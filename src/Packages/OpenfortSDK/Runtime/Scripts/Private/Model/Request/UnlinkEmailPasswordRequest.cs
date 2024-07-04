using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class UnlinkEmailPasswordRequest
    {
        /**
        * Email address of the user
        */
        public string email;

        /**
        * authentication token
        */
        public string authToken;

        public UnlinkEmailPasswordRequest(string email, string authToken)
        {
            this.email = email;
            this.authToken = authToken;
        }

        /**
        * Creates a new UnlinkEmailPasswordRequest with the provided email and password
        */
        public static UnlinkEmailPasswordRequest Create(string email, string authToken)
        {
            return new UnlinkEmailPasswordRequest(email, authToken);
        }
    }
}
