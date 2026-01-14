using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class LoginPhoneOtpRequest
    {
        /// <summary>
        /// Phone number
        /// </summary>
        public string phoneNumber;

        /// <summary>
        /// One-time password received via SMS
        /// </summary>
        public string otp;

        public LoginPhoneOtpRequest(string phoneNumber, string otp)
        {
            this.phoneNumber = phoneNumber;
            this.otp = otp;
        }

        /// <summary>
        /// Creates a new LoginPhoneOtpRequest with the provided phone number and OTP
        /// </summary>
        public static LoginPhoneOtpRequest Create(string phoneNumber, string otp)
        {
            return new LoginPhoneOtpRequest(phoneNumber, otp);
        }
    }
}
