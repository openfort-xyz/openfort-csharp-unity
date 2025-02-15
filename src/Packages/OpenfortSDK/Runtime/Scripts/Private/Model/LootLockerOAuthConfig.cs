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
    /// LootLocker oauth configuration
    /// </summary>
    [DataContract(Name = "LootLockerOAuthConfig")]
    public partial class LootLockerOAuthConfig : IEquatable<LootLockerOAuthConfig>
    {

        /// <summary>
        /// Gets or Sets Provider
        /// </summary>
        [DataMember(Name = "provider", IsRequired = true, EmitDefaultValue = true)]
        public ThirdPartyOAuthProviderLOOTLOCKER Provider { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="LootLockerOAuthConfig" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected LootLockerOAuthConfig() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LootLockerOAuthConfig" /> class.
        /// </summary>
        /// <param name="enabled">Enable OAuth provider. (required).</param>
        /// <param name="provider">provider (required).</param>
        public LootLockerOAuthConfig(bool enabled = default(bool), ThirdPartyOAuthProviderLOOTLOCKER provider = default(ThirdPartyOAuthProviderLOOTLOCKER))
        {
            this.Enabled = enabled;
            this.Provider = provider;
        }

        /// <summary>
        /// Enable OAuth provider.
        /// </summary>
        /// <value>Enable OAuth provider.</value>
        [DataMember(Name = "enabled", IsRequired = true, EmitDefaultValue = true)]
        public bool Enabled { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class LootLockerOAuthConfig {\n");
            sb.Append("  Enabled: ").Append(Enabled).Append("\n");
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
            return this.Equals(input as LootLockerOAuthConfig);
        }

        /// <summary>
        /// Returns true if LootLockerOAuthConfig instances are equal
        /// </summary>
        /// <param name="input">Instance of LootLockerOAuthConfig to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LootLockerOAuthConfig input)
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
                return hashCode;
            }
        }

    }

}
