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
    /// LinkedAccountResponse
    /// </summary>
    [DataContract(Name = "LinkedAccountResponse")]
    public partial class LinkedAccountResponse : IEquatable<LinkedAccountResponse>
    {

        /// <summary>
        /// Gets or Sets Provider
        /// </summary>
        [DataMember(Name = "provider", IsRequired = true, EmitDefaultValue = true)]
        public AuthProvider Provider { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedAccountResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected LinkedAccountResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedAccountResponse" /> class.
        /// </summary>
        /// <param name="provider">provider (required).</param>
        /// <param name="email">email.</param>
        /// <param name="externalUserId">externalUserId.</param>
        /// <param name="disabled">disabled (required).</param>
        /// <param name="updatedAt">updatedAt.</param>
        /// <param name="address">address.</param>
        /// <param name="metadata">metadata.</param>
        public LinkedAccountResponse(AuthProvider provider = default(AuthProvider), string email = default(string), string externalUserId = default(string), bool disabled = default(bool), double updatedAt = default(double), string address = default(string), PrismaInputJsonValue metadata = default(PrismaInputJsonValue))
        {
            this.Provider = provider;
            this.Disabled = disabled;
            this.Email = email;
            this.ExternalUserId = externalUserId;
            this.UpdatedAt = updatedAt;
            this.Address = address;
            this.Metadata = metadata;
        }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets ExternalUserId
        /// </summary>
        [DataMember(Name = "externalUserId", EmitDefaultValue = false)]
        public string ExternalUserId { get; set; }

        /// <summary>
        /// Gets or Sets Disabled
        /// </summary>
        [DataMember(Name = "disabled", IsRequired = true, EmitDefaultValue = true)]
        public bool Disabled { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [DataMember(Name = "updatedAt", EmitDefaultValue = false)]
        public double UpdatedAt { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        [DataMember(Name = "metadata", EmitDefaultValue = false)]
        public PrismaInputJsonValue Metadata { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class LinkedAccountResponse {\n");
            sb.Append("  Provider: ").Append(Provider).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  ExternalUserId: ").Append(ExternalUserId).Append("\n");
            sb.Append("  Disabled: ").Append(Disabled).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
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
            return this.Equals(input as LinkedAccountResponse);
        }

        /// <summary>
        /// Returns true if LinkedAccountResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of LinkedAccountResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LinkedAccountResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Provider == input.Provider ||
                    this.Provider.Equals(input.Provider)
                ) && 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.ExternalUserId == input.ExternalUserId ||
                    (this.ExternalUserId != null &&
                    this.ExternalUserId.Equals(input.ExternalUserId))
                ) && 
                (
                    this.Disabled == input.Disabled ||
                    this.Disabled.Equals(input.Disabled)
                ) && 
                (
                    this.UpdatedAt == input.UpdatedAt ||
                    this.UpdatedAt.Equals(input.UpdatedAt)
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.Metadata == input.Metadata ||
                    (this.Metadata != null &&
                    this.Metadata.Equals(input.Metadata))
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
                hashCode = (hashCode * 59) + this.Provider.GetHashCode();
                if (this.Email != null)
                {
                    hashCode = (hashCode * 59) + this.Email.GetHashCode();
                }
                if (this.ExternalUserId != null)
                {
                    hashCode = (hashCode * 59) + this.ExternalUserId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Disabled.GetHashCode();
                hashCode = (hashCode * 59) + this.UpdatedAt.GetHashCode();
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
                }
                if (this.Metadata != null)
                {
                    hashCode = (hashCode * 59) + this.Metadata.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
