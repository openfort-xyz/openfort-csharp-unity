using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Openfort.OpenfortSDK.Event;
using Openfort.OpenfortSDK.Model;
using Openfort.OpenfortSDK.Core;
using Openfort.OpenfortSDK.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Cysharp.Threading.Tasks;
#if UNITY_ANDROID
using UnityEngine.Android;
#endif

namespace Openfort.OpenfortSDK
{
#if UNITY_ANDROID
    public class OpenfortImpl : Callback
#else
    public class OpenfortImpl
#endif
    {
        private const string TAG = "[Openfort Implementation]";

        static readonly JsonSerializerSettings s_JsonSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
        };

        public readonly IBrowserCommunicationsManager communicationsManager;

        private UniTaskCompletionSource<bool> deviceFlowCompletionSource;
        private string redirectUri = null;
        private Func<string, Task<string>> _getThirdPartyToken;


#if UNITY_ANDROID
        // Used for the custom callback
        internal static bool completingDeviceFlow = false;
        internal static string loginDeviceFlowUrl;
#endif

        // Used to prevent calling login functions multiple times
        private bool isLoggedIn = false;

        public event OnAuthEventDelegate OnAuthEvent;

        public OpenfortImpl(IBrowserCommunicationsManager communicationsManager)
        {
            this.communicationsManager = communicationsManager;
        }

        public async UniTask Init(string publishableKey,
            string shieldPublishableKey,
            bool shieldDebug,
            string backendUrl,
            string iframeUrl,
            string shieldUrl,
            string deeplink,
            string thirdPartyProvider,
            Func<string, Task<string>> getThirdPartyToken
            )
        {
            communicationsManager.OnPostMessageError += OnPostMessageError;
            communicationsManager.OnAuthPostMessage += OnDeepLinkActivated;
            communicationsManager.OnThirdPartyTokenRequested += OnThirdPartyTokenRequested;

            _getThirdPartyToken = getThirdPartyToken;

            string initRequest;

            InitRequest request = new InitRequest()
            {
                publishableKey = publishableKey,
                shieldPublishableKey = shieldPublishableKey,
                shieldDebug = shieldDebug,
                backendUrl = backendUrl,
                iframeUrl = iframeUrl,
                shieldUrl = shieldUrl,
                thirdPartyAuth = new ThirdPartyAuth { provider = thirdPartyProvider },
                nativeAppIdentifier = Application.identifier
            };
            initRequest = JsonUtility.ToJson(request);


            string response = await communicationsManager.Call(OpenfortFunction.INIT, initRequest);
            BrowserResponse initResponse = response.OptDeserializeObject<BrowserResponse>();

            if (initResponse.success == false)
            {
                throw new OpenfortException(initResponse.error ?? "Unable to initialize Openfort");
            }
            else if (deeplink != null)
            {
                OnDeepLinkActivated(deeplink);
            }
        }
        public async void OnDeepLinkActivated(string url)
        {
            try
            {
                Debug.Log($"{TAG} OnDeepLinkActivated URL: {url}");
                Uri uri = new Uri(url);
                string domain = $"{uri.Scheme}://{uri.Host}{uri.AbsolutePath}";
                if (domain.EndsWith("/"))
                {
                    domain = domain.Remove(domain.Length - 1);
                }

                if (domain.Equals(redirectUri))
                {
                    Debug.Log($"{TAG} OnDeepLinkActivated Redirect URI: {url}");
                    await CompleteAuthenticationFlow(url);
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"{TAG} OnDeepLinkActivated error {url}: {e.Message}");
            }
        }

        private async void OnThirdPartyTokenRequested(string requestId)
        {
            var token = string.Empty;

            if (_getThirdPartyToken != null)
            {
                try
                {
                    token = await _getThirdPartyToken(requestId);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"{TAG} Get third party token error: {ex.Message}");
                }
            }

            communicationsManager.CallFunction(requestId,
                OpenfortFunction.SET_THIRD_PARTY_TOKEN,
                JsonConvert.SerializeObject(new SetThirdPartyTokenRequest() { Token = token }, s_JsonSettings));
        }

        public async UniTask<AuthResponse> SignUpGuest()
        {
            string functionName = "signUpGuest";
            SendAuthEvent(OpenfortAuthEvent.LoggingIn);

            string callResponse = await communicationsManager.Call(
                functionName
            );

            return callResponse.OptDeserializeObject<AuthResponse>();
        }
        public async UniTask<AuthResponse> LogInWithEmailPassword(string email, string password)
        {
            string functionName = "logInWithEmailPassword";
            SendAuthEvent(OpenfortAuthEvent.LoggingIn);
            LoginEmailPasswordRequest request = new LoginEmailPasswordRequest(email, password);

            string callResponse = await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );

            return callResponse.OptDeserializeObject<AuthResponse>();
        }
        public async UniTask<AuthResponse> SignUpWithEmailPassword(string email, string password, string name = null)
        {
            string functionName = "signUpWithEmailPassword";
            SendAuthEvent(OpenfortAuthEvent.LoggingIn);
            SignupEmailPasswordRequest request = new SignupEmailPasswordRequest(
                email: email,
                password: password,
                options: new Options(
                    data: new Data(name)
                )
            );

            string callResponse = await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );
            AuthResponse authResponse = callResponse.OptDeserializeObject<AuthResponse>();

            if (authResponse == null)
            {
                SendAuthEvent(OpenfortAuthEvent.LoginFailed);
                throw new OpenfortException(
                    "Unable to login, call {functionName} again",
                    OpenfortErrorType.AUTHENTICATION_ERROR
                );
            }
            else
            {
                SendAuthEvent(OpenfortAuthEvent.LoginSuccess);
                isLoggedIn = true;
                return authResponse;
            }

        }
        public async UniTask RequestResetPassword(ResetPasswordRequest request)
        {
            string functionName = "requestResetPassword";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );
            BrowserResponse response = callResponse.OptDeserializeObject<BrowserResponse>();
            if (response == null || response?.success == false)
            {
                throw new OpenfortException(
                    response?.error ?? $"Unable to confirm code, call {functionName} again",
                    OpenfortErrorType.AUTHENTICATION_ERROR
                );
            }
        }
        public async UniTask ResetPassword(ResetPasswordRequest request)
        {
            string functionName = "resetPassword";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );
            BrowserResponse response = callResponse.OptDeserializeObject<BrowserResponse>();
            if (response == null || response?.success == false)
            {
                throw new OpenfortException(
                    response?.error ?? "Unable to reset password",
                    OpenfortErrorType.AUTHENTICATION_ERROR
                );
            }
        }
        public async UniTask RequestEmailVerification(RequestEmailVerificationRequest request)
        {
            string functionName = "requestEmailVerification";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );
            BrowserResponse response = callResponse.OptDeserializeObject<BrowserResponse>();
            if (response == null || response?.success == false)
            {
                throw new OpenfortException(
                    response?.error ?? $"Unable to confirm code, call {functionName} again",
                    OpenfortErrorType.AUTHENTICATION_ERROR
                );
            }
        }
        public async UniTask VerifyEmail(VerifyEmailRequest request)
        {
            string functionName = "verifyEmail";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );
            BrowserResponse response = callResponse.OptDeserializeObject<BrowserResponse>();
            if (response == null || response?.success == false)
            {
                throw new OpenfortException(
                    response?.error ?? "Unable to verify email",
                    OpenfortErrorType.AUTHENTICATION_ERROR
                );
            }
        }

        public async UniTask<bool> AuthenticateWithOAuth(OAuthInitRequest request)
        {
            try
            {
                InitAuthResponse deviceConnectResponse = await InitOAuth(request);
                if (request.Options != null && request.Options.RedirectTo != null)
                {
                    redirectUri = request.Options.RedirectTo;
                }
                UniTaskCompletionSource<bool> task = new UniTaskCompletionSource<bool>();
                deviceFlowCompletionSource = task;
                _ = LaunchAuthUrl(deviceConnectResponse.url);
                return await task.Task;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async UniTask LaunchAuthUrl(string url)
        {
            try
            {
#if UNITY_ANDROID && !UNITY_EDITOR
                    loginDeviceFlowUrl = url;
                    LaunchAndroidUrl(url);
#else
                communicationsManager.LaunchAuthURL(url, redirectUri);
#endif
                return;
            }
            catch (Exception e)
            {
                Debug.Log($"{TAG} Get Auth URL error: {e.Message}");
            }

            await UniTask.SwitchToMainThread();
            TrySetDeviceFlowException(new OpenfortException(
                "Something went wrong, please call AuthenticateWithOAuth() again",
                OpenfortErrorType.AUTHENTICATION_ERROR
            ));
        }
        public async UniTask<InitAuthResponse> InitOAuth(OAuthInitRequest request)
        {
            string functionName = "initOAuth";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonConvert.SerializeObject(request)
            );
            return callResponse.OptDeserializeObject<InitAuthResponse>();
        }
        public async UniTask<User> UnlinkOAuth(UnlinkOAuthRequest request)
        {
            string functionName = "unlinkOAuth";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );
            return callResponse.OptDeserializeObject<User>();
        }
        public async UniTask<InitAuthResponse> InitLinkOAuth(InitLinkOAuthRequest request)
        {
            string functionName = "initLinkOAuth";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );
            return callResponse.OptDeserializeObject<InitAuthResponse>();
        }
        public async UniTask<InitSiweResponse> InitSiwe(InitSiweRequest request)
        {
            string functionName = "initSIWE";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );
            return callResponse.OptDeserializeObject<InitSiweResponse>();
        }
        public async UniTask<AuthResponse> AuthenticateWithSiwe(AuthenticateWithSiweRequest request)
        {
            string functionName = "authenticateWithSIWE";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );
            return callResponse.OptDeserializeObject<AuthResponse>();
        }
        public async UniTask<User> LinkWallet(LinkWalletRequest request)
        {
            string functionName = "linkWallet";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );
            return callResponse.OptDeserializeObject<User>();
        }
        public async UniTask<User> UnlinkWallet(UnlinkWalletRequest request)
        {
            string functionName = "unlinkWallet";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );
            return callResponse.OptDeserializeObject<User>();
        }

        public async UniTask<InitSiweResponse> LinkSiwe(LinkSiweRequest request)
        {
            string callResponse = await communicationsManager.Call(
                OpenfortFunction.LINK_SIWE,
                JsonUtility.ToJson(request)
            );
            return callResponse.OptDeserializeObject<InitSiweResponse>();
        }

        // Email OTP Methods
        public async UniTask RequestEmailOtp(EmailOtpRequest request)
        {
            string callResponse = await communicationsManager.Call(
                OpenfortFunction.REQUEST_EMAIL_OTP,
                JsonUtility.ToJson(request)
            );
            BrowserResponse response = callResponse.OptDeserializeObject<BrowserResponse>();
            if (response == null || response?.success == false)
            {
                throw new OpenfortException(
                    response?.error ?? "Unable to request email OTP",
                    OpenfortErrorType.AUTHENTICATION_ERROR
                );
            }
        }

        public async UniTask<AuthResponse> LogInWithEmailOtp(LoginEmailOtpRequest request)
        {
            SendAuthEvent(OpenfortAuthEvent.LoggingIn);
            string callResponse = await communicationsManager.Call(
                OpenfortFunction.LOGIN_WITH_EMAIL_OTP,
                JsonUtility.ToJson(request)
            );
            AuthResponse authResponse = callResponse.OptDeserializeObject<AuthResponse>();
            if (authResponse == null)
            {
                SendAuthEvent(OpenfortAuthEvent.LoginFailed);
                throw new OpenfortException(
                    "Unable to login with email OTP",
                    OpenfortErrorType.AUTHENTICATION_ERROR
                );
            }
            SendAuthEvent(OpenfortAuthEvent.LoginSuccess);
            isLoggedIn = true;
            return authResponse;
        }

        public async UniTask VerifyEmailOtp(VerifyEmailOtpRequest request)
        {
            string callResponse = await communicationsManager.Call(
                OpenfortFunction.VERIFY_EMAIL_OTP,
                JsonUtility.ToJson(request)
            );
            BrowserResponse response = callResponse.OptDeserializeObject<BrowserResponse>();
            if (response == null || response?.success == false)
            {
                throw new OpenfortException(
                    response?.error ?? "Unable to verify email OTP",
                    OpenfortErrorType.AUTHENTICATION_ERROR
                );
            }
        }

        public async UniTask<User> AddEmail(AddEmailRequest request)
        {
            string callResponse = await communicationsManager.Call(
                OpenfortFunction.ADD_EMAIL,
                JsonUtility.ToJson(request)
            );
            return callResponse.OptDeserializeObject<User>();
        }

        // Phone OTP Methods
        public async UniTask RequestPhoneOtp(PhoneOtpRequest request)
        {
            string callResponse = await communicationsManager.Call(
                OpenfortFunction.REQUEST_PHONE_OTP,
                JsonUtility.ToJson(request)
            );
            BrowserResponse response = callResponse.OptDeserializeObject<BrowserResponse>();
            if (response == null || response?.success == false)
            {
                throw new OpenfortException(
                    response?.error ?? "Unable to request phone OTP",
                    OpenfortErrorType.AUTHENTICATION_ERROR
                );
            }
        }

        public async UniTask<AuthResponse> LogInWithPhoneOtp(LoginPhoneOtpRequest request)
        {
            SendAuthEvent(OpenfortAuthEvent.LoggingIn);
            string callResponse = await communicationsManager.Call(
                OpenfortFunction.LOGIN_WITH_PHONE_OTP,
                JsonUtility.ToJson(request)
            );
            AuthResponse authResponse = callResponse.OptDeserializeObject<AuthResponse>();
            if (authResponse == null)
            {
                SendAuthEvent(OpenfortAuthEvent.LoginFailed);
                throw new OpenfortException(
                    "Unable to login with phone OTP",
                    OpenfortErrorType.AUTHENTICATION_ERROR
                );
            }
            SendAuthEvent(OpenfortAuthEvent.LoginSuccess);
            isLoggedIn = true;
            return authResponse;
        }

        public async UniTask<AuthResponse> LinkPhoneOtp(LinkPhoneOtpRequest request)
        {
            string callResponse = await communicationsManager.Call(
                OpenfortFunction.LINK_PHONE_OTP,
                JsonUtility.ToJson(request)
            );
            return callResponse.OptDeserializeObject<AuthResponse>();
        }

        // ID Token Methods
        public async UniTask<AuthResponse> LogInWithIdToken(LoginIdTokenRequest request)
        {
            SendAuthEvent(OpenfortAuthEvent.LoggingIn);
            string callResponse = await communicationsManager.Call(
                OpenfortFunction.LOGIN_WITH_ID_TOKEN,
                JsonUtility.ToJson(request)
            );
            AuthResponse authResponse = callResponse.OptDeserializeObject<AuthResponse>();
            if (authResponse == null)
            {
                SendAuthEvent(OpenfortAuthEvent.LoginFailed);
                throw new OpenfortException(
                    "Unable to login with ID token",
                    OpenfortErrorType.AUTHENTICATION_ERROR
                );
            }
            SendAuthEvent(OpenfortAuthEvent.LoginSuccess);
            isLoggedIn = true;
            return authResponse;
        }

        public async UniTask StoreCredentials(AuthCredentialsRequest request)
        {
            string functionName = "storeCredentials";
            await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );
        }
        public async UniTask<User> GetUser()
        {
            string functionName = "getUser";
            string callResponse = await communicationsManager.Call(
                functionName
            );
            return callResponse.OptDeserializeObject<User>();
        }
        public async UniTask Logout()
        {
            string functionName = "logout";
            string callResponse = await communicationsManager.Call(
                functionName
            );
            BrowserResponse response = callResponse.OptDeserializeObject<BrowserResponse>();
            if (response == null || response?.success == false)
            {
                throw new OpenfortException(
                    response?.error ?? $"Unable to confirm code, call {functionName} again",
                    OpenfortErrorType.AUTHENTICATION_ERROR
                );
            }
            if (isLoggedIn)
            {
                TrySetDeviceFlowResult(true);
            }
            isLoggedIn = false;
            deviceFlowCompletionSource = null;

        }
        public async UniTask CompleteAuthenticationFlow(string uriString)
        {
#if UNITY_ANDROID
                    completingDeviceFlow = true;
#endif
            try
            {
                Uri uri = new Uri(uriString);
                string accessToken = uri.GetQueryParameter("access_token");
                string refreshToken = uri.GetQueryParameter("refresh_token");

                if (String.IsNullOrEmpty(accessToken) || String.IsNullOrEmpty(refreshToken))
                {
                    await UniTask.SwitchToMainThread();
                    TrySetDeviceFlowException(new OpenfortException(
                        "Uri was missing accessToken and/or refreshToken. Please call AuthenticateWithOAuth() again",
                        OpenfortErrorType.AUTHENTICATION_ERROR
                    ));
                }
                else
                {
                    AuthCredentialsRequest request = new AuthCredentialsRequest("undefined", accessToken, refreshToken);

                    string callResponse = await communicationsManager.Call(
                            OpenfortFunction.STORE_CREDENTIALS,
                            JsonUtility.ToJson(request)
                        );

                    BrowserResponse response = callResponse.OptDeserializeObject<BrowserResponse>();
                    await UniTask.SwitchToMainThread();

                    if (response != null && response.success != true)
                    {
                        TrySetDeviceFlowException(new OpenfortException(
                            response.error ?? "Something went wrong, please call AuthenticateWithOAuth() again",
                            OpenfortErrorType.AUTHENTICATION_ERROR
                        ));
                    }
                    else
                    {
                        if (!isLoggedIn)
                        {
                            TrySetDeviceFlowResult(true);
                        }

                        isLoggedIn = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Ensure any failure results in completing the flow regardless.
                TrySetDeviceFlowException(ex);
            }

            deviceFlowCompletionSource = null;
#if UNITY_ANDROID
                    completingDeviceFlow = false;
#endif
        }

#if UNITY_ANDROID
        public void OnLoginDismissed(bool completing)
        {
            Debug.Log($"{TAG} On Login Dismissed");
            if (!completing && !isLoggedIn)
            {
                // User hasn't entered all required details (e.g. email address) 
                Debug.Log($"{TAG} Login dismissed before completing the flow");
                TrySetDeviceFlowCanceled();
            }
            else
            {
                Debug.Log($"{TAG} Login dismissed by user or SDK");
            }
            loginDeviceFlowUrl = null;
        }

        public void OnDeeplinkResult(string url)
        {
            OnDeepLinkActivated(url);
        }
#endif
        public async UniTask<string> GetAccessToken()
        {
            string response = await communicationsManager.Call(OpenfortFunction.GET_ACCESS_TOKEN);
            string token = response.GetStringResult();
            return token != null ? Uri.EscapeDataString(token) : null;
        }
        public async UniTask<AuthResponse> ValidateAndRefreshToken(ValidateAndRefreshTokenRequest request)
        {
            string functionName = "validateAndRefreshToken";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );
            return callResponse.OptDeserializeObject<AuthResponse>();
        }
        public async UniTask<TransactionIntentResponse> SendSignatureTransactionIntentRequest(SignatureTransactionIntentRequest request)
        {
            string functionName = "sendSignatureTransactionIntentRequest";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonConvert.SerializeObject(request)
            );

            // This is likely not needed when stripping is set to minimum
            string modifiedResponse = JsonHelpers.RemoveKeysFromJson(callResponse, "responseFor", "requestId", "success");

            return modifiedResponse.OptDeserializeObject<TransactionIntentResponse>();
        }
        public async UniTask<string> SignMessage(SignMessageRequest request)
        {
            string functionName = "signMessage";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );
            return callResponse.GetStringResult();
        }
        public async UniTask<string> SignTypedData(SignTypedDataRequest request)
        {
            string functionName = "signTypedData";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonConvert.SerializeObject(request)
            );
            return callResponse.GetStringResult();
        }
        [Serializable]
        public class EmbeddedStateResponse
        {
            public string responseFor;
            public string requestId;
            public bool success;
            public int result;
        }

        public async UniTask<EmbeddedState> GetEmbeddedState()
        {
            string functionName = "getEmbeddedState";
            string callResponse = await communicationsManager.Call(functionName);
            Debug.Log($"{TAG} getEmbeddedState response: {callResponse}");

            try
            {
                EmbeddedStateResponse response = JsonConvert.DeserializeObject<EmbeddedStateResponse>(callResponse);

                if (response != null && response.success)
                {
                    return (EmbeddedState)response.result;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"{TAG} Error parsing embedded state: {ex.Message}");
            }

            return EmbeddedState.NONE;
        }
        public async UniTask<Provider> GetEthereumProvider(EthereumProviderRequest request)
        {
            string functionName = "getEthereumProvider";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonUtility.ToJson(request)
            );
            return callResponse.OptDeserializeObject<Provider>();
        }
        public async UniTask<EmbeddedAccount> CreateEmbeddedWallet(CreateEmbeddedWalletRequest request)
        {
            string functionName = "createEmbeddedWallet";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonConvert.SerializeObject(request, s_JsonSettings)
            );
            return callResponse.OptDeserializeObject<EmbeddedAccount>(s_JsonSettings);
        }
        public async UniTask<EmbeddedAccount> RecoverEmbeddedWallet(RecoverEmbeddedWalletRequest request)
        {
            string functionName = "recoverEmbeddedWallet";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonConvert.SerializeObject(request, s_JsonSettings)
            );
            return callResponse.OptDeserializeObject<EmbeddedAccount>(s_JsonSettings);
        }
        public async UniTask<EmbeddedAccount> GetWallet()
        {
            string functionName = "getWallet";
            string callResponse = await communicationsManager.Call(functionName);
            return callResponse.OptDeserializeObject<EmbeddedAccount>(s_JsonSettings);
        }
        public async UniTask<EmbeddedAccount[]> ListWallets(ListWalletsRequest request)
        {
            string functionName = "listWallets";
            string callResponse = await communicationsManager.Call(
                functionName,
                JsonConvert.SerializeObject(request, s_JsonSettings)
            );
            return callResponse.OptDeserializeObject<EmbeddedAccount[]>(s_JsonSettings);
        }
        public async UniTask ConfigureEmbeddedWallet(ConfigureEmbeddedWalletRequest request)
        {
            string x = JsonUtility.ToJson(request);

            string functionName = "configureEmbeddedWallet";
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new StringEnumConverter() }
            };

            string response = await communicationsManager.Call(
                functionName,
                JsonConvert.SerializeObject(request, settings)
            );

            BrowserResponse browserResponse = response.OptDeserializeObject<BrowserResponse>();
            if (browserResponse.success == false)
            {
                throw new OpenfortException(browserResponse.error ?? "Unable to configure embedded signer");
            }
        }
        private async void OnPostMessageError(string id, string message)
        {
            if (id == "CallFromAuthCallbackError" && deviceFlowCompletionSource != null)
            {
                await CallFromAuthCallbackError(id, message);
            }
            else
            {
                Debug.LogError($"{TAG} id: {id} err: {message}");
            }
        }

        private async UniTask CallFromAuthCallbackError(string id, string message)
        {
            await UniTask.SwitchToMainThread();

            if (message == "")
            {
                Debug.Log($"{TAG} Get Auth URL user cancelled");
                TrySetDeviceFlowCanceled();
            }
            else
            {
                Debug.Log($"{TAG} Get Auth URL error: {message}");
                TrySetDeviceFlowException(new OpenfortException(
                    "Something went wrong, please call AuthenticateWithOAuth() again",
                    OpenfortErrorType.AUTHENTICATION_ERROR
                ));
            }

            deviceFlowCompletionSource = null;
        }

        private void TrySetDeviceFlowResult(bool result)
        {
            Debug.Log($"{TAG} Trying to set result to {result}...");
            if (deviceFlowCompletionSource != null)
            {
                deviceFlowCompletionSource.TrySetResult(result);
            }
            else
            {
                Debug.LogError($"{TAG} completed with {result} but unable to bind result");
            }
        }

        private void TrySetDeviceFlowException(Exception exception)
        {
            Debug.Log($"{TAG} Trying to set exception...");
            if (deviceFlowCompletionSource != null)
            {
                deviceFlowCompletionSource.TrySetException(exception);
            }
            else
            {
                Debug.LogError($"{TAG} {exception.Message}");
            }
        }
        private void TrySetDeviceFlowCanceled()
        {
            Debug.Log($"{TAG} Trying to set canceled...");
            if (deviceFlowCompletionSource != null)
            {
                deviceFlowCompletionSource.TrySetCanceled();
            }
            else
            {
                Debug.LogWarning($"{TAG} canceled");
            }
        }
        private void SendAuthEvent(OpenfortAuthEvent authEvent)
        {
            Debug.Log($"{TAG} Send auth event: {authEvent}");
            if (OnAuthEvent != null)
            {
                OnAuthEvent.Invoke(authEvent);
            }
        }
        protected virtual void OpenUrl(string url)
        {
            Application.OpenURL(url);
        }


#if UNITY_ANDROID
        private void LaunchAndroidUrl(string url)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass customTabLauncher = new AndroidJavaClass("com.openfort.unity.OpenfortActivity");
            customTabLauncher.CallStatic("startActivity", activity, url, new AndroidCallback(this));
        }
#endif
        public void ClearCache(bool includeDiskFiles)
        {
            communicationsManager.ClearCache(includeDiskFiles);
        }

        public void ClearStorage()
        {
            communicationsManager.ClearStorage();
        }
    }
#if UNITY_ANDROID
    public interface Callback
    {

        /// <summary>
        /// Called when the Android Chrome Custom Tabs is hidden. 
        /// Note that you won't be able to tell whether it was closed by the user or the SDK.
        /// <param name="completing">True if the user has entered everything required (e.g. email address),
        /// Chrome Custom Tabs have closed, and the SDK is trying to complete the flow.
        /// </summary>
        void OnLoginDismissed(bool completing);

        void OnDeeplinkResult(string url);
    }

    class AndroidCallback : AndroidJavaProxy
    {
        private Callback callback;

        public AndroidCallback(Callback callback) : base("com.openfort.unity.OpenfortActivity$Callback")
        {
            this.callback = callback;
        }

        async void onCustomTabsDismissed(string url)
        {
            await UniTask.SwitchToMainThread();

            // To differentiate what triggered this
            if (url == OpenfortImpl.loginDeviceFlowUrl)
            {
                // Custom tabs dismissed for login flow
                callback.OnLoginDismissed(OpenfortImpl.completingDeviceFlow);
            }
        }

        async void onDeeplinkResult(string url)
        {
            await UniTask.SwitchToMainThread();
            callback.OnDeeplinkResult(url);
        }
    }
#endif
}