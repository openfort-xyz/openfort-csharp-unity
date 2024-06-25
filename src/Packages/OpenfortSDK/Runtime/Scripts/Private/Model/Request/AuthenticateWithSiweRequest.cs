using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class AuthenticateWithSiweRequest
    {
        /**
        * Signature of the SIWE message
        */
        public string signature;

        /**
        * SIWE message
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

        public AuthenticateWithSiweRequest(string signature, string message, string walletClientType, string connectorType)
        {
            this.signature = signature;
            this.message = message;
            this.walletClientType = walletClientType;
            this.connectorType = connectorType;
        }

        /**
        * Creates a new AuthenticateWithSiweRequest with the provided signature, message, walletClientType, and connectorType
        */
        public static AuthenticateWithSiweRequest Create(string signature, string message, string walletClientType, string connectorType)
        {
            return new AuthenticateWithSiweRequest(signature, message, walletClientType, connectorType);
        }
    }
}
