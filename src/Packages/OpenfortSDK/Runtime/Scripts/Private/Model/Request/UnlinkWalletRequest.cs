using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class UnlinkWalletRequest
    {
        /// <summary>
        /// Address of the wallet to be unlinked
        /// </summary>
        public string address;

        /// <summary>
        /// Chain ID of the wallet
        /// </summary>
        public int chainId;

        public UnlinkWalletRequest(string address, int chainId)
        {
            this.address = address;
            this.chainId = chainId;
        }

        /// <summary>
        /// Creates a new UnlinkWalletRequest with the provided address and chainId
        /// </summary>
        public static UnlinkWalletRequest Create(string address, int chainId)
        {
            return new UnlinkWalletRequest(address, chainId);
        }
    }
}
