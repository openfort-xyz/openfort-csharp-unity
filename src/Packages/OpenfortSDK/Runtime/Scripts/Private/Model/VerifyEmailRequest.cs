using System;
using System.Runtime.Serialization;

namespace Openfort.OpenfortSDK.Model
{
    /// <summary>
    /// Request to verify email
    /// </summary>
    [Serializable]
    [DataContract(Name = "VerifyEmailRequest")]
    public class VerifyEmailRequest
    {
        /// <summary>
        /// The verification token from the email
        /// </summary>
        [DataMember(Name = "token", IsRequired = true, EmitDefaultValue = true)]
        public string token;

        /// <summary>
        /// Optional callback URL after verification
        /// </summary>
        [DataMember(Name = "callbackURL", EmitDefaultValue = false)]
        public string callbackURL;

        public VerifyEmailRequest(string token, string callbackURL = null)
        {
            this.token = token;
            this.callbackURL = callbackURL;
        }

        /// <summary>
        /// Creates a new VerifyEmailRequest
        /// </summary>
        public static VerifyEmailRequest Create(string token, string callbackURL = null)
        {
            return new VerifyEmailRequest(token, callbackURL);
        }
    }
}
