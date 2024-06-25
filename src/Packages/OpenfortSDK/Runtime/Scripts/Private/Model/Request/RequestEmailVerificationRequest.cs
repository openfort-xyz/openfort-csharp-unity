using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class RequestEmailVerificationRequest
    {
        /**
        * Email address of the user
        */
        public string email;

        /**
        * Redirect URL after the action is performed
        */
        public string redirectUrl;

        public RequestEmailVerificationRequest(string email, string redirectUrl)
        {
            this.email = email;
            this.redirectUrl = redirectUrl;
        }

        /**
        * Creates a new RequestEmailVerificationRequest with the provided email and redirectUrl
        */
        public static RequestEmailVerificationRequest Create(string email, string redirectUrl)
        {
            return new RequestEmailVerificationRequest(email, redirectUrl);
        }
    }
}
