namespace Openfort.OpenfortSDK
{
    public static class OpenfortFunction
    {
        public const string INIT = "init";

        // EMAIL METHODS
        public const string LOGIN_WITH_EMAIL_PASSWORD = "logInWithEmailPassword";
        public const string SIGNUP_WITH_EMAIL_PASSWORD = "signUpWithEmailPassword";
        public const string SIGNUP_GUEST = "signUpGuest";
        public const string REQUEST_RESET_PASSWORD = "requestResetPassword";
        public const string RESET_PASSWORD = "resetPassword";
        public const string REQUEST_EMAIL_VERIFICATION = "requestEmailVerification";
        public const string VERIFY_EMAIL = "verifyEmail";

        // OAUTH METHODS
        public const string INIT_OAUTH = "initOAuth";
        public const string INIT_LINK_OAUTH = "initLinkOAuth";
        public const string UNLINK_OAUTH = "unlinkOAuth";

        // SIWE METHODS
        public const string INIT_SIWE = "initSiwe";
        public const string LOGIN_WITH_SIWE = "loginWithSiwe";
        public const string INIT_LINK_SIWE = "initLinkSiwe";
        public const string LINK_WITH_SIWE = "linkWithSiwe";
        public const string UNLINK_WALLET = "unlinkWallet";

        // EMAIL OTP METHODS
        public const string REQUEST_EMAIL_OTP = "requestEmailOtp";
        public const string LOGIN_WITH_EMAIL_OTP = "logInWithEmailOtp";
        public const string VERIFY_EMAIL_OTP = "verifyEmailOtp";
        public const string ADD_EMAIL = "addEmail";

        // PHONE OTP METHODS
        public const string REQUEST_PHONE_OTP = "requestPhoneOtp";
        public const string LOGIN_WITH_PHONE_OTP = "logInWithPhoneOtp";
        public const string LINK_PHONE_OTP = "linkPhoneOtp";

        // ID TOKEN METHODS
        public const string LOGIN_WITH_ID_TOKEN = "logInWithIdToken";

        // GENERAL AUTH METHODS
        public const string STORE_CREDENTIALS = "storeCredentials";
        public const string GET_ACCESS_TOKEN = "getAccessToken";
        public const string GET_USER = "getUser";
        public const string LOGOUT = "logout";
        public const string VALIDATE_AND_REFRESH_TOKEN = "validateAndRefreshToken";

        // TRANSACTION METHODS
        public const string SEND_SIGNATURE_TRANSACTION_INTENT_REQUEST = "sendSignatureTransactionIntentRequest";
        public const string SIGN_MESSAGE = "signMessage";
        public const string SIGN_TYPED_DATA = "signTypedData";

        // EMBEDDED WALLET METHODS
        public const string GET_EMBEDDED_STATE = "getEmbeddedState";
        public const string GET_ETHEREUM_PROVIDER = "getEthereumProvider";
        public const string CONFIGURE_EMBEDDED_WALLET = "configureEmbeddedWallet";
        public const string CREATE_EMBEDDED_WALLET = "createEmbeddedWallet";
        public const string RECOVER_EMBEDDED_WALLET = "recoverEmbeddedWallet";
        public const string LIST_WALLETS = "listWallets";
        public const string GET_WALLET = "getWallet";

        public const string SET_THIRD_PARTY_TOKEN = "setThirdPartyToken";
    }
}
