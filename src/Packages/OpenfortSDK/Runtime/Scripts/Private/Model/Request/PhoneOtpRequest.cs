using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class PhoneOtpRequest
    {
        /// <summary>
        /// Phone number to send OTP to
        /// </summary>
        public string phoneNumber;

        public PhoneOtpRequest(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        /// <summary>
        /// Creates a new PhoneOtpRequest with the provided phone number
        /// </summary>
        public static PhoneOtpRequest Create(string phoneNumber)
        {
            return new PhoneOtpRequest(phoneNumber);
        }
    }
}
