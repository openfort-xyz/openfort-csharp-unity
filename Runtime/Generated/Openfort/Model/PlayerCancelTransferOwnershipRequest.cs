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
    /// PlayerCancelTransferOwnershipRequest
    /// </summary>
    [DataContract(Name = "PlayerCancelTransferOwnershipRequest")]
    public partial class PlayerCancelTransferOwnershipRequest : IEquatable<PlayerCancelTransferOwnershipRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCancelTransferOwnershipRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PlayerCancelTransferOwnershipRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCancelTransferOwnershipRequest" /> class.
        /// </summary>
        /// <param name="policy">ID of the Policy that defines the gas sponsorship strategy (starts with &#x60;pol_&#x60;). A policy must be provided. (required).</param>
        /// <param name="chainId">The chain ID. Must be a [supported chain](/chains). (required).</param>
        public PlayerCancelTransferOwnershipRequest(string policy = default(string), int chainId = default(int))
        {
            // to ensure "policy" is required (not null)
            if (policy == null)
            {
                throw new ArgumentNullException("policy is a required property for PlayerCancelTransferOwnershipRequest and cannot be null");
            }
            this.Policy = policy;
            this.ChainId = chainId;
        }

        /// <summary>
        /// ID of the Policy that defines the gas sponsorship strategy (starts with &#x60;pol_&#x60;). A policy must be provided.
        /// </summary>
        /// <value>ID of the Policy that defines the gas sponsorship strategy (starts with &#x60;pol_&#x60;). A policy must be provided.</value>
        /// <example>&quot;pol_7e07ae30-2a4d-48fa-803f-361da94905dd&quot;</example>
        [DataMember(Name = "policy", IsRequired = true, EmitDefaultValue = true)]
        public string Policy { get; set; }

        /// <summary>
        /// The chain ID. Must be a [supported chain](/chains).
        /// </summary>
        /// <value>The chain ID. Must be a [supported chain](/chains).</value>
        /// <example>80001</example>
        [DataMember(Name = "chainId", IsRequired = true, EmitDefaultValue = true)]
        public int ChainId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PlayerCancelTransferOwnershipRequest {\n");
            sb.Append("  Policy: ").Append(Policy).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
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
            return this.Equals(input as PlayerCancelTransferOwnershipRequest);
        }

        /// <summary>
        /// Returns true if PlayerCancelTransferOwnershipRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of PlayerCancelTransferOwnershipRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PlayerCancelTransferOwnershipRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Policy == input.Policy ||
                    (this.Policy != null &&
                    this.Policy.Equals(input.Policy))
                ) && 
                (
                    this.ChainId == input.ChainId ||
                    this.ChainId.Equals(input.ChainId)
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
                if (this.Policy != null)
                {
                    hashCode = (hashCode * 59) + this.Policy.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ChainId.GetHashCode();
                return hashCode;
            }
        }

    }

}