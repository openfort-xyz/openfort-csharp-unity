using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class AuthCredentialsRequest
    {
        /**
        * Player identifier
        */
        public string player;

        /**
        * Access token for authentication
        */
        public string accessToken;

        /**
        * Refresh token for authentication
        */
        public string refreshToken;

        public AuthCredentialsRequest(string player, string accessToken, string refreshToken)
        {
            this.player = player;
            this.accessToken = accessToken;
            this.refreshToken = refreshToken;
        }

        /**
        * Creates a new AuthCredentialsRequest with the provided player, accessToken, and refreshToken
        */
        public static AuthCredentialsRequest Create(string player, string accessToken, string refreshToken)
        {
            return new AuthCredentialsRequest(player, accessToken, refreshToken);
        }
    }
}
