using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class VerifyEmailOtpRequest
    {
        /// <summary>
        /// Email address to verify
        /// </summary>
        public string email;

        /// <summary>
        /// One-time password received via email
        /// </summary>
        public string otp;

        public VerifyEmailOtpRequest(string email, string otp)
        {
            this.email = email;
            this.otp = otp;
        }

        /// <summary>
        /// Creates a new VerifyEmailOtpRequest with the provided email and OTP
        /// </summary>
        public static VerifyEmailOtpRequest Create(string email, string otp)
        {
            return new VerifyEmailOtpRequest(email, otp);
        }
    }
}
