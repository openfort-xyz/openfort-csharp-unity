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
using OpenAPIDateConverter = OpenfortSdk.Client.OpenAPIDateConverter;

namespace OpenfortSdk.Model
{
    /// <summary>
    /// AccountResponse
    /// </summary>
    [DataContract(Name = "AccountResponse")]
    public partial class AccountResponse : IEquatable<AccountResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AccountResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountResponse" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="createdAt">createdAt (required).</param>
        /// <param name="address">address (required).</param>
        /// <param name="deployed">deployed (required).</param>
        /// <param name="_object">_object (required).</param>
        /// <param name="chainId">chainId (required).</param>
        /// <param name="transactionIntents">transactionIntents (required).</param>
        public AccountResponse(string id = default(string), DateTime createdAt = default(DateTime), string address = default(string), bool deployed = default(bool), string _object = default(string), double chainId = default(double), List<TransactionIntentResponse> transactionIntents = default(List<TransactionIntentResponse>))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for AccountResponse and cannot be null");
            }
            this.Id = id;
            this.CreatedAt = createdAt;
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new ArgumentNullException("address is a required property for AccountResponse and cannot be null");
            }
            this.Address = address;
            this.Deployed = deployed;
            // to ensure "_object" is required (not null)
            if (_object == null)
            {
                throw new ArgumentNullException("_object is a required property for AccountResponse and cannot be null");
            }
            this.Object = _object;
            this.ChainId = chainId;
            // to ensure "transactionIntents" is required (not null)
            if (transactionIntents == null)
            {
                throw new ArgumentNullException("transactionIntents is a required property for AccountResponse and cannot be null");
            }
            this.TransactionIntents = transactionIntents;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name = "address", IsRequired = true, EmitDefaultValue = true)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets Deployed
        /// </summary>
        [DataMember(Name = "deployed", IsRequired = true, EmitDefaultValue = true)]
        public bool Deployed { get; set; }

        /// <summary>
        /// Gets or Sets Object
        /// </summary>
        [DataMember(Name = "object", IsRequired = true, EmitDefaultValue = true)]
        public string Object { get; set; }

        /// <summary>
        /// Gets or Sets ChainId
        /// </summary>
        [DataMember(Name = "chain_id", IsRequired = true, EmitDefaultValue = true)]
        public double ChainId { get; set; }

        /// <summary>
        /// Gets or Sets TransactionIntents
        /// </summary>
        [DataMember(Name = "transaction_intents", IsRequired = true, EmitDefaultValue = true)]
        public List<TransactionIntentResponse> TransactionIntents { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AccountResponse {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Deployed: ").Append(Deployed).Append("\n");
            sb.Append("  Object: ").Append(Object).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
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
            return this.Equals(input as AccountResponse);
        }

        /// <summary>
        /// Returns true if AccountResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of AccountResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountResponse input)
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
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.Deployed == input.Deployed ||
                    this.Deployed.Equals(input.Deployed)
                ) && 
                (
                    this.Object == input.Object ||
                    (this.Object != null &&
                    this.Object.Equals(input.Object))
                ) && 
                (
                    this.ChainId == input.ChainId ||
                    this.ChainId.Equals(input.ChainId)
                ) && 
                (
                    this.TransactionIntents == input.TransactionIntents ||
                    this.TransactionIntents != null &&
                    input.TransactionIntents != null &&
                    this.TransactionIntents.SequenceEqual(input.TransactionIntents)
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
                if (this.CreatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                }
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Deployed.GetHashCode();
                if (this.Object != null)
                {
                    hashCode = (hashCode * 59) + this.Object.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ChainId.GetHashCode();
                if (this.TransactionIntents != null)
                {
                    hashCode = (hashCode * 59) + this.TransactionIntents.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
