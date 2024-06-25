using System;
using System.Collections.Generic;
using Openfort.OpenfortSDK.Model;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class InitLinkOAuthRequest
    {
        /**
        * OAuth provider
        */
        public OAuthProvider provider;

        /**
        * Authentication token
        */
        public string authToken;

        /**
        * Options for initializing OAuth
        */
        public OAuthInitRequestOptions options;

        public InitLinkOAuthRequest(OAuthProvider provider, string authToken, OAuthInitRequestOptions options = null)
        {
            this.provider = provider;
            this.authToken = authToken;
            this.options = options;
        }

        /**
        * Creates a new InitLinkOAuthRequest with the provided provider, authToken, and options
        */
        public static InitLinkOAuthRequest Create(OAuthProvider provider, string authToken, OAuthInitRequestOptions options = null)
        {
            return new InitLinkOAuthRequest(provider, authToken, options);
        }
    }
}
