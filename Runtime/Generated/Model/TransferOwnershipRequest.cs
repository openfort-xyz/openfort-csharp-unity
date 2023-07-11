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
using OpenAPIDateConverter = Openfort.Client.OpenAPIDateConverter;

namespace Openfort.Model
{
    /// <summary>
    /// TransferOwnershipRequest
    /// </summary>
    [DataContract(Name = "TransferOwnershipRequest")]
    public partial class TransferOwnershipRequest : IEquatable<TransferOwnershipRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferOwnershipRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransferOwnershipRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferOwnershipRequest" /> class.
        /// </summary>
        /// <param name="newOwnerAddress">The address of the new owner (required).</param>
        /// <param name="policy">The policy ID (required).</param>
        public TransferOwnershipRequest(string newOwnerAddress = default(string), string policy = default(string))
        {
            // to ensure "newOwnerAddress" is required (not null)
            if (newOwnerAddress == null)
            {
                throw new ArgumentNullException("newOwnerAddress is a required property for TransferOwnershipRequest and cannot be null");
            }
            this.NewOwnerAddress = newOwnerAddress;
            // to ensure "policy" is required (not null)
            if (policy == null)
            {
                throw new ArgumentNullException("policy is a required property for TransferOwnershipRequest and cannot be null");
            }
            this.Policy = policy;
        }

        /// <summary>
        /// The address of the new owner
        /// </summary>
        /// <value>The address of the new owner</value>
        [DataMember(Name = "new_owner_address", IsRequired = true, EmitDefaultValue = true)]
        public string NewOwnerAddress { get; set; }

        /// <summary>
        /// The policy ID
        /// </summary>
        /// <value>The policy ID</value>
        [DataMember(Name = "policy", IsRequired = true, EmitDefaultValue = true)]
        public string Policy { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TransferOwnershipRequest {\n");
            sb.Append("  NewOwnerAddress: ").Append(NewOwnerAddress).Append("\n");
            sb.Append("  Policy: ").Append(Policy).Append("\n");
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
            return this.Equals(input as TransferOwnershipRequest);
        }

        /// <summary>
        /// Returns true if TransferOwnershipRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of TransferOwnershipRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransferOwnershipRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.NewOwnerAddress == input.NewOwnerAddress ||
                    (this.NewOwnerAddress != null &&
                    this.NewOwnerAddress.Equals(input.NewOwnerAddress))
                ) && 
                (
                    this.Policy == input.Policy ||
                    (this.Policy != null &&
                    this.Policy.Equals(input.Policy))
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
                if (this.NewOwnerAddress != null)
                {
                    hashCode = (hashCode * 59) + this.NewOwnerAddress.GetHashCode();
                }
                if (this.Policy != null)
                {
                    hashCode = (hashCode * 59) + this.Policy.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
