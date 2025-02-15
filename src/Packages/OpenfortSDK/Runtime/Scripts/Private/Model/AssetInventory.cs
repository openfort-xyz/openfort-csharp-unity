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
    /// AssetInventory
    /// </summary>
    [DataContract(Name = "AssetInventory")]
    public partial class AssetInventory : IEquatable<AssetInventory>
    {

        /// <summary>
        /// Gets or Sets AssetType
        /// </summary>
        [DataMember(Name = "assetType", IsRequired = true, EmitDefaultValue = true)]
        public AssetType AssetType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetInventory" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AssetInventory() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetInventory" /> class.
        /// </summary>
        /// <param name="assetType">assetType (required).</param>
        /// <param name="address">address.</param>
        /// <param name="tokenId">tokenId.</param>
        /// <param name="amount">amount in Wei.</param>
        /// <param name="lastTransferredAt">lastTransferredAt.</param>
        public AssetInventory(AssetType assetType = default(AssetType), string address = default(string), long tokenId = default(long), string amount = default(string), int lastTransferredAt = default(int))
        {
            this.AssetType = assetType;
            this.Address = address;
            this.TokenId = tokenId;
            this.Amount = amount;
            this.LastTransferredAt = lastTransferredAt;
        }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets TokenId
        /// </summary>
        [DataMember(Name = "tokenId", EmitDefaultValue = false)]
        public long TokenId { get; set; }

        /// <summary>
        /// amount in Wei
        /// </summary>
        /// <value>amount in Wei</value>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public string Amount { get; set; }

        /// <summary>
        /// Gets or Sets LastTransferredAt
        /// </summary>
        [DataMember(Name = "lastTransferredAt", EmitDefaultValue = false)]
        public int LastTransferredAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AssetInventory {\n");
            sb.Append("  AssetType: ").Append(AssetType).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  LastTransferredAt: ").Append(LastTransferredAt).Append("\n");
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
            return this.Equals(input as AssetInventory);
        }

        /// <summary>
        /// Returns true if AssetInventory instances are equal
        /// </summary>
        /// <param name="input">Instance of AssetInventory to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AssetInventory input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.AssetType == input.AssetType ||
                    this.AssetType.Equals(input.AssetType)
                ) &&
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) &&
                (
                    this.TokenId == input.TokenId ||
                    this.TokenId.Equals(input.TokenId)
                ) &&
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
                ) &&
                (
                    this.LastTransferredAt == input.LastTransferredAt ||
                    this.LastTransferredAt.Equals(input.LastTransferredAt)
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
                hashCode = (hashCode * 59) + this.AssetType.GetHashCode();
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.TokenId.GetHashCode();
                if (this.Amount != null)
                {
                    hashCode = (hashCode * 59) + this.Amount.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.LastTransferredAt.GetHashCode();
                return hashCode;
            }
        }

    }

}
