/*
 * Openfort API
 *
 * Complete Openfort API references and guides can be found at: https://openfort.xyz/docs
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: founders@openfort.xyz
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Openfort.OpenfortSDK.Model
{
    /// <summary>
    /// Log
    /// </summary>
    [DataContract(Name = "Log")]
    public partial class Log : IEquatable<Log>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Log" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Log() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Log" /> class.
        /// </summary>
        /// <param name="blockNumber">blockNumber (required).</param>
        /// <param name="blockHash">blockHash (required).</param>
        /// <param name="transactionIndex">transactionIndex (required).</param>
        /// <param name="removed">removed (required).</param>
        /// <param name="address">address (required).</param>
        /// <param name="data">data (required).</param>
        /// <param name="topics">topics (required).</param>
        /// <param name="transactionHash">transactionHash (required).</param>
        /// <param name="logIndex">logIndex (required).</param>
        /// <param name="orphaned">orphaned.</param>
        public Log(double blockNumber = default(double), string blockHash = default(string), double transactionIndex = default(double), bool removed = default(bool), string address = default(string), string data = default(string), List<string> topics = default(List<string>), string transactionHash = default(string), double logIndex = default(double), bool orphaned = default(bool))
        {
            this.BlockNumber = blockNumber;
            // to ensure "blockHash" is required (not null)
            if (blockHash == null)
            {
                throw new ArgumentNullException("blockHash is a required property for Log and cannot be null");
            }
            this.BlockHash = blockHash;
            this.TransactionIndex = transactionIndex;
            this.Removed = removed;
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new ArgumentNullException("address is a required property for Log and cannot be null");
            }
            this.Address = address;
            // to ensure "data" is required (not null)
            if (data == null)
            {
                throw new ArgumentNullException("data is a required property for Log and cannot be null");
            }
            this.Data = data;
            // to ensure "topics" is required (not null)
            if (topics == null)
            {
                throw new ArgumentNullException("topics is a required property for Log and cannot be null");
            }
            this.Topics = topics;
            // to ensure "transactionHash" is required (not null)
            if (transactionHash == null)
            {
                throw new ArgumentNullException("transactionHash is a required property for Log and cannot be null");
            }
            this.TransactionHash = transactionHash;
            this.LogIndex = logIndex;
            this.Orphaned = orphaned;
        }

        /// <summary>
        /// Gets or Sets BlockNumber
        /// </summary>
        [DataMember(Name = "blockNumber", IsRequired = true, EmitDefaultValue = true)]
        public double BlockNumber { get; set; }

        /// <summary>
        /// Gets or Sets BlockHash
        /// </summary>
        [DataMember(Name = "blockHash", IsRequired = true, EmitDefaultValue = true)]
        public string BlockHash { get; set; }

        /// <summary>
        /// Gets or Sets TransactionIndex
        /// </summary>
        [DataMember(Name = "transactionIndex", IsRequired = true, EmitDefaultValue = true)]
        public double TransactionIndex { get; set; }

        /// <summary>
        /// Gets or Sets Removed
        /// </summary>
        [DataMember(Name = "removed", IsRequired = true, EmitDefaultValue = true)]
        public bool Removed { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name = "address", IsRequired = true, EmitDefaultValue = true)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "data", IsRequired = true, EmitDefaultValue = true)]
        public string Data { get; set; }

        /// <summary>
        /// Gets or Sets Topics
        /// </summary>
        [DataMember(Name = "topics", IsRequired = true, EmitDefaultValue = true)]
        public List<string> Topics { get; set; }

        /// <summary>
        /// Gets or Sets TransactionHash
        /// </summary>
        [DataMember(Name = "transactionHash", IsRequired = true, EmitDefaultValue = true)]
        public string TransactionHash { get; set; }

        /// <summary>
        /// Gets or Sets LogIndex
        /// </summary>
        [DataMember(Name = "logIndex", IsRequired = true, EmitDefaultValue = true)]
        public double LogIndex { get; set; }

        /// <summary>
        /// Gets or Sets Orphaned
        /// </summary>
        [DataMember(Name = "orphaned", EmitDefaultValue = true)]
        public bool Orphaned { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Log {\n");
            sb.Append("  BlockNumber: ").Append(BlockNumber).Append("\n");
            sb.Append("  BlockHash: ").Append(BlockHash).Append("\n");
            sb.Append("  TransactionIndex: ").Append(TransactionIndex).Append("\n");
            sb.Append("  Removed: ").Append(Removed).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Topics: ").Append(Topics).Append("\n");
            sb.Append("  TransactionHash: ").Append(TransactionHash).Append("\n");
            sb.Append("  LogIndex: ").Append(LogIndex).Append("\n");
            sb.Append("  Orphaned: ").Append(Orphaned).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Log);
        }

        /// <summary>
        /// Returns true if Log instances are equal
        /// </summary>
        /// <param name="input">Instance of Log to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Log input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.BlockNumber == input.BlockNumber ||
                    this.BlockNumber.Equals(input.BlockNumber)
                ) &&
                (
                    this.BlockHash == input.BlockHash ||
                    (this.BlockHash != null &&
                    this.BlockHash.Equals(input.BlockHash))
                ) &&
                (
                    this.TransactionIndex == input.TransactionIndex ||
                    this.TransactionIndex.Equals(input.TransactionIndex)
                ) &&
                (
                    this.Removed == input.Removed ||
                    this.Removed.Equals(input.Removed)
                ) &&
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) &&
                (
                    this.Data == input.Data ||
                    (this.Data != null &&
                    this.Data.Equals(input.Data))
                ) &&
                (
                    this.Topics == input.Topics ||
                    this.Topics != null &&
                    input.Topics != null &&
                    this.Topics.SequenceEqual(input.Topics)
                ) &&
                (
                    this.TransactionHash == input.TransactionHash ||
                    (this.TransactionHash != null &&
                    this.TransactionHash.Equals(input.TransactionHash))
                ) &&
                (
                    this.LogIndex == input.LogIndex ||
                    this.LogIndex.Equals(input.LogIndex)
                ) &&
                (
                    this.Orphaned == input.Orphaned ||
                    this.Orphaned.Equals(input.Orphaned)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                hashCode = (hashCode * 59) + this.BlockNumber.GetHashCode();
                if (this.BlockHash != null)
                {
                    hashCode = (hashCode * 59) + this.BlockHash.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.TransactionIndex.GetHashCode();
                hashCode = (hashCode * 59) + this.Removed.GetHashCode();
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
                }
                if (this.Data != null)
                {
                    hashCode = (hashCode * 59) + this.Data.GetHashCode();
                }
                if (this.Topics != null)
                {
                    hashCode = (hashCode * 59) + this.Topics.GetHashCode();
                }
                if (this.TransactionHash != null)
                {
                    hashCode = (hashCode * 59) + this.TransactionHash.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.LogIndex.GetHashCode();
                hashCode = (hashCode * 59) + this.Orphaned.GetHashCode();
                return hashCode;
            }
        }

    }

}
