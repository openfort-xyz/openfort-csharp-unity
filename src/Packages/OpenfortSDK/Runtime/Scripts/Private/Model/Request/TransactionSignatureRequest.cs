using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class TransactionSignatureRequest
    {
        /**
        * ID of the transaction (starts with tin_)
        */
        public string transactionId;

        /**
        * The nextAction.hash to sign with the embedded signer. Ignored when a signature is given.
        */
        public string hash;

        /**
        * A ready-made signature (e.g. from a session key), can be null
        */
        public string signature;

        /**
        * Resolve as soon as the transaction is broadcast instead of waiting for the receipt
        */
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
