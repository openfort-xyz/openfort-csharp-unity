using System;

namespace Openfort.OpenfortSDK.Model
{
    /// <summary>
    /// Deprecated: Use LinkWithSiweRequest instead.
    /// This class is kept for backward compatibility but LinkWallet has been replaced by LinkWithSiwe.
    /// </summary>
    [Obsolete("Use LinkWithSiweRequest instead. The LinkWallet method has been replaced by LinkWithSiwe.")]
    [Serializable]
    public class LinkWalletRequest
    {
        /// <summary>
        /// Signature for linking the wallet
        /// </summary>
        public string signature;

        /// <summary>
        /// Message for linking the wallet
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
        /// Authentication token for linking the wallet (deprecated)
        /// </summary>
        public string authToken;

        public LinkWalletRequest(string signature, string message, string walletClientType, string connectorType, string authToken)
        {
            this.signature = signature;
            this.message = message;
            this.walletClientType = walletClientType;
            this.connectorType = connectorType;
            this.authToken = authToken;
        }

        /// <summary>
        /// Creates a new LinkWalletRequest with the provided parameters
        /// </summary>
        [Obsolete("Use LinkWithSiweRequest instead")]
        public static LinkWalletRequest Create(string signature, string message, string walletClientType, string connectorType, string authToken)
        {
            return new LinkWalletRequest(signature, message, walletClientType, connectorType, authToken);
        }
    }
}
