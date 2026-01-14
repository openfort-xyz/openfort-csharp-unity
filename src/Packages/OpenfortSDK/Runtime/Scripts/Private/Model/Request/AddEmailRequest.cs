using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class AddEmailRequest
    {
        /// <summary>
        /// Email address to add to the account
        /// </summary>
        public string email;

        /// <summary>
        /// Callback URL for email verification
        /// </summary>
        public string callbackURL;

        public AddEmailRequest(string email, string callbackURL = null)
        {
            this.email = email;
            this.callbackURL = callbackURL;
        }

        /// <summary>
        /// Creates a new AddEmailRequest with the provided email and callback URL
        /// </summary>
        public static AddEmailRequest Create(string email, string callbackURL = null)
        {
            return new AddEmailRequest(email, callbackURL);
        }
    }
}
