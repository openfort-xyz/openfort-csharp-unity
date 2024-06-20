using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class InitSiweRequest
    {
        /**
        * Address for the SIWE request
        */
        public string address;

        public InitSiweRequest(string address)
        {
            this.address = address;
        }

        /**
        * Creates a new InitSiweRequest with the provided address
        */
        public static InitSiweRequest Create(string address)
        {
            return new InitSiweRequest(address);
        }
    }
}
