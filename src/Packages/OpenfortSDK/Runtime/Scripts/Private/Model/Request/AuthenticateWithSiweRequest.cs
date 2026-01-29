using System;

namespace Openfort.OpenfortSDK.Model
{
    /// <summary>
    /// Request for logging in with SIWE (Sign-In With Ethereum)
    /// </summary>
    [Serializable]
    public class LoginWithSiweRequest
    {
        /// <summary>
        /// Signature of the SIWE message
        /// </summary>
        public string signature;

        /// <summary>
        /// SIWE message
        /// </summary>
        public string message;

        /// <summary>
        /// Type of the wallet client
        /// </summary>
        public string walletClientType;

        /// <summary>
        /// Type of the connector
        /// </summary>
        public string connectorType;

        /// <summary>
        /// Wallet address
        /// </summary>
        public string address;

        public LoginWithSiweRequest(string signature, string message, string walletClientType, string connectorType, string address)
        {
            this.signature = signature;
            this.message = message;
            this.walletClientType = walletClientType;
            this.connectorType = connectorType;
            this.address = address;
        }
    }

    /// <summary>
    /// Request for linking a wallet with SIWE
    /// </summary>
    [Serializable]
    public class LinkWithSiweRequest
    {
        /// <summary>
        /// Signature of the SIWE message
        /// </summary>
        public string signature;

        /// <summary>
        /// SIWE message
        /// </summary>
        public string message;

        /// <summary>
        /// Type of the wallet client
        /// </summary>
        public string walletClientType;

        /// <summary>
        /// Type of the connector
        /// </summary>
        public string connectorType;

        /// <summary>
        /// Wallet address
        /// </summary>
        public string address;

        /// <summary>
        /// Chain ID
        /// </summary>
        public int chainId;

        public LinkWithSiweRequest(string signature, string message, string walletClientType, string connectorType, string address, int chainId)
        {
            this.signature = signature;
            this.message = message;
            this.walletClientType = walletClientType;
            this.connectorType = connectorType;
            this.address = address;
            this.chainId = chainId;
        }
    }

    /// <summary>
    /// Deprecated: Use LoginWithSiweRequest instead
    /// </summary>
    [Obsolete("Use LoginWithSiweRequest instead")]
    [Serializable]
    public class AuthenticateWithSiweRequest
    {
        /// <summary>
        /// Signature of the SIWE message
        /// </summary>
        public string signature;

        /// <summary>
        /// SIWE message
        /// </summary>
        public string message;

        /// <summary>
        /// Type of the wallet client
        /// </summary>
        public string walletClientType;

        /// <summary>
        /// Type of the connector
        /// </summary>
        public string connectorType;

        /// <summary>
        /// Wallet address
        /// </summary>
        public string address;

        public AuthenticateWithSiweRequest(string signature, string message, string walletClientType, string connectorType, string address = null)
        {
            this.signature = signature;
            this.message = message;
            this.walletClientType = walletClientType;
            this.connectorType = connectorType;
            this.address = address;
        }

        /// <summary>
        /// Creates a new AuthenticateWithSiweRequest
        /// </summary>
        public static AuthenticateWithSiweRequest Create(string signature, string message, string walletClientType, string connectorType, string address = null)
        {
            return new AuthenticateWithSiweRequest(signature, message, walletClientType, connectorType, address);
        }
    }
}
