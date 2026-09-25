using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Openfort.OpenfortSDK.Model
{
    /// <summary>
    /// Values of TransactionResponse.Status. Terminal: Succeeded, Reverted, Failed, Expired.
    /// </summary>
    public static class TransactionStatus
    {
        public const string AwaitingSignature = "awaiting_signature";
        public const string Submitted = "submitted";
        public const string Succeeded = "succeeded";
        public const string Reverted = "reverted";
        public const string Failed = "failed";
        public const string Expired = "expired";
    }

    /// <summary>
    /// Action the caller must take before the transaction can be submitted.
    /// </summary>
    [Preserve]
    [DataContract(Name = "SignHashAction")]
    public class SignHashAction
    {
        /// <summary>
        /// Action type, currently "sign_hash".
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Hash to sign with the embedded signer.
        /// </summary>
        [DataMember(Name = "hash", EmitDefaultValue = false)]
        public string Hash { get; set; }
    }

    /// <summary>
    /// How the transaction is executed on chain. Fields depend on Type ("userOperation" or "transaction").
    /// </summary>
    [Preserve]
    [DataContract(Name = "TransactionExecution")]
    public class TransactionExecution
    {
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "entryPointVersion", EmitDefaultValue = false)]
        public string EntryPointVersion { get; set; }

        [DataMember(Name = "userOperationHash", EmitDefaultValue = false)]
        public string UserOperationHash { get; set; }

        [DataMember(Name = "userOperation", EmitDefaultValue = false)]
        public Dictionary<string, object> UserOperation { get; set; }

        [DataMember(Name = "from", EmitDefaultValue = false)]
        public string From { get; set; }

        [DataMember(Name = "to", EmitDefaultValue = false)]
        public string To { get; set; }

        [DataMember(Name = "data", EmitDefaultValue = false)]
        public string Data { get; set; }

        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        [DataMember(Name = "nonce", EmitDefaultValue = false)]
        public string Nonce { get; set; }

        [DataMember(Name = "gas", EmitDefaultValue = false)]
        public string Gas { get; set; }

        [DataMember(Name = "maxFeePerGas", EmitDefaultValue = false)]
        public string MaxFeePerGas { get; set; }

        [DataMember(Name = "maxPriorityFeePerGas", EmitDefaultValue = false)]
        public string MaxPriorityFeePerGas { get; set; }
    }

    /// <summary>
    /// Human-readable explanation of a transaction error.
    /// </summary>
    [Preserve]
    [DataContract(Name = "TransactionErrorExplanation")]
    public class TransactionErrorExplanation
    {
        [DataMember(Name = "cause", EmitDefaultValue = false)]
        public string Cause { get; set; }

        [DataMember(Name = "solution", EmitDefaultValue = false)]
        public string Solution { get; set; }
    }

    /// <summary>
    /// Error attached to a receipt when the transaction reverted or failed.
    /// </summary>
    [Preserve]
    [DataContract(Name = "TransactionError")]
    public class TransactionError
    {
        [DataMember(Name = "reason", EmitDefaultValue = false)]
        public string Reason { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "explanation", EmitDefaultValue = false)]
        public TransactionErrorExplanation Explanation { get; set; }
    }

    /// <summary>
    /// On-chain receipt of the transaction.
    /// </summary>
    [Preserve]
    [DataContract(Name = "TransactionReceipt")]
    public class TransactionReceipt
    {
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public long CreatedAt { get; set; }

        [DataMember(Name = "transactionHash", EmitDefaultValue = false)]
        public string TransactionHash { get; set; }

        [DataMember(Name = "blockNumber", EmitDefaultValue = false)]
        public long? BlockNumber { get; set; }

        [DataMember(Name = "to", EmitDefaultValue = false)]
        public string To { get; set; }

        [DataMember(Name = "gasUsed", EmitDefaultValue = false)]
        public string GasUsed { get; set; }

        [DataMember(Name = "gasFee", EmitDefaultValue = false)]
        public string GasFee { get; set; }

        [DataMember(Name = "l1GasUsed", EmitDefaultValue = false)]
        public string L1GasUsed { get; set; }

        [DataMember(Name = "l1GasFee", EmitDefaultValue = false)]
        public string L1GasFee { get; set; }

        /// <summary>
        /// Present only when the transaction was fetched with expand=logs.
        /// </summary>
        [DataMember(Name = "logs", EmitDefaultValue = false)]
        public List<Log> Logs { get; set; }

        [DataMember(Name = "error", EmitDefaultValue = false)]
        public TransactionError Error { get; set; }
    }

    /// <summary>
    /// One lifecycle event of the transaction.
    /// </summary>
    [Preserve]
    [DataContract(Name = "TransactionTimelineEntry")]
    public class TransactionTimelineEntry
    {
        [DataMember(Name = "event", EmitDefaultValue = false)]
        public string Event { get; set; }

        [DataMember(Name = "at", EmitDefaultValue = false)]
        public long? At { get; set; }
    }

    /// <summary>
    /// A /v2/transactions transaction.
    /// </summary>
    [Preserve]
    [DataContract(Name = "TransactionResponse")]
    public class TransactionResponse
    {
        /// <summary>
        /// Transaction ID (tin_...).
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Always "transaction".
        /// </summary>
        [DataMember(Name = "object", EmitDefaultValue = false)]
        public string Object { get; set; }

        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public long CreatedAt { get; set; }

        [DataMember(Name = "updatedAt", EmitDefaultValue = false)]
        public long UpdatedAt { get; set; }

        [DataMember(Name = "chainId", EmitDefaultValue = false)]
        public int ChainId { get; set; }

        /// <summary>
        /// One of awaiting_signature, submitted, succeeded, reverted, failed, expired.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }

        [DataMember(Name = "accountId", EmitDefaultValue = false)]
        public string AccountId { get; set; }

        [DataMember(Name = "walletId", EmitDefaultValue = false)]
        public string WalletId { get; set; }

        [DataMember(Name = "feeSponsorshipId", EmitDefaultValue = false)]
        public string FeeSponsorshipId { get; set; }

        [DataMember(Name = "calls", EmitDefaultValue = false)]
        public List<Interaction> Calls { get; set; }

        [DataMember(Name = "execution", EmitDefaultValue = false)]
        public TransactionExecution Execution { get; set; }

        /// <summary>
        /// Set while Status is awaiting_signature.
        /// </summary>
        [DataMember(Name = "nextAction", EmitDefaultValue = false)]
        public SignHashAction NextAction { get; set; }

        /// <summary>
        /// Set once the transaction has been mined.
        /// </summary>
        [DataMember(Name = "receipt", EmitDefaultValue = false)]
        public TransactionReceipt Receipt { get; set; }

        /// <summary>
        /// Present only when the transaction was fetched with expand=timeline.
        /// </summary>
        [DataMember(Name = "timeline", EmitDefaultValue = false)]
        public List<TransactionTimelineEntry> Timeline { get; set; }

        [DataMember(Name = "costUsd", EmitDefaultValue = false)]
        public string CostUsd { get; set; }
    }
}
