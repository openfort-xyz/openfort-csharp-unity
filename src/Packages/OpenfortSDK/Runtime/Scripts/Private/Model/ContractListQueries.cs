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
    /// ContractListQueries
    /// </summary>
    [DataContract(Name = "ContractListQueries")]
    public partial class ContractListQueries : IEquatable<ContractListQueries>
    {

        /// <summary>
        /// Gets or Sets Order
        /// </summary>
        [DataMember(Name = "order", EmitDefaultValue = false)]
        public SortOrder? Order { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractListQueries" /> class.
        /// </summary>
        /// <param name="limit">Specifies the maximum number of records to return..</param>
        /// <param name="skip">Specifies the offset for the first records to return..</param>
        /// <param name="order">order.</param>
        /// <param name="name">Specifies the name of the contract..</param>
        /// <param name="deleted">Specifies whether to include deleted contracts..</param>
        /// <param name="chainId">The chain ID of the contract..</param>
        /// <param name="address">Specifies the address of the contract..</param>
        public ContractListQueries(int limit = default(int), int skip = default(int), SortOrder? order = default(SortOrder?), string name = default(string), bool deleted = default(bool), int chainId = default(int), string address = default(string))
        {
            this.Limit = limit;
            this.Skip = skip;
            this.Order = order;
            this.Name = name;
            this.Deleted = deleted;
            this.ChainId = chainId;
            this.Address = address;
        }

        /// <summary>
        /// Specifies the maximum number of records to return.
        /// </summary>
        /// <value>Specifies the maximum number of records to return.</value>
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int Limit { get; set; }

        /// <summary>
        /// Specifies the offset for the first records to return.
        /// </summary>
        /// <value>Specifies the offset for the first records to return.</value>
        [DataMember(Name = "skip", EmitDefaultValue = false)]
        public int Skip { get; set; }

        /// <summary>
        /// Specifies the name of the contract.
        /// </summary>
        /// <value>Specifies the name of the contract.</value>
        /// <example>&quot;NFT Contract&quot;</example>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Specifies whether to include deleted contracts.
        /// </summary>
        /// <value>Specifies whether to include deleted contracts.</value>
        /// <example>false</example>
        [DataMember(Name = "deleted", EmitDefaultValue = true)]
        public bool Deleted { get; set; }

        /// <summary>
        /// The chain ID of the contract.
        /// </summary>
        /// <value>The chain ID of the contract.</value>
        /// <example>80002</example>
        [DataMember(Name = "chainId", EmitDefaultValue = false)]
        public int ChainId { get; set; }

        /// <summary>
        /// Specifies the address of the contract.
        /// </summary>
        /// <value>Specifies the address of the contract.</value>
        /// <example>&quot;0x742e6e61d760164d56f44801054bcf40fa821d97&quot;</example>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public string Address { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ContractListQueries {\n");
            sb.Append("  Limit: ").Append(Limit).Append("\n");
            sb.Append("  Skip: ").Append(Skip).Append("\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Deleted: ").Append(Deleted).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
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
            return this.Equals(input as ContractListQueries);
        }

        /// <summary>
        /// Returns true if ContractListQueries instances are equal
        /// </summary>
        /// <param name="input">Instance of ContractListQueries to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ContractListQueries input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Limit == input.Limit ||
                    this.Limit.Equals(input.Limit)
                ) &&
                (
                    this.Skip == input.Skip ||
                    this.Skip.Equals(input.Skip)
                ) &&
                (
                    this.Order == input.Order ||
                    this.Order.Equals(input.Order)
                ) &&
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.Deleted == input.Deleted ||
                    this.Deleted.Equals(input.Deleted)
                ) &&
                (
                    this.ChainId == input.ChainId ||
                    this.ChainId.Equals(input.ChainId)
                ) &&
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
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
                hashCode = (hashCode * 59) + this.Limit.GetHashCode();
                hashCode = (hashCode * 59) + this.Skip.GetHashCode();
                hashCode = (hashCode * 59) + this.Order.GetHashCode();
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Deleted.GetHashCode();
                hashCode = (hashCode * 59) + this.ChainId.GetHashCode();
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
