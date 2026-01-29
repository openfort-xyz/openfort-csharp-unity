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
using System.Threading.Tasks;

namespace Openfort.OpenfortSDK
{

    public class OpenfortSDK
    {
        private const string TAG = "[OpenfortSDK]";

        public static OpenfortSDK Instance { get; private set; }

        private IWebBrowserClient webBrowserClient;
        private static bool readySignalReceived = false;
        private OpenfortImpl openfortImpl = null;

        public event OnAuthEventDelegate OnAuthEvent;

        private OpenfortSDK()
        {
            Application.quitting += OnQuit;
        }

        /// <summary>
        /// Initializes OpenfortSDK.
        /// </summary>
        /// <param name="publishableKey">Openfort publishable key</param>
        /// <param name="shieldPublishableKey">Shield publishable key</param>
        /// <param name="shieldDebug">Enable shield debug mode</param>
        /// <param name="backendUrl">Backend URL</param>
        /// <param name="iframeUrl">Iframe URL</param>
        /// <param name="shieldUrl">Shield URL</param>
        /// <param name="engineStartupTimeoutMs">(Windows only) Timeout time for waiting for the engine to start (in milliseconds)</param>
        public static UniTask<OpenfortSDK> Init(
            string publishableKey
            , string shieldPublishableKey = null
            , bool shieldDebug = false
            , string backendUrl = "https://api.openfort.io"
            , string iframeUrl = "https://embed.openfort.io"
            , string shieldUrl = "https://shield.openfort.io"
            , string thirdPartyProvider = null
            , Func<string, Task<string>> getThirdPartyToken = null
#if OPENFORT_USE_UWB
            , int engineStartupTimeoutMs = 4000
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
                            await Instance.GetOpenfortImpl().Init(publishableKey,
                                shieldPublishableKey,
                                shieldDebug,
                                backendUrl,
                                iframeUrl,
                                shieldUrl,
                                thirdPartyProvider,
                                getThirdPartyToken);

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
        /// Logs the user into Openfort via a guest account.
        /// </summary>
        public async UniTask<AuthResponse> SignUpGuest()
        {
            return await GetOpenfortImpl().SignUpGuest();
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
        /// Signs up a new user via email and password.
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="password">User password</param>
        /// <param name="name">User name (optional)</param>
        /// <param name="callbackURL">Callback URL for email verification (optional)</param>
        public async UniTask<AuthResponse> SignUpWithEmailPassword(string email, string password, string name = null, string callbackURL = null)
        {
            return await GetOpenfortImpl().SignUpWithEmailPassword(email, password, name, callbackURL);
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
        public async UniTask ResetPassword(ResetPasswordRequest request)
        {
            await GetOpenfortImpl().ResetPassword(request);
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
        public async UniTask VerifyEmail(VerifyEmailRequest request)
        {
            await GetOpenfortImpl().VerifyEmail(request);
        }

        // OAuth Methods

        /// <summary>
        /// Initializes OAuth authentication flow.
        /// </summary>
        /// <param name="provider">The OAuth provider to use</param>
        /// <param name="redirectTo">The URL to redirect to after authentication</param>
        /// <param name="options">Optional OAuth options</param>
        /// <returns>The OAuth URL to redirect the user to</returns>
        public async UniTask<string> InitOAuth(OAuthProvider provider, string redirectTo, InitializeOAuthOptions options = null)
        {
            return await GetOpenfortImpl().InitOAuth(new InitOAuthRequest(provider, redirectTo, options));
        }

        /// <summary>
        /// Initializes OAuth linking flow for an authenticated user.
        /// </summary>
        /// <param name="provider">The OAuth provider to link</param>
        /// <param name="redirectTo">The URL to redirect to after linking</param>
        /// <param name="options">Optional OAuth options</param>
        /// <returns>The OAuth URL to redirect the user to</returns>
        public async UniTask<string> InitLinkOAuth(OAuthProvider provider, string redirectTo, InitializeOAuthOptions options = null)
        {
            return await GetOpenfortImpl().InitLinkOAuth(new InitOAuthRequest(provider, redirectTo, options));
        }

        /// <summary>
        /// Unlinks an OAuth provider from the user account.
        /// </summary>
        /// <param name="provider">The OAuth provider to unlink</param>
        public async UniTask<User> UnlinkOAuth(OAuthProvider provider)
        {
            return await GetOpenfortImpl().UnlinkOAuth(new UnlinkOAuthRequest(provider));
        }

        // SIWE Methods

        /// <summary>
        /// Initializes Sign-In with Ethereum (SIWE).
        /// </summary>
        /// <param name="request">SIWE initialization request</param>
        public async UniTask<InitSiweResponse> InitSiwe(InitSiweRequest request)
        {
            return await GetOpenfortImpl().InitSiwe(request);
        }

        /// <summary>
        /// Logs in the user with SIWE (Sign-In With Ethereum).
        /// </summary>
        /// <param name="request">SIWE login request</param>
        public async UniTask<AuthResponse> LoginWithSiwe(LoginWithSiweRequest request)
        {
            return await GetOpenfortImpl().LoginWithSiwe(request);
        }

        /// <summary>
        /// Authenticates the user with SIWE.
        /// </summary>
        /// <param name="request">SIWE authentication request</param>
        [Obsolete("Use LoginWithSiwe instead")]
        public async UniTask<AuthResponse> AuthenticateWithSiwe(AuthenticateWithSiweRequest request)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            return await GetOpenfortImpl().AuthenticateWithSiwe(request);
#pragma warning restore CS0618
        }

        /// <summary>
        /// Initializes SIWE linking for an authenticated user.
        /// </summary>
        /// <param name="request">Init link SIWE request containing the wallet address</param>
        public async UniTask<InitSiweResponse> InitLinkSiwe(InitLinkSiweRequest request)
        {
            return await GetOpenfortImpl().InitLinkSiwe(request);
        }

        /// <summary>
        /// Links a SIWE wallet to the user account.
        /// </summary>
        /// <param name="request">Link SIWE request containing the wallet address</param>
        [Obsolete("Use InitLinkSiwe instead")]
        public async UniTask<InitSiweResponse> LinkSiwe(LinkSiweRequest request)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            return await GetOpenfortImpl().LinkSiwe(request);
#pragma warning restore CS0618
        }

        /// <summary>
        /// Links a wallet to the user account using SIWE.
        /// </summary>
        /// <param name="request">Link with SIWE request</param>
        public async UniTask<User> LinkWithSiwe(LinkWithSiweRequest request)
        {
            return await GetOpenfortImpl().LinkWithSiwe(request);
        }

        /// <summary>
        /// Unlinks a wallet from the user account.
        /// </summary>
        /// <param name="request">Unlink wallet request</param>
        public async UniTask<User> UnlinkWallet(UnlinkWalletRequest request)
        {
            return await GetOpenfortImpl().UnlinkWallet(request);
        }

        /// <summary>
        /// Requests an OTP to be sent to the specified email address.
        /// </summary>
        /// <param name="email">Email address to send OTP to</param>
        public async UniTask RequestEmailOtp(string email)
        {
            await GetOpenfortImpl().RequestEmailOtp(new EmailOtpRequest(email));
        }

        /// <summary>
        /// Logs in the user using email and OTP.
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="otp">One-time password received via email</param>
        public async UniTask<AuthResponse> LogInWithEmailOtp(string email, string otp)
        {
            return await GetOpenfortImpl().LogInWithEmailOtp(new LoginEmailOtpRequest(email, otp));
        }

        /// <summary>
        /// Verifies the user's email using OTP.
        /// </summary>
        /// <param name="email">Email address to verify</param>
        /// <param name="otp">One-time password received via email</param>
        public async UniTask VerifyEmailOtp(string email, string otp)
        {
            await GetOpenfortImpl().VerifyEmailOtp(new VerifyEmailOtpRequest(email, otp));
        }

        /// <summary>
        /// Adds an additional email to the user account.
        /// </summary>
        /// <param name="request">Add email request</param>
        public async UniTask<User> AddEmail(AddEmailRequest request)
        {
            return await GetOpenfortImpl().AddEmail(request);
        }

        /// <summary>
        /// Requests an OTP to be sent to the specified phone number.
        /// </summary>
        /// <param name="phoneNumber">Phone number to send OTP to</param>
        public async UniTask RequestPhoneOtp(string phoneNumber)
        {
            await GetOpenfortImpl().RequestPhoneOtp(new PhoneOtpRequest(phoneNumber));
        }

        /// <summary>
        /// Logs in the user using phone number and OTP.
        /// </summary>
        /// <param name="phoneNumber">User phone number</param>
        /// <param name="otp">One-time password received via SMS</param>
        public async UniTask<AuthResponse> LogInWithPhoneOtp(string phoneNumber, string otp)
        {
            return await GetOpenfortImpl().LogInWithPhoneOtp(new LoginPhoneOtpRequest(phoneNumber, otp));
        }

        /// <summary>
        /// Links a phone number to the user account using OTP.
        /// </summary>
        /// <param name="request">Link phone OTP request</param>
        public async UniTask<AuthResponse> LinkPhoneOtp(LinkPhoneOtpRequest request)
        {
            return await GetOpenfortImpl().LinkPhoneOtp(request);
        }

        /// <summary>
        /// Logs in the user using an ID token from an external identity provider.
        /// </summary>
        /// <param name="provider">Identity provider (e.g., "google", "facebook", "apple")</param>
        /// <param name="token">ID token from the identity provider</param>
        public async UniTask<AuthResponse> LogInWithIdToken(string provider, string token)
        {
            return await GetOpenfortImpl().LogInWithIdToken(new LoginIdTokenRequest(provider, token));
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
        public async UniTask<User> GetUser()
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
        /// <param name="forceRefresh">Whether to force refresh the token</param>
        public async UniTask ValidateAndRefreshToken(bool forceRefresh = false)
        {
            await GetOpenfortImpl().ValidateAndRefreshToken(new ValidateAndRefreshTokenRequest(forceRefresh));
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

        public async UniTask<EmbeddedAccount> CreateEmbeddedWallet(CreateEmbeddedWalletRequest request)
        {
            return await GetOpenfortImpl().CreateEmbeddedWallet(request);
        }

        public async UniTask<EmbeddedAccount> RecoverEmbeddedWallet(RecoverEmbeddedWalletRequest request)
        {
            return await GetOpenfortImpl().RecoverEmbeddedWallet(request);
        }

        public async UniTask<EmbeddedAccount> GetEmbeddedWallet()
        {
            return await GetOpenfortImpl().GetWallet();
        }

        public async UniTask<EmbeddedAccount[]> ListWallets(ListWalletsRequest request)
        {
            return await GetOpenfortImpl().ListWallets(request);
        }

        /// <summary>
        /// Configures the embedded wallet.
        /// </summary>
        /// <param name="request">Embedded wallet configuration request</param>
        public async UniTask ConfigureEmbeddedWallet(ConfigureEmbeddedWalletRequest request)
        {
            await GetOpenfortImpl().ConfigureEmbeddedWallet(request);
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

        private void OnOpenfortAuthEvent(OpenfortAuthEvent authEvent)
        {
            if (OnAuthEvent != null)
            {
                OnAuthEvent.Invoke(authEvent);
            }
        }
    }
}
