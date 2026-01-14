using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class LoginIdTokenRequest
    {
        /// <summary>
        /// Identity provider (e.g., "google", "facebook", "apple")
        /// </summary>
        public string provider;

        /// <summary>
        /// ID token from the identity provider
        /// </summary>
        public string token;

        public LoginIdTokenRequest(string provider, string token)
        {
            this.provider = provider;
            this.token = token;
        }

        /// <summary>
        /// Creates a new LoginIdTokenRequest with the provided provider and token
        /// </summary>
        public static LoginIdTokenRequest Create(string provider, string token)
        {
            return new LoginIdTokenRequest(provider, token);
        }
    }
}
