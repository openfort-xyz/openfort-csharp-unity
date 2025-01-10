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
    /// AuthProviderWithTypeResponse
    /// </summary>
    [DataContract(Name = "AuthProviderWithTypeResponse")]
    public partial class AuthProviderWithTypeResponse : IEquatable<AuthProviderWithTypeResponse>
    {

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public AuthenticationType Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthProviderWithTypeResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AuthProviderWithTypeResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthProviderWithTypeResponse" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="provider">provider (required).</param>
        public AuthProviderWithTypeResponse(AuthenticationType type = default(AuthenticationType), AuthProvider provider = default(AuthProvider))
        {
            this.Type = type;
            // to ensure "provider" is required (not null)
            if (provider == null)
            {
                throw new ArgumentNullException("provider is a required property for AuthProviderWithTypeResponse and cannot be null");
            }
            this.Provider = provider;
        }

        /// <summary>
        /// Gets or Sets Provider
        /// </summary>
        [DataMember(Name = "provider", IsRequired = true, EmitDefaultValue = true)]
        public AuthProvider Provider { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AuthProviderWithTypeResponse {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Provider: ").Append(Provider).Append("\n");
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
            return this.Equals(input as AuthProviderWithTypeResponse);
        }

        /// <summary>
        /// Returns true if AuthProviderWithTypeResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthProviderWithTypeResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthProviderWithTypeResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) &&
                (
                    this.Provider == input.Provider ||
                    (this.Provider != null &&
                    this.Provider.Equals(input.Provider))
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
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                if (this.Provider != null)
                {
                    hashCode = (hashCode * 59) + this.Provider.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
