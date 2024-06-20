using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class LoginEmailPasswordRequest
    {
        /**
        * Email of the user
        */
        public string email;

        /**
        * Password of the user
        */
        public string password;

        public LoginEmailPasswordRequest(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        /**
        * Creates a new LoginEmailPasswordRequest with the provided email and password
        */
        public static LoginEmailPasswordRequest Create(string email, string password)
        {
            return new LoginEmailPasswordRequest(email, password);
        }
    }
}
