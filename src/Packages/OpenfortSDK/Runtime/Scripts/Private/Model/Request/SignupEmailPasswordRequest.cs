using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class SignupEmailPasswordRequest
    {
        /**
        * Email of the user
        */
        public string email;

        /**
        * Password of the user
        */
        public string password;

        /**
        * Optional data for the signup request
        */
        public Options options;

        public SignupEmailPasswordRequest(string email, string password, Options options = null)
        {
            this.email = email;
            this.password = password;
            this.options = options;
        }

        /**
        * Creates a new SignupEmailPasswordRequest with the provided email, password, and options
        */
        public static SignupEmailPasswordRequest Create(string email, string password, Options options = null)
        {
            return new SignupEmailPasswordRequest(email, password, options);
        }
    }

    [Serializable]
    public class Options
    {
        /**
        * Data containing additional information
        */
        public Data data;

        public Options(Data data)
        {
            this.data = data;
        }
    }

    [Serializable]
    public class Data
    {
        /**
        * Name of the user
        */
        public string name;

        public Data(string name)
        {
            this.name = name;
        }
    }
}
