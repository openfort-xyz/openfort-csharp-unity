using System;

namespace Openfort.OpenfortSDK.Model
{
    public enum OpenfortErrorType
    {
        INITIALIZATION_ERROR,
        AUTHENTICATION_ERROR,
        USER_REGISTRATION_ERROR,
        REFRESH_TOKEN_ERROR,
        OPERATION_NOT_SUPPORTED_ERROR,
        NOT_LOGGED_IN_ERROR,
        LOGOUT_ERROR,
        MISSING_SESSION_SIGNER_ERROR,
        MISSING_EMBEDDED_SIGNER_ERROR,
        MISSING_SIGNER_ERROR
    }

    public class OpenfortException : Exception
    {
        public Nullable<OpenfortErrorType> Type;

        public OpenfortException(string message, Nullable<OpenfortErrorType> type = null) : base(message)
        {
            this.Type = type;
        }

        /**
        * The error message for api requests via axios that fail due to network connectivity is "Network Error".
        * This isn't the most reliable way to determine connectivity but it is currently the best we have. 
        */
        public bool IsNetworkError()
        {
            return Message.EndsWith("Network Error");
        }
    }
}