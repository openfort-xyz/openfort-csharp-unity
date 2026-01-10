using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class LinkSiweRequest
    {
        /// <summary>
        /// Wallet address for SIWE linking
        /// </summary>
        public string address;

        public LinkSiweRequest(string address)
        {
            this.address = address;
        }

        /// <summary>
        /// Creates a new LinkSiweRequest with the provided address
        /// </summary>
        public static LinkSiweRequest Create(string address)
        {
            return new LinkSiweRequest(address);
        }
    }
}
