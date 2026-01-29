using System;

namespace Openfort.OpenfortSDK.Model
{
    /// <summary>
    /// Request for initializing SIWE linking (initLinkSiwe)
    /// </summary>
    [Serializable]
    public class InitLinkSiweRequest
    {
        /// <summary>
        /// Wallet address for SIWE linking
        /// </summary>
        public string address;

        public InitLinkSiweRequest(string address)
        {
            this.address = address;
        }
    }

    /// <summary>
    /// Deprecated: Use InitLinkSiweRequest instead
    /// </summary>
    [Obsolete("Use InitLinkSiweRequest instead")]
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
