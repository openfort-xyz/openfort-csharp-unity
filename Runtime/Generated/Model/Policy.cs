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
    /// Policy
    /// </summary>
    [DataContract(Name = "Policy")]
    public partial class Policy : IEquatable<Policy>
    {

        /// <summary>
        /// Gets or Sets Object
        /// </summary>
        [DataMember(Name = "object", IsRequired = true, EmitDefaultValue = true)]
        public EntityTypePOLICY Object { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Policy" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Policy() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Policy" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="_object">_object (required).</param>
        /// <param name="createdAt">createdAt (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="deleted">deleted (required).</param>
        /// <param name="chainId">The chain ID. (required).</param>
        /// <param name="strategy">strategy (required).</param>
        /// <param name="transactionIntents">transactionIntents (required).</param>
        /// <param name="policyRules">policyRules (required).</param>
        public Policy(string id = default(string), EntityTypePOLICY _object = default(EntityTypePOLICY), int createdAt = default(int), string name = default(string), bool deleted = default(bool), int chainId = default(int), PolicyStrategy strategy = default(PolicyStrategy), List<EntityIdResponse> transactionIntents = default(List<EntityIdResponse>), List<EntityIdResponse> policyRules = default(List<EntityIdResponse>))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for Policy and cannot be null");
            }
            this.Id = id;
            this.Object = _object;
            this.CreatedAt = createdAt;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for Policy and cannot be null");
            }
            this.Name = name;
            this.Deleted = deleted;
            this.ChainId = chainId;
            // to ensure "strategy" is required (not null)
            if (strategy == null)
            {
                throw new ArgumentNullException("strategy is a required property for Policy and cannot be null");
            }
            this.Strategy = strategy;
            // to ensure "transactionIntents" is required (not null)
            if (transactionIntents == null)
            {
                throw new ArgumentNullException("transactionIntents is a required property for Policy and cannot be null");
            }
            this.TransactionIntents = transactionIntents;
            // to ensure "policyRules" is required (not null)
            if (policyRules == null)
            {
                throw new ArgumentNullException("policyRules is a required property for Policy and cannot be null");
            }
            this.PolicyRules = policyRules;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "createdAt", IsRequired = true, EmitDefaultValue = true)]
        public int CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Deleted
        /// </summary>
        [DataMember(Name = "deleted", IsRequired = true, EmitDefaultValue = true)]
        public bool Deleted { get; set; }

        /// <summary>
        /// The chain ID.
        /// </summary>
        /// <value>The chain ID.</value>
        [DataMember(Name = "chainId", IsRequired = true, EmitDefaultValue = true)]
        public int ChainId { get; set; }

        /// <summary>
        /// Gets or Sets Strategy
        /// </summary>
        [DataMember(Name = "strategy", IsRequired = true, EmitDefaultValue = true)]
        public PolicyStrategy Strategy { get; set; }

        /// <summary>
        /// Gets or Sets TransactionIntents
        /// </summary>
        [DataMember(Name = "transactionIntents", IsRequired = true, EmitDefaultValue = true)]
        public List<EntityIdResponse> TransactionIntents { get; set; }

        /// <summary>
        /// Gets or Sets PolicyRules
        /// </summary>
        [DataMember(Name = "policyRules", IsRequired = true, EmitDefaultValue = true)]
        public List<EntityIdResponse> PolicyRules { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Policy {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Object: ").Append(Object).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Deleted: ").Append(Deleted).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  Strategy: ").Append(Strategy).Append("\n");
            sb.Append("  TransactionIntents: ").Append(TransactionIntents).Append("\n");
            sb.Append("  PolicyRules: ").Append(PolicyRules).Append("\n");
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
            return this.Equals(input as Policy);
        }

        /// <summary>
        /// Returns true if Policy instances are equal
        /// </summary>
        /// <param name="input">Instance of Policy to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Policy input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Object == input.Object ||
                    this.Object.Equals(input.Object)
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    this.CreatedAt.Equals(input.CreatedAt)
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
                    this.Strategy == input.Strategy ||
                    (this.Strategy != null &&
                    this.Strategy.Equals(input.Strategy))
                ) && 
                (
                    this.TransactionIntents == input.TransactionIntents ||
                    this.TransactionIntents != null &&
                    input.TransactionIntents != null &&
                    this.TransactionIntents.SequenceEqual(input.TransactionIntents)
                ) && 
                (
                    this.PolicyRules == input.PolicyRules ||
                    this.PolicyRules != null &&
                    input.PolicyRules != null &&
                    this.PolicyRules.SequenceEqual(input.PolicyRules)
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
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Object.GetHashCode();
                hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Deleted.GetHashCode();
                hashCode = (hashCode * 59) + this.ChainId.GetHashCode();
                if (this.Strategy != null)
                {
                    hashCode = (hashCode * 59) + this.Strategy.GetHashCode();
                }
                if (this.TransactionIntents != null)
                {
                    hashCode = (hashCode * 59) + this.TransactionIntents.GetHashCode();
                }
                if (this.PolicyRules != null)
                {
                    hashCode = (hashCode * 59) + this.PolicyRules.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
