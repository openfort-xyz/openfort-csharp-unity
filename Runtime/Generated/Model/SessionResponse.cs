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
    /// SessionResponse
    /// </summary>
    [DataContract(Name = "SessionResponse")]
    public partial class SessionResponse : IEquatable<SessionResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SessionResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionResponse" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="_object">_object (required).</param>
        /// <param name="createdAt">createdAt (required).</param>
        /// <param name="updatedAt">updatedAt (required).</param>
        /// <param name="isActive">isActive.</param>
        /// <param name="address">address (required).</param>
        /// <param name="validAfter">validAfter.</param>
        /// <param name="validUntil">validUntil.</param>
        /// <param name="whitelist">whitelist.</param>
        /// <param name="limit">limit.</param>
        /// <param name="nextAction">nextAction (required).</param>
        /// <param name="transactionIntents">transactionIntents (required).</param>
        public SessionResponse(string id = default(string), string _object = default(string), DateTime createdAt = default(DateTime), DateTime updatedAt = default(DateTime), bool isActive = default(bool), string address = default(string), string validAfter = default(string), string validUntil = default(string), List<string> whitelist = default(List<string>), double limit = default(double), Object nextAction = default(Object), SessionResponseTransactionIntents transactionIntents = default(SessionResponseTransactionIntents))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for SessionResponse and cannot be null");
            }
            this.Id = id;
            // to ensure "_object" is required (not null)
            if (_object == null)
            {
                throw new ArgumentNullException("_object is a required property for SessionResponse and cannot be null");
            }
            this.Object = _object;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new ArgumentNullException("address is a required property for SessionResponse and cannot be null");
            }
            this.Address = address;
            // to ensure "nextAction" is required (not null)
            if (nextAction == null)
            {
                throw new ArgumentNullException("nextAction is a required property for SessionResponse and cannot be null");
            }
            this.NextAction = nextAction;
            // to ensure "transactionIntents" is required (not null)
            if (transactionIntents == null)
            {
                throw new ArgumentNullException("transactionIntents is a required property for SessionResponse and cannot be null");
            }
            this.TransactionIntents = transactionIntents;
            this.IsActive = isActive;
            this.ValidAfter = validAfter;
            this.ValidUntil = validUntil;
            this.Whitelist = whitelist;
            this.Limit = limit;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Object
        /// </summary>
        [DataMember(Name = "object", IsRequired = true, EmitDefaultValue = true)]
        public string Object { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [DataMember(Name = "updated_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or Sets IsActive
        /// </summary>
        [DataMember(Name = "is_active", EmitDefaultValue = true)]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name = "address", IsRequired = true, EmitDefaultValue = true)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets ValidAfter
        /// </summary>
        [DataMember(Name = "valid_after", EmitDefaultValue = false)]
        public string ValidAfter { get; set; }

        /// <summary>
        /// Gets or Sets ValidUntil
        /// </summary>
        [DataMember(Name = "valid_until", EmitDefaultValue = false)]
        public string ValidUntil { get; set; }

        /// <summary>
        /// Gets or Sets Whitelist
        /// </summary>
        [DataMember(Name = "whitelist", EmitDefaultValue = false)]
        public List<string> Whitelist { get; set; }

        /// <summary>
        /// Gets or Sets Limit
        /// </summary>
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public double Limit { get; set; }

        /// <summary>
        /// Gets or Sets NextAction
        /// </summary>
        [DataMember(Name = "next_action", IsRequired = true, EmitDefaultValue = true)]
        public Object NextAction { get; set; }

        /// <summary>
        /// Gets or Sets TransactionIntents
        /// </summary>
        [DataMember(Name = "transaction_intents", IsRequired = true, EmitDefaultValue = true)]
        public SessionResponseTransactionIntents TransactionIntents { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SessionResponse {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Object: ").Append(Object).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  IsActive: ").Append(IsActive).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  ValidAfter: ").Append(ValidAfter).Append("\n");
            sb.Append("  ValidUntil: ").Append(ValidUntil).Append("\n");
            sb.Append("  Whitelist: ").Append(Whitelist).Append("\n");
            sb.Append("  Limit: ").Append(Limit).Append("\n");
            sb.Append("  NextAction: ").Append(NextAction).Append("\n");
            sb.Append("  TransactionIntents: ").Append(TransactionIntents).Append("\n");
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
            return this.Equals(input as SessionResponse);
        }

        /// <summary>
        /// Returns true if SessionResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of SessionResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SessionResponse input)
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
                    (this.Object != null &&
                    this.Object.Equals(input.Object))
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) && 
                (
                    this.UpdatedAt == input.UpdatedAt ||
                    (this.UpdatedAt != null &&
                    this.UpdatedAt.Equals(input.UpdatedAt))
                ) && 
                (
                    this.IsActive == input.IsActive ||
                    this.IsActive.Equals(input.IsActive)
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.ValidAfter == input.ValidAfter ||
                    (this.ValidAfter != null &&
                    this.ValidAfter.Equals(input.ValidAfter))
                ) && 
                (
                    this.ValidUntil == input.ValidUntil ||
                    (this.ValidUntil != null &&
                    this.ValidUntil.Equals(input.ValidUntil))
                ) && 
                (
                    this.Whitelist == input.Whitelist ||
                    this.Whitelist != null &&
                    input.Whitelist != null &&
                    this.Whitelist.SequenceEqual(input.Whitelist)
                ) && 
                (
                    this.Limit == input.Limit ||
                    this.Limit.Equals(input.Limit)
                ) && 
                (
                    this.NextAction == input.NextAction ||
                    (this.NextAction != null &&
                    this.NextAction.Equals(input.NextAction))
                ) && 
                (
                    this.TransactionIntents == input.TransactionIntents ||
                    (this.TransactionIntents != null &&
                    this.TransactionIntents.Equals(input.TransactionIntents))
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
                if (this.Object != null)
                {
                    hashCode = (hashCode * 59) + this.Object.GetHashCode();
                }
                if (this.CreatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                }
                if (this.UpdatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.UpdatedAt.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.IsActive.GetHashCode();
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
                }
                if (this.ValidAfter != null)
                {
                    hashCode = (hashCode * 59) + this.ValidAfter.GetHashCode();
                }
                if (this.ValidUntil != null)
                {
                    hashCode = (hashCode * 59) + this.ValidUntil.GetHashCode();
                }
                if (this.Whitelist != null)
                {
                    hashCode = (hashCode * 59) + this.Whitelist.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Limit.GetHashCode();
                if (this.NextAction != null)
                {
                    hashCode = (hashCode * 59) + this.NextAction.GetHashCode();
                }
                if (this.TransactionIntents != null)
                {
                    hashCode = (hashCode * 59) + this.TransactionIntents.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
