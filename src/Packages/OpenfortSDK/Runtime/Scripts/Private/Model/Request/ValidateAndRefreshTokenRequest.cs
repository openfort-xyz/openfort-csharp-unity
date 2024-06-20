using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class ValidateAndRefreshTokenRequest
    {
        /**
        * Force refresh of the access token
        */
        public bool forceRefresh = false;

        public ValidateAndRefreshTokenRequest(bool? forceRefresh = null)
        {
            this.forceRefresh = forceRefresh ?? false;
        }

        /**
        * Creates a new ValidateAndRefreshTokenRequest with the provided forceRefresh
        */
        public static ValidateAndRefreshTokenRequest Create(bool? forceRefresh = null)
        {
            return new ValidateAndRefreshTokenRequest(forceRefresh);
        }
    }
}
