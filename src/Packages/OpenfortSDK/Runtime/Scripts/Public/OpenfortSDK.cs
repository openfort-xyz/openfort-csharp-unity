#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
#define OPENFORT_USE_UWB
#elif UNITY_WEBGL || UNITY_IOS || UNITY_ANDROID || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
#define OPENFORT_USE_GREE
#endif
using System;
#if OPENFORT_USE_UWB
using VoltstroStudios.UnityWebBrowser.Core;
#elif OPENFORT_USE_GREE
using Openfort.Browser.Gree;
#endif
using Openfort.OpenfortSDK.Event;
using Openfort.Browser.Core;
using Openfort.OpenfortSDK.Model;
using Openfort.OpenfortSDK.Core;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Openfort.OpenfortSDK
{

    public class OpenfortSDK
    {
        private const string TAG = "[OpenfortSDK]";

        public static OpenfortSDK Instance { get; private set; }

        private IWebBrowserClient webBrowserClient;
        // Keeps track of the latest received deeplink
        private static string deeplink = null;
        private static bool readySignalReceived = false;
        private OpenfortImpl openfortImpl = null;

        public event OnAuthEventDelegate OnAuthEvent;

        private OpenfortSDK()
        {
            Application.quitting += OnQuit;
#if UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
            Application.deepLinkActivated += OnDeepLinkActivated;
            if (!string.IsNullOrEmpty(Application.absoluteURL))
            {
                // Cold start and Application.absoluteURL not null so process Deep Link.
                OnDeepLinkActivated(Application.absoluteURL);
            }
#endif
        }

        /// <summary>
        /// Initializes OpenfortSDK.
        /// </summary>
        /// <param name="publishableKey">Openfort publishable key</param>
        /// <param name="shieldPublishableKey">Shield publishable key</param>
        /// <param name="shieldEncryptionKey">Shield encryption key</param>
        /// <param name="shieldDebug">Enable shield debug mode</param>
        /// <param name="backendUrl">Backend URL</param>
        /// <param name="iframeUrl">Iframe URL</param>
        /// <param name="shieldUrl">Shield URL</param>
        /// <param name="engineStartupTimeoutMs">(Windows only) Timeout time for waiting for the engine to start (in milliseconds)</param>
        public static UniTask<OpenfortSDK> Init(
#if OPENFORT_USE_UWB
            string publishableKey, string shieldPublishableKey = null, string shieldEncryptionKey = null, bool shieldDebug = false, string backendUrl = "https://api.openfort.xyz", string iframeUrl = "https://iframe.openfort.xyz", string shieldUrl = "https://shield.openfort.xyz", int engineStartupTimeoutMs = 4000
#elif OPENFORT_USE_GREE
            string publishableKey, string shieldPublishableKey = null, string shieldEncryptionKey = null, bool shieldDebug = false, string backendUrl = "https://api.openfort.xyz", string iframeUrl = "https://iframe.openfort.xyz", string shieldUrl = "https://shield.openfort.xyz"
#endif
        )
        {
            if (Instance == null)
            {
                Debug.Log($"{TAG} Initializing Openfort...");
                Instance = new OpenfortSDK();
                return Instance.Initialize(
#if OPENFORT_USE_UWB
                        engineStartupTimeoutMs
#endif
                    )
                    .ContinueWith(async () =>
                    {
                        Debug.Log($"{TAG} Waiting for ready signal...");
                        await UniTask.WaitUntil(() => readySignalReceived == true);
                    })
                    .ContinueWith(async () =>
                    {
                        if (readySignalReceived == true)
                        {
                            await Instance.GetOpenfortImpl().Init(publishableKey, shieldPublishableKey, shieldEncryptionKey, shieldDebug, backendUrl, iframeUrl, shieldUrl, deeplink);
                            return Instance;
                        }
                        else
                        {
                            Debug.Log($"{TAG} Failed to initialize OpenfortSDK");
                            throw new OpenfortException("Failed to initialize OpenfortSDK", OpenfortErrorType.INITIALIZATION_ERROR);
                        }
                    });
            }
            else
            {
                readySignalReceived = true;
                return UniTask.FromResult(Instance);
            }
        }

        private async UniTask Initialize(
#if OPENFORT_USE_UWB
            int engineStartupTimeoutMs
#endif
        )
        {
            try
            {
#if OPENFORT_USE_UWB
                webBrowserClient = new WebBrowserClient();
#elif OPENFORT_USE_GREE
                webBrowserClient = new GreeBrowserClient();
#endif 
                BrowserCommunicationsManager communicationsManager = new BrowserCommunicationsManager(webBrowserClient);
                communicationsManager.OnReady += () => readySignalReceived = true;
#if OPENFORT_USE_UWB
                await ((WebBrowserClient)webBrowserClient).Init(engineStartupTimeoutMs);
#endif
                openfortImpl = new OpenfortImpl(communicationsManager);
                openfortImpl.OnAuthEvent += OnOpenfortAuthEvent;
            }
            catch (Exception ex)
            {
                readySignalReceived = false;
                Instance = null;
                throw ex;
            }
        }

        private void OnQuit()
        {
#if OPENFORT_USE_UWB
            Debug.Log($"{TAG} Quitting the Player");
            ((WebBrowserClient)webBrowserClient).Dispose();
#endif
        }

        /// <summary>
        /// Sets the timeout time for waiting for each call to respond (in milliseconds).
        /// This only applies to functions that use the browser communications manager.
        /// </summary>
        /// <param name="ms">Timeout duration in milliseconds</param>
        public void SetCallTimeout(int ms)
        {
            GetOpenfortImpl().communicationsManager.SetCallTimeout(ms);
        }

        /// <summary>
        /// Logs the user into Openfort via LoginWithEmailPassword.
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="password">User password</param>
        public async UniTask<AuthResponse> LogInWithEmailPassword(string email, string password)
        {
            return await GetOpenfortImpl().LogInWithEmailPassword(email, password);
        }

        /// <summary>
        /// Logs the user into Openfort via SignUpWithEmailPassword.
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="password">User password</param>
        /// <param name="name">User name</param>
        public async UniTask<AuthResponse> SignUpWithEmailPassword(string email, string password, string name = null)
        {
            return await GetOpenfortImpl().SignUpWithEmailPassword(email, password, name);
        }

        /// <summary>
        /// Links an email and password to the user account.
        /// </summary>
        /// <param name="request">Link email and password request</param>
        public async UniTask<AuthPlayerResponse> LinkEmailPassword(LinkEmailPasswordRequest request)
        {
            return await GetOpenfortImpl().LinkEmailPassword(request);
        }

        /// <summary>
        /// Unlinks an email and password from the user account.
        /// </summary>
        /// <param name="request">Unlink email and password request</param>
        public async UniTask<AuthPlayerResponse> UnlinkEmailPassword(UnlinkEmailPasswordRequest request)
        {
            return await GetOpenfortImpl().UnlinkEmailPassword(request);
        }

        /// <summary>
        /// Requests a password reset.
        /// </summary>
        /// <param name="request">Password reset request</param>
        public async UniTask RequestResetPassword(ResetPasswordRequest request)
        {
            await GetOpenfortImpl().RequestResetPassword(request);
        }

        /// <summary>
        /// Resets the user password.
        /// </summary>
        /// <param name="request">Reset password request</param>
        public async UniTask<AuthPlayerResponse> ResetPassword(ResetPasswordRequest request)
        {
            return await GetOpenfortImpl().ResetPassword(request);
        }

        /// <summary>
        /// Requests an email verification.
        /// </summary>
        /// <param name="request">Email verification request</param>
        public async UniTask RequestEmailVerification(RequestEmailVerificationRequest request)
        {
            await GetOpenfortImpl().RequestEmailVerification(request);
        }

        /// <summary>
        /// Verifies the user email.
        /// </summary>
        /// <param name="request">Verify email request</param>
        public async UniTask<AuthPlayerResponse> VerifyEmail(VerifyEmailRequest request)
        {
            return await GetOpenfortImpl().VerifyEmail(request);
        }

        /// <summary>
        /// Initializes OAuth for the user.
        /// </summary>
        /// <param name="request">OAuth initialization request</param>
        public async UniTask<InitAuthResponse> InitOAuth(OAuthInitRequest request)
        {
            return await GetOpenfortImpl().InitOAuth(request);
        }

        public async UniTask<bool> AuthenticateWithOAuth(OAuthInitRequest request)
        {
            return await GetOpenfortImpl().AuthenticateWithOAuth(request);
        }

        /// <summary>
        /// Unlinks OAuth from the user account.
        /// </summary>
        /// <param name="request">Unlink OAuth request</param>
        public async UniTask<AuthPlayerResponse> UnlinkOAuth(UnlinkOAuthRequest request)
        {
            return await GetOpenfortImpl().UnlinkOAuth(request);
        }

        /// <summary>
        /// Pools OAuth for the user account.
        /// </summary>
        /// <param name="request">Pool OAuth request</param>
        public async UniTask<AuthResponse> PoolOAuth(PoolOAuthRequest request)
        {
            return await GetOpenfortImpl().PoolOAuth(request);
        }

        /// <summary>
        /// Initializes the link OAuth process.
        /// </summary>
        /// <param name="request">Link OAuth initialization request</param>
        public async UniTask<InitAuthResponse> InitLinkOAuth(InitLinkOAuthRequest request)
        {
            return await GetOpenfortImpl().InitLinkOAuth(request);
        }

        /// <summary>
        /// Authenticates the user with a third-party provider.
        /// </summary>
        /// <param name="request">Third-party provider authentication request</param>
        public async UniTask<AuthPlayerResponse> AuthenticateWithThirdPartyProvider(ThirdPartyOAuthRequest request)
        {
            return await GetOpenfortImpl().AuthenticateWithThirdPartyProvider(request);
        }

        /// <summary>
        /// Initializes Sign-In with Ethereum (SIWE).
        /// </summary>
        /// <param name="request">SIWE initialization request</param>
        public async UniTask<InitSiweResponse> InitSiwe(InitSiweRequest request)
        {
            return await GetOpenfortImpl().InitSiwe(request);
        }

        /// <summary>
        /// Authenticates the user with SIWE.
        /// </summary>
        /// <param name="request">SIWE authentication request</param>
        public async UniTask<AuthResponse> AuthenticateWithSiwe(AuthenticateWithSiweRequest request)
        {
            return await GetOpenfortImpl().AuthenticateWithSiwe(request);
        }

        /// <summary>
        /// Links a wallet to the user account.
        /// </summary>
        /// <param name="request">Link wallet request</param>
        public async UniTask<AuthPlayerResponse> LinkWallet(LinkWalletRequest request)
        {
            return await GetOpenfortImpl().LinkWallet(request);
        }

        /// <summary>
        /// Unlinks a wallet from the user account.
        /// </summary>
        /// <param name="request">Unlink wallet request</param>
        public async UniTask<AuthPlayerResponse> UnlinkWallet(UnlinkWalletRequest request)
        {
            return await GetOpenfortImpl().UnlinkWallet(request);
        }

        /// <summary>
        /// Stores authentication credentials.
        /// </summary>
        /// <param name="request">Authentication credentials request</param>
        public async UniTask StoreCredentials(AuthCredentialsRequest request)
        {
            await GetOpenfortImpl().StoreCredentials(request);
        }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        public async UniTask<AuthPlayerResponse> GetUser()
        {
            return await GetOpenfortImpl().GetUser();
        }

        /// <summary>
        /// Logs the user out of Openfort and removes any stored credentials.
        /// </summary>
        public async UniTask Logout()
        {
            await GetOpenfortImpl().Logout();
        }

        /// <summary>
        /// Gets the currently saved access token without verifying its validity.
        /// </summary>
        /// <returns>The access token, otherwise null</returns>
        public UniTask<string> GetAccessToken()
        {
            return GetOpenfortImpl().GetAccessToken();
        }

        /// <summary>
        /// Validates and refreshes the access token.
        /// </summary>
        public async UniTask<AuthResponse> ValidateAndRefreshToken(ValidateAndRefreshTokenRequest request)
        {
            return await GetOpenfortImpl().ValidateAndRefreshToken(request);
        }

        /// <summary>
        /// Sends a signature transaction intent request.
        /// </summary>
        /// <param name="request">Signature transaction intent request</param>
        public async UniTask<TransactionIntentResponse> SendSignatureTransactionIntentRequest(SignatureTransactionIntentRequest request)
        {
            return await GetOpenfortImpl().SendSignatureTransactionIntentRequest(request);
        }

        /// <summary>
        /// Signs a message.
        /// </summary>
        /// <param name="request">Sign message request</param>
        public async UniTask<string> SignMessage(SignMessageRequest request)
        {
            return await GetOpenfortImpl().SignMessage(request);
        }

        /// <summary>
        /// Signs typed data.
        /// </summary>
        /// <param name="request">Sign typed data request</param>
        public async UniTask<string> SignTypedData(SignTypedDataRequest request)
        {
            return await GetOpenfortImpl().SignTypedData(request);
        }

        /// <summary>
        /// Sends a transaction signed by a session.
        /// </summary>
        /// <param name="request">Register session request</param>
        public async UniTask<SessionResponse> SendSignatureSessionRequest(RegisterSessionRequest request)
        {
            return await GetOpenfortImpl().SendSignatureSessionRequest(request);
        }

        /// <summary>
        /// Gets the embedded state.
        /// </summary>
        public async UniTask<EmbeddedState> GetEmbeddedState()
        {
            return await GetOpenfortImpl().GetEmbeddedState();
        }

        /// <summary>
        /// Gets the Ethereum provider.
        /// </summary>
        /// <param name="request">Ethereum provider request</param>
        public async UniTask<Provider> GetEthereumProvider(EthereumProviderRequest request)
        {
            return await GetOpenfortImpl().GetEthereumProvider(request);
        }

        /// <summary>
        /// Configures the embedded signer.
        /// </summary>
        /// <param name="request">Embedded signer request</param>
        public async UniTask ConfigureEmbeddedSigner(EmbeddedSignerRequest request)
        {
            await GetOpenfortImpl().ConfigureEmbeddedSigner(request);
        }

        /// <summary>
        /// Clears the underlying WebView resource cache.
        /// Android: Note that the cache is per-application, so this will clear the cache for all WebViews used.
        /// </summary>
        /// <param name="includeDiskFiles">if false, only the RAM/in-memory cache is cleared</param>
        public void ClearCache(bool includeDiskFiles)
        {
            GetOpenfortImpl().ClearCache(includeDiskFiles);
        }

        /// <summary>
        /// Clears all the underlying WebView storage currently being used by the JavaScript storage APIs.
        /// This includes Web SQL Database and the HTML5 Web Storage APIs.
        /// </summary>
        public void ClearStorage()
        {
            GetOpenfortImpl().ClearStorage();
        }

        private OpenfortImpl GetOpenfortImpl()
        {
            if (openfortImpl != null)
            {
                return openfortImpl;
            }
            throw new OpenfortException("Openfort not initialized");
        }

        private void OnDeepLinkActivated(string url)
        {
            deeplink = url;

            if (openfortImpl != null)
            {
                GetOpenfortImpl().OnDeepLinkActivated(url);
            }
        }

        private void OnOpenfortAuthEvent(OpenfortAuthEvent authEvent)
        {
            if (OnAuthEvent != null)
            {
                OnAuthEvent.Invoke(authEvent);
            }
        }
    }
}
