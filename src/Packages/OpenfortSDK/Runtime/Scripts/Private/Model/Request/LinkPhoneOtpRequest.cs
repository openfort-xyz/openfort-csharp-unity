using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class LinkPhoneOtpRequest
    {
        /// <summary>
        /// Phone number to link
        /// </summary>
        public string phoneNumber;

        /// <summary>
        /// One-time password received via SMS
        /// </summary>
        public string otp;

        public LinkPhoneOtpRequest(string phoneNumber, string otp)
        {
            this.phoneNumber = phoneNumber;
            this.otp = otp;
        }

        /// <summary>
        /// Creates a new LinkPhoneOtpRequest with the provided phone number and OTP
        /// </summary>
        public static LinkPhoneOtpRequest Create(string phoneNumber, string otp)
        {
            return new LinkPhoneOtpRequest(phoneNumber, otp);
        }
    }
}
