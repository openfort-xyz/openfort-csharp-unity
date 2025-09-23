namespace Openfort.OpenfortSDK
{
    public static class OpenfortFunction
    {
        public const string INIT = "init";

        // EMAIL METHODS
        public const string LOGIN_WITH_EMAIL_PASSWORD = "logInWithEmailPassword";
        public const string SIGNUP_WITH_EMAIL_PASSWORD = "signUpWithEmailPassword";
        public const string SIGNUP_GUEST = "signUpGuest";
        public const string LINK_EMAIL_PASSWORD = "linkEmailPassword";
        public const string UNLINK_EMAIL_PASSWORD = "unlinkEmailPassword";
        public const string REQUEST_RESET_PASSWORD = "requestResetPassword";
        public const string RESET_PASSWORD = "resetPassword";
        public const string REQUEST_EMAIL_VERIFICATION = "requestEmailVerification";
        public const string VERIFY_EMAIL = "verifyEmail";

        // OAUTH METHODS
        public const string INIT_OAUTH = "initOAuth";
        public const string INIT_LINK_OAUTH = "initLinkOAuth";
        public const string UNLINK_OAUTH = "unlinkOAuth";
        public const string POOL_OAUTH = "poolOAuth";

        // THIRD PARTY AUTH METHODS
        public const string AUTHENTICATE_WITH_THIRD_PARTY_PROVIDER = "authenticateWithThirdPartyProvider";

        // SIWE METHODS
        public const string INIT_SIWE = "initSIWE";
        public const string AUTHENTICATE_WITH_SIWE = "authenticateWithSIWE";
        public const string LINK_WALLET = "linkWallet";
        public const string UNLINK_WALLET = "unlinkWallet";

        // GENERAL AUTH METHODS
        public const string STORE_CREDENTIALS = "storeCredentials";
        public const string GET_ACCESS_TOKEN = "getAccessToken";
        public const string GET_USER = "getUser";
        public const string LOGOUT = "logout";
        public const string VALIDATE_AND_REFRESH_TOKEN = "validateAndRefreshToken";

        public const string SEND_SIGNATURE_TRANSACTION_INTENT_REQUEST = "sendSignatureTransactionIntentRequest";
        public const string SIGN_MESSAGE = "signMessage";
        public const string SIGN_TYPED_DATA = "signTypedData";
        public const string SEND_SIGNATURE_SESSION_REQUEST = "sendSignatureSessionRequest";
        public const string GET_EMBEDDED_STATE = "getEmbeddedState";
        public const string GET_ETHEREUM_PROVIDER = "getEthereumProvider";
        public const string CONFIGURE_SESSION_KEY = "configureSessionKey";
        public const string CONFIGURE_EMBEDDED_SIGNER = "configureEmbeddedSigner";

        public const string SET_THIRD_PARTY_TOKEN = "setThirdPartyToken";
    }
}
