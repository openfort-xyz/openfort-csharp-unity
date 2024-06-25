using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class LinkEmailPasswordRequest
    {
        /**
        * Email address of the user
        */
        public string email;

        /**
        * Password for the user's account
        */
        public string password;

        /**
        * authentication token
        */
        public string authToken;

        public LinkEmailPasswordRequest(string email, string password, string authToken)
        {
            this.email = email;
            this.password = password;
            this.authToken = authToken;
        }

        /**
        * Creates a new LinkEmailPasswordRequest with the provided email and password
        */
        public static LinkEmailPasswordRequest Create(string email, string password, string authToken)
        {
            return new LinkEmailPasswordRequest(email, password, authToken);
        }
    }
}
