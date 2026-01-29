using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class SignupEmailPasswordRequest
    {
        /// <summary>
        /// Email of the user
        /// </summary>
        public string email;

        /// <summary>
        /// Password of the user
        /// </summary>
        public string password;

        /// <summary>
        /// Name of the user
        /// </summary>
        public string name;

        /// <summary>
        /// Callback URL for email verification
        /// </summary>
        public string callbackURL;

        public SignupEmailPasswordRequest(string email, string password, string name = null, string callbackURL = null)
        {
            this.email = email;
            this.password = password;
            this.name = name;
            this.callbackURL = callbackURL;
        }

        /// <summary>
        /// Creates a new SignupEmailPasswordRequest with the provided parameters
        /// </summary>
        public static SignupEmailPasswordRequest Create(string email, string password, string name = null, string callbackURL = null)
        {
            return new SignupEmailPasswordRequest(email, password, name, callbackURL);
        }
    }

    /// <summary>
    /// Deprecated: Use direct parameters in SignupEmailPasswordRequest instead
    /// </summary>
    [Obsolete("Use direct parameters in SignupEmailPasswordRequest instead")]
    [Serializable]
    public class Options
    {
        /// <summary>
        /// Data containing additional information
        /// </summary>
        public Data data;

        public Options(Data data)
        {
            this.data = data;
        }
    }

    /// <summary>
    /// Deprecated: Use direct parameters in SignupEmailPasswordRequest instead
    /// </summary>
    [Obsolete("Use direct parameters in SignupEmailPasswordRequest instead")]
    [Serializable]
    public class Data
    {
        /// <summary>
        /// Name of the user
        /// </summary>
        public string name;

        public Data(string name)
        {
            this.name = name;
        }
    }
}
