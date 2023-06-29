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
        /// <param name="project">The project ID.</param>
        /// <param name="policy">The policy ID (required).</param>
        /// <param name="chainId">The chain_id where the account is. (required).</param>
        /// <param name="newOwnerAddress">The address of the new owner (required).</param>
        /// <param name="player">The player ID.</param>
        public PlayerTransferOwnershipRequest(string project = default(string), string policy = default(string), double chainId = default(double), string newOwnerAddress = default(string), string player = default(string))
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
            this.Project = project;
            this.Player = player;
        }

        /// <summary>
        /// The project ID
        /// </summary>
        /// <value>The project ID</value>
        [DataMember(Name = "project", EmitDefaultValue = false)]
        public string Project { get; set; }

        /// <summary>
        /// The policy ID
        /// </summary>
        /// <value>The policy ID</value>
        [DataMember(Name = "policy", IsRequired = true, EmitDefaultValue = true)]
        public string Policy { get; set; }

        /// <summary>
        /// The chain_id where the account is.
        /// </summary>
        /// <value>The chain_id where the account is.</value>
        [DataMember(Name = "chain_id", IsRequired = true, EmitDefaultValue = true)]
        public double ChainId { get; set; }

        /// <summary>
        /// The address of the new owner
        /// </summary>
        /// <value>The address of the new owner</value>
        [DataMember(Name = "new_owner_address", IsRequired = true, EmitDefaultValue = true)]
        public string NewOwnerAddress { get; set; }

        /// <summary>
        /// The player ID
        /// </summary>
        /// <value>The player ID</value>
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
            sb.Append("  Project: ").Append(Project).Append("\n");
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
                    this.Project == input.Project ||
                    (this.Project != null &&
                    this.Project.Equals(input.Project))
                ) && 
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
                if (this.Project != null)
                {
                    hashCode = (hashCode * 59) + this.Project.GetHashCode();
                }
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
