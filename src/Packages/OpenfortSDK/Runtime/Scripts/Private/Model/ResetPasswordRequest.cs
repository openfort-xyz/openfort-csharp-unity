using System;
using System.Runtime.Serialization;

namespace Openfort.OpenfortSDK.Model
{
    /// <summary>
    /// Request to reset password
    /// </summary>
    [Serializable]
    [DataContract(Name = "ResetPasswordRequest")]
    public class ResetPasswordRequest
    {
        /// <summary>
        /// The new password
        /// </summary>
        [DataMember(Name = "password", IsRequired = true, EmitDefaultValue = true)]
        public string password;

        /// <summary>
        /// The reset token from the email
        /// </summary>
        [DataMember(Name = "token", IsRequired = true, EmitDefaultValue = true)]
        public string token;

        public ResetPasswordRequest(string password, string token)
        {
            this.password = password;
            this.token = token;
        }

        /// <summary>
        /// Creates a new ResetPasswordRequest
        /// </summary>
        public static ResetPasswordRequest Create(string password, string token)
        {
            return new ResetPasswordRequest(password, token);
        }
    }
}
