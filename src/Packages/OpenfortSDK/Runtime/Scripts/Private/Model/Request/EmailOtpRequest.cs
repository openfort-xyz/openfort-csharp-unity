using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class EmailOtpRequest
    {
        /// <summary>
        /// Email address to send OTP to
        /// </summary>
        public string email;

        public EmailOtpRequest(string email)
        {
            this.email = email;
        }

        /// <summary>
        /// Creates a new EmailOtpRequest with the provided email
        /// </summary>
        public static EmailOtpRequest Create(string email)
        {
            return new EmailOtpRequest(email);
        }
    }
}
