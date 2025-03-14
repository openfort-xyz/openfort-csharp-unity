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
    /// CustomAuthConfig
    /// </summary>
    [DataContract(Name = "CustomAuthConfig")]
    public partial class CustomAuthConfig : IEquatable<CustomAuthConfig>
    {

        /// <summary>
        /// Gets or Sets Provider
        /// </summary>
        [DataMember(Name = "provider", IsRequired = true, EmitDefaultValue = true)]
        public ThirdPartyOAuthProviderCUSTOM Provider { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAuthConfig" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CustomAuthConfig() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAuthConfig" /> class.
        /// </summary>
        /// <param name="enabled">Enable OAuth provider. (required).</param>
        /// <param name="provider">provider (required).</param>
        /// <param name="headers">Headers to send with the request.</param>
        /// <param name="authenticationUrl">URL to send the request to to verify the payload (required).</param>
        public CustomAuthConfig(bool enabled = default(bool), ThirdPartyOAuthProviderCUSTOM provider = default(ThirdPartyOAuthProviderCUSTOM), string headers = default(string), string authenticationUrl = default(string))
        {
            this.Enabled = enabled;
            this.Provider = provider;
            // to ensure "authenticationUrl" is required (not null)
            if (authenticationUrl == null)
            {
                throw new ArgumentNullException("authenticationUrl is a required property for CustomAuthConfig and cannot be null");
            }
            this.AuthenticationUrl = authenticationUrl;
            this.Headers = headers;
        }

        /// <summary>
        /// Enable OAuth provider.
        /// </summary>
        /// <value>Enable OAuth provider.</value>
        [DataMember(Name = "enabled", IsRequired = true, EmitDefaultValue = true)]
        public bool Enabled { get; set; }

        /// <summary>
        /// Headers to send with the request
        /// </summary>
        /// <value>Headers to send with the request</value>
        [DataMember(Name = "headers", EmitDefaultValue = false)]
        public string Headers { get; set; }

        /// <summary>
        /// URL to send the request to to verify the payload
        /// </summary>
        /// <value>URL to send the request to to verify the payload</value>
        [DataMember(Name = "authenticationUrl", IsRequired = true, EmitDefaultValue = true)]
        public string AuthenticationUrl { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CustomAuthConfig {\n");
            sb.Append("  Enabled: ").Append(Enabled).Append("\n");
            sb.Append("  Provider: ").Append(Provider).Append("\n");
            sb.Append("  Headers: ").Append(Headers).Append("\n");
            sb.Append("  AuthenticationUrl: ").Append(AuthenticationUrl).Append("\n");
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
            return this.Equals(input as CustomAuthConfig);
        }

        /// <summary>
        /// Returns true if CustomAuthConfig instances are equal
        /// </summary>
        /// <param name="input">Instance of CustomAuthConfig to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CustomAuthConfig input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Enabled == input.Enabled ||
                    this.Enabled.Equals(input.Enabled)
                ) &&
                (
                    this.Provider == input.Provider ||
                    this.Provider.Equals(input.Provider)
                ) &&
                (
                    this.Headers == input.Headers ||
                    (this.Headers != null &&
                    this.Headers.Equals(input.Headers))
                ) &&
                (
                    this.AuthenticationUrl == input.AuthenticationUrl ||
                    (this.AuthenticationUrl != null &&
                    this.AuthenticationUrl.Equals(input.AuthenticationUrl))
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
                hashCode = (hashCode * 59) + this.Enabled.GetHashCode();
                hashCode = (hashCode * 59) + this.Provider.GetHashCode();
                if (this.Headers != null)
                {
                    hashCode = (hashCode * 59) + this.Headers.GetHashCode();
                }
                if (this.AuthenticationUrl != null)
                {
                    hashCode = (hashCode * 59) + this.AuthenticationUrl.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
