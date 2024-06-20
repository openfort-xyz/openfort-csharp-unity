using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class LinkWalletRequest
    {
        /**
        * Signature for linking the wallet
        */
        public string signature;

        /**
        * Message for linking the wallet
        */
        public string message;

        /**
        * Type of the wallet client
        */
        public string walletClientType;

        /**
        * Type of the connector
        */
        public string connectorType;

        /**
        * Authentication token for linking the wallet
        */
        public string authToken;

        public LinkWalletRequest(string signature, string message, string walletClientType, string connectorType, string authToken)
        {
            this.signature = signature;
            this.message = message;
            this.walletClientType = walletClientType;
            this.connectorType = connectorType;
            this.authToken = authToken;
        }

        /**
        * Creates a new LinkWalletRequest with the provided signature, message, walletClientType, connectorType, and authToken
        */
        public static LinkWalletRequest Create(string signature, string message, string walletClientType, string connectorType, string authToken)
        {
            return new LinkWalletRequest(signature, message, walletClientType, connectorType, authToken);
        }
    }
}
