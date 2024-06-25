using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class UnlinkWalletRequest
    {
        /**
        * Address of the wallet to be unlinked
        */
        public string address;

        /**
        * Authentication token of the user
        */
        public string authToken;

        public UnlinkWalletRequest(string address, string authToken)
        {
            this.address = address;
            this.authToken = authToken;
        }

        /**
        * Creates a new UnlinkWalletRequest with the provided address and authToken
        */
        public static UnlinkWalletRequest Create(string address, string authToken)
        {
            return new UnlinkWalletRequest(address, authToken);
        }
    }
}
