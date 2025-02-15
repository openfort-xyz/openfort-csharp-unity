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
    /// PlayerTransferOwnershipRequest
    /// </summary>
    [DataContract(Name = "PlayerTransferOwnershipRequest")]
    public partial class PlayerTransferOwnershipRequest : IEquatable<PlayerTransferOwnershipRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerTransferOwnershipRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PlayerTransferOwnershipRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerTransferOwnershipRequest" /> class.
        /// </summary>
        /// <param name="policy">ID of the Policy that defines the gas sponsorship strategy (starts with &#x60;pol_&#x60;). A policy must be provided. (required).</param>
        /// <param name="chainId">The chain ID. Must be a [supported chain](/chains). (required).</param>
        /// <param name="newOwnerAddress">The address of the new owner (required).</param>
        /// <param name="player">ID of the Player that has the Account you want to transfer ownership from (starts with &#x60;pla_&#x60;)..</param>
        public PlayerTransferOwnershipRequest(string policy = default(string), int chainId = default(int), string newOwnerAddress = default(string), string player = default(string))
        {
            // to ensure "policy" is required (not null)
            if (policy == null)
            {
                throw new ArgumentNullException("policy is a required property for PlayerTransferOwnershipRequest and cannot be null");
            }
            this.Policy = policy;
            this.ChainId = chainId;
            // to ensure "newOwnerAddress" is required (not null)
            if (newOwnerAddress == null)
            {
                throw new ArgumentNullException("newOwnerAddress is a required property for PlayerTransferOwnershipRequest and cannot be null");
            }
            this.NewOwnerAddress = newOwnerAddress;
            this.Player = player;
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
        /// <example>80002</example>
        [DataMember(Name = "chainId", IsRequired = true, EmitDefaultValue = true)]
        public int ChainId { get; set; }

        /// <summary>
        /// The address of the new owner
        /// </summary>
        /// <value>The address of the new owner</value>
        /// <example>&quot;0x1234567890abcdef1234567890abcdef12345678&quot;</example>
        [DataMember(Name = "newOwnerAddress", IsRequired = true, EmitDefaultValue = true)]
        public string NewOwnerAddress { get; set; }

        /// <summary>
        /// ID of the Player that has the Account you want to transfer ownership from (starts with &#x60;pla_&#x60;).
        /// </summary>
        /// <value>ID of the Player that has the Account you want to transfer ownership from (starts with &#x60;pla_&#x60;).</value>
        /// <example>&quot;pla_e0b84653-1741-4a3d-9e91-2b0fd2942f60&quot;</example>
        [DataMember(Name = "player", EmitDefaultValue = false)]
        public string Player { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PlayerTransferOwnershipRequest {\n");
            sb.Append("  Policy: ").Append(Policy).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  NewOwnerAddress: ").Append(NewOwnerAddress).Append("\n");
            sb.Append("  Player: ").Append(Player).Append("\n");
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
            return this.Equals(input as PlayerTransferOwnershipRequest);
        }

        /// <summary>
        /// Returns true if PlayerTransferOwnershipRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of PlayerTransferOwnershipRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PlayerTransferOwnershipRequest input)
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
                ) &&
                (
                    this.NewOwnerAddress == input.NewOwnerAddress ||
                    (this.NewOwnerAddress != null &&
                    this.NewOwnerAddress.Equals(input.NewOwnerAddress))
                ) &&
                (
                    this.Player == input.Player ||
                    (this.Player != null &&
                    this.Player.Equals(input.Player))
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
                if (this.NewOwnerAddress != null)
                {
                    hashCode = (hashCode * 59) + this.NewOwnerAddress.GetHashCode();
                }
                if (this.Player != null)
                {
                    hashCode = (hashCode * 59) + this.Player.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
