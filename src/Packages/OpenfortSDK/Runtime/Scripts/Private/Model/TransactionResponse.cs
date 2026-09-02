using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Openfort.OpenfortSDK.Model
{
    /// <summary>
    /// A transaction returned by the /v2/transactions endpoints.
    /// Poll until <see cref="Status"/> is terminal (succeeded, reverted or failed).
    /// </summary>
    public class TransactionResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("createdAt")]
        public long CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public long UpdatedAt { get; set; }

        [JsonProperty("chainId")]
        public int ChainId { get; set; }

        /// <summary>One of the <see cref="TransactionStatus"/> values.</summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>ID of the account that executes the transaction (starts with acc_).</summary>
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        /// <summary>ID of the wallet that owns the account (starts with pla_). Absent for backend wallets.</summary>
        [JsonProperty("walletId")]
        public string WalletId { get; set; }

        /// <summary>ID of the fee sponsorship paying for gas (starts with pol_). Absent when the account pays its own gas.</summary>
        [JsonProperty("feeSponsorshipId")]
        public string FeeSponsorshipId { get; set; }

        [JsonProperty("calls")]
        public List<TransactionCall> Calls { get; set; }

        [JsonProperty("execution")]
        public TransactionExecution Execution { get; set; }

        /// <summary>Present while <see cref="Status"/> is awaiting_signature.</summary>
        [JsonProperty("nextAction")]
        public SignHashAction NextAction { get; set; }

        /// <summary>Present once the transaction reached a terminal status.</summary>
        [JsonProperty("receipt")]
        public TransactionReceipt Receipt { get; set; }

        /// <summary>Lifecycle history, present only with expand=timeline.</summary>
        [JsonProperty("timeline")]
        public List<TransactionTimelineEntry> Timeline { get; set; }

        /// <summary>Actual transaction cost in USD, available after on-chain confirmation.</summary>
        [JsonProperty("costUsd")]
        public string CostUsd { get; set; }
    }

    public static class TransactionStatus
    {
        public const string AwaitingSignature = "awaiting_signature";
        public const string Submitted = "submitted";
        public const string Succeeded = "succeeded";
        public const string Reverted = "reverted";
        public const string Failed = "failed";
    }

    /// <summary>
    /// A single call executed by the transaction: either raw (To/Value/Data)
    /// or a registered contract call (ContractId/FunctionName/FunctionArgs).
    /// </summary>
    public class TransactionCall
    {
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>Value in wei, as a string.</summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("dataSuffix")]
        public string DataSuffix { get; set; }

        /// <summary>ID of a contract registered in Openfort (starts with con_).</summary>
        [JsonProperty("contractId")]
        public string ContractId { get; set; }

        [JsonProperty("functionName")]
        public string FunctionName { get; set; }

        [JsonProperty("functionArgs")]
        public List<object> FunctionArgs { get; set; }
    }

    /// <summary>
    /// How the transaction is executed on-chain. <see cref="Type"/> is "userOperation" (ERC-4337,
    /// including EIP-7702 delegated accounts) or "transaction" (plain EOA transaction).
    /// The user-operation fields are set for the former, the EOA fields for the latter.
    /// </summary>
    public class TransactionExecution
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("entryPointVersion")]
        public string EntryPointVersion { get; set; }

        [JsonProperty("userOperationHash")]
        public string UserOperationHash { get; set; }

        /// <summary>The full user operation, present only with expand=userOperation.</summary>
        [JsonProperty("userOperation")]
        public JObject UserOperation { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("nonce")]
        public string Nonce { get; set; }

        [JsonProperty("gas")]
        public string Gas { get; set; }

        [JsonProperty("maxFeePerGas")]
        public string MaxFeePerGas { get; set; }

        [JsonProperty("maxPriorityFeePerGas")]
        public string MaxPriorityFeePerGas { get; set; }
    }

    public class SignHashAction
    {
        /// <summary>Always "sign_hash".</summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>Hash to sign with the account's signer, then submit with SendTransactionSignatureRequest.</summary>
        [JsonProperty("hash")]
        public string Hash { get; set; }
    }

    public class TransactionReceipt
    {
        [JsonProperty("createdAt")]
        public long CreatedAt { get; set; }

        [JsonProperty("transactionHash")]
        public string TransactionHash { get; set; }

        [JsonProperty("blockNumber")]
        public long? BlockNumber { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("gasUsed")]
        public string GasUsed { get; set; }

        [JsonProperty("gasFee")]
        public string GasFee { get; set; }

        [JsonProperty("l1GasUsed")]
        public string L1GasUsed { get; set; }

        [JsonProperty("l1GasFee")]
        public string L1GasFee { get; set; }

        /// <summary>Event logs, present only with expand=logs.</summary>
        [JsonProperty("logs")]
        public List<Log> Logs { get; set; }

        /// <summary>Present when the transaction reverted or failed.</summary>
        [JsonProperty("error")]
        public TransactionError Error { get; set; }
    }

    public class TransactionError
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("explanation")]
        public TransactionErrorExplanation Explanation { get; set; }
    }

    public class TransactionErrorExplanation
    {
        [JsonProperty("cause")]
        public string Cause { get; set; }

        [JsonProperty("solution")]
        public string Solution { get; set; }
    }

    public class TransactionTimelineEntry
    {
        [JsonProperty("event")]
        public string Event { get; set; }

        /// <summary>Unix timestamp in seconds. Absent when the exact time is unknown.</summary>
        [JsonProperty("at")]
        public long? At { get; set; }
    }
}
