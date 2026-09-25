using System;

namespace Openfort.OpenfortSDK.Model
{
    /// <summary>
    /// Request to sign and submit a transaction created with POST /v2/transactions.
    /// </summary>
    [Serializable]
    public class TransactionSignatureRequest
    {
        /// <summary>
        /// ID of the transaction (tin_...).
        /// </summary>
        public string transactionId;

        /// <summary>
        /// Hash from nextAction.hash. The SDK signs it with the embedded signer when signature is null.
        /// </summary>
        public string hash;

        /// <summary>
        /// Ready-made signature (e.g. from a session key). Optional.
        /// </summary>
        public string signature;

        /// <summary>
        /// Resolve at broadcast instead of waiting for the receipt. Optional.
        /// </summary>
        public bool optimistic;

        public TransactionSignatureRequest(string transactionId, string hash = null, string signature = null, bool optimistic = false)
        {
            this.transactionId = transactionId;
            this.hash = hash;
            this.signature = signature;
            this.optimistic = optimistic;
        }
    }
}
