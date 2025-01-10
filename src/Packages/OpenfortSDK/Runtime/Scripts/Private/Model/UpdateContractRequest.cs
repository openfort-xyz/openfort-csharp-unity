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
    /// UpdateContractRequest
    /// </summary>
    [DataContract(Name = "UpdateContractRequest")]
    public partial class UpdateContractRequest : IEquatable<UpdateContractRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateContractRequest" /> class.
        /// </summary>
        /// <param name="name">Specifies the name of the contract (Only for display purposes)..</param>
        /// <param name="chainId">Specifies the chain ID of the contract. Must be a [supported chain](/chains)..</param>
        /// <param name="deleted">Specifies whether to delete the contract..</param>
        /// <param name="address">Specifies the address of the contract..</param>
        /// <param name="abi">Specifies the ABI of the contract..</param>
        /// <param name="publicVerification">Specifies whether to verify the contract publicly..</param>
        public UpdateContractRequest(string name = default(string), int chainId = default(int), bool deleted = default(bool), string address = default(string), List<Abi> abi = default(List<Abi>), bool publicVerification = default(bool))
        {
            this.Name = name;
            this.ChainId = chainId;
            this.Deleted = deleted;
            this.Address = address;
            this.Abi = abi;
            this.PublicVerification = publicVerification;
        }

        /// <summary>
        /// Specifies the name of the contract (Only for display purposes).
        /// </summary>
        /// <value>Specifies the name of the contract (Only for display purposes).</value>
        /// <example>&quot;NFT Contract&quot;</example>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Specifies the chain ID of the contract. Must be a [supported chain](/chains).
        /// </summary>
        /// <value>Specifies the chain ID of the contract. Must be a [supported chain](/chains).</value>
        /// <example>80002</example>
        [DataMember(Name = "chainId", EmitDefaultValue = false)]
        public int ChainId { get; set; }

        /// <summary>
        /// Specifies whether to delete the contract.
        /// </summary>
        /// <value>Specifies whether to delete the contract.</value>
        /// <example>false</example>
        [DataMember(Name = "deleted", EmitDefaultValue = true)]
        public bool Deleted { get; set; }

        /// <summary>
        /// Specifies the address of the contract.
        /// </summary>
        /// <value>Specifies the address of the contract.</value>
        /// <example>&quot;0x1234567890abcdef1234567890abcdef12345678&quot;</example>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public string Address { get; set; }

        /// <summary>
        /// Specifies the ABI of the contract.
        /// </summary>
        /// <value>Specifies the ABI of the contract.</value>
        [DataMember(Name = "abi", EmitDefaultValue = false)]
        public List<Abi> Abi { get; set; }

        /// <summary>
        /// Specifies whether to verify the contract publicly.
        /// </summary>
        /// <value>Specifies whether to verify the contract publicly.</value>
        /// <example>false</example>
        [DataMember(Name = "publicVerification", EmitDefaultValue = true)]
        public bool PublicVerification { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UpdateContractRequest {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  Deleted: ").Append(Deleted).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Abi: ").Append(Abi).Append("\n");
            sb.Append("  PublicVerification: ").Append(PublicVerification).Append("\n");
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
            return this.Equals(input as UpdateContractRequest);
        }

        /// <summary>
        /// Returns true if UpdateContractRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdateContractRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateContractRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.ChainId == input.ChainId ||
                    this.ChainId.Equals(input.ChainId)
                ) &&
                (
                    this.Deleted == input.Deleted ||
                    this.Deleted.Equals(input.Deleted)
                ) &&
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) &&
                (
                    this.Abi == input.Abi ||
                    this.Abi != null &&
                    input.Abi != null &&
                    this.Abi.SequenceEqual(input.Abi)
                ) &&
                (
                    this.PublicVerification == input.PublicVerification ||
                    this.PublicVerification.Equals(input.PublicVerification)
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ChainId.GetHashCode();
                hashCode = (hashCode * 59) + this.Deleted.GetHashCode();
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
                }
                if (this.Abi != null)
                {
                    hashCode = (hashCode * 59) + this.Abi.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.PublicVerification.GetHashCode();
                return hashCode;
            }
        }

    }

}
