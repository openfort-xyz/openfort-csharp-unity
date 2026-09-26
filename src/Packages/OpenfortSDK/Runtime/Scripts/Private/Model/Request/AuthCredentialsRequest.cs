using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class AuthCredentialsRequest
    {
        /**
        * User identifier (the id returned in the user object, e.g. "pla_...")
        */
        public string userId;

        /**
        * Access token for the user session
        */
        public string token;

        public AuthCredentialsRequest(string userId, string token)
        {
            this.userId = userId;
            this.token = token;
        }

        [Obsolete("Use AuthCredentialsRequest(userId, token). refreshToken is ignored.")]
        public AuthCredentialsRequest(string player, string accessToken, string refreshToken)
            : this(player, accessToken)
        {
        }

        /**
        * Creates a new AuthCredentialsRequest with the provided userId and access token
        */
        public static AuthCredentialsRequest Create(string userId, string token)
        {
            return new AuthCredentialsRequest(userId, token);
        }

        [Obsolete("Use Create(userId, token). refreshToken is ignored.")]
        public static AuthCredentialsRequest Create(string player, string accessToken, string refreshToken)
        {
            return new AuthCredentialsRequest(player, accessToken);
        }
    }
}
