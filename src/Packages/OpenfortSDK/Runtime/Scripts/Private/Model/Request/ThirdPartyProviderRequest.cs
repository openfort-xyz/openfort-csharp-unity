using System;
using Openfort.OpenfortSDK.Model;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class ThirdPartyProviderRequest
    {
        /**
        * Third party OAuth provider
        */
        public ThirdPartyOAuthProvider provider;

        /**
        * Token provided by the third party
        */
        public string token;

        /**
        * Type of the token
        */
        public TokenType tokenType;

        public ThirdPartyProviderRequest(ThirdPartyOAuthProvider provider, string token, TokenType tokenType)
        {
            this.provider = provider;
            this.token = token;
            this.tokenType = tokenType;
        }

        /**
        * Creates a new ThirdPartyProviderRequest with the provided provider, token, and tokenType
        */
        public static ThirdPartyProviderRequest Create(ThirdPartyOAuthProvider provider, string token, TokenType tokenType)
        {
            return new ThirdPartyProviderRequest(provider, token, tokenType);
        }
    }
}
