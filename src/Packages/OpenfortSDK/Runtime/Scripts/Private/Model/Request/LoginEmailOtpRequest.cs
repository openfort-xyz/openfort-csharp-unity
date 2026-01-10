using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class LoginEmailOtpRequest
    {
        /// <summary>
        /// Email address
        /// </summary>
        public string email;

        /// <summary>
        /// One-time password received via email
        /// </summary>
        public string otp;

        public LoginEmailOtpRequest(string email, string otp)
        {
            this.email = email;
            this.otp = otp;
        }

        /// <summary>
        /// Creates a new LoginEmailOtpRequest with the provided email and OTP
        /// </summary>
        public static LoginEmailOtpRequest Create(string email, string otp)
        {
            return new LoginEmailOtpRequest(email, otp);
        }
    }
}
