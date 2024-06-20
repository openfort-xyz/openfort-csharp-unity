using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class SignatureTransactionIntentRequest
    {
        /**
        * ID of the transaction intent
        */
        public string transactionIntentId;

        /**
        * Hash of the user operation, can be null
        */
        public string userOperationHash;

        /**
        * Signature, can be null
        */
        public string signature;
        /**
        * Optimistic, can be null
        */
        public bool optimistic;

        public SignatureTransactionIntentRequest(string transactionIntentId, string userOperationHash = null, string signature = null, bool optimistic = false)
        {
            this.transactionIntentId = transactionIntentId;
            this.userOperationHash = userOperationHash;
            this.signature = signature;
            this.optimistic = optimistic;
        }

        /**
        * Creates a new SignatureTransactionIntentRequest with the provided transactionIntentId, userOperationHash, and signature
        */
        public static SignatureTransactionIntentRequest Create(string transactionIntentId, string userOperationHash = null, string signature = null, bool optimistic = false)
        {
            return new SignatureTransactionIntentRequest(transactionIntentId, userOperationHash, signature, optimistic);
        }
    }
}
