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
    /// LineOAuthConfig
    /// </summary>
    [DataContract(Name = "LineOAuthConfig")]
    public partial class LineOAuthConfig : IEquatable<LineOAuthConfig>
    {

        /// <summary>
        /// Gets or Sets Provider
        /// </summary>
        [DataMember(Name = "provider", IsRequired = true, EmitDefaultValue = true)]
        public OAuthProviderLINE Provider { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="LineOAuthConfig" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected LineOAuthConfig() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LineOAuthConfig" /> class.
        /// </summary>
        /// <param name="enabled">Enable OAuth provider. (required).</param>
        /// <param name="provider">provider (required).</param>
        /// <param name="channelId">Line Channel ID. (required).</param>
        /// <param name="channelSecret">Line Channel secret. (required).</param>
        public LineOAuthConfig(bool enabled = default(bool), OAuthProviderLINE provider = default(OAuthProviderLINE), string channelId = default(string), string channelSecret = default(string))
        {
            this.Enabled = enabled;
            this.Provider = provider;
            // to ensure "channelId" is required (not null)
            if (channelId == null)
            {
                throw new ArgumentNullException("channelId is a required property for LineOAuthConfig and cannot be null");
            }
            this.ChannelId = channelId;
            // to ensure "channelSecret" is required (not null)
            if (channelSecret == null)
            {
                throw new ArgumentNullException("channelSecret is a required property for LineOAuthConfig and cannot be null");
            }
            this.ChannelSecret = channelSecret;
        }

        /// <summary>
        /// Enable OAuth provider.
        /// </summary>
        /// <value>Enable OAuth provider.</value>
        [DataMember(Name = "enabled", IsRequired = true, EmitDefaultValue = true)]
        public bool Enabled { get; set; }

        /// <summary>
        /// Line Channel ID.
        /// </summary>
        /// <value>Line Channel ID.</value>
        [DataMember(Name = "channelId", IsRequired = true, EmitDefaultValue = true)]
        public string ChannelId { get; set; }

        /// <summary>
        /// Line Channel secret.
        /// </summary>
        /// <value>Line Channel secret.</value>
        [DataMember(Name = "channelSecret", IsRequired = true, EmitDefaultValue = true)]
        public string ChannelSecret { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class LineOAuthConfig {\n");
            sb.Append("  Enabled: ").Append(Enabled).Append("\n");
            sb.Append("  Provider: ").Append(Provider).Append("\n");
            sb.Append("  ChannelId: ").Append(ChannelId).Append("\n");
            sb.Append("  ChannelSecret: ").Append(ChannelSecret).Append("\n");
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
            return this.Equals(input as LineOAuthConfig);
        }

        /// <summary>
        /// Returns true if LineOAuthConfig instances are equal
        /// </summary>
        /// <param name="input">Instance of LineOAuthConfig to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LineOAuthConfig input)
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
                    this.ChannelId == input.ChannelId ||
                    (this.ChannelId != null &&
                    this.ChannelId.Equals(input.ChannelId))
                ) &&
                (
                    this.ChannelSecret == input.ChannelSecret ||
                    (this.ChannelSecret != null &&
                    this.ChannelSecret.Equals(input.ChannelSecret))
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
                if (this.ChannelId != null)
                {
                    hashCode = (hashCode * 59) + this.ChannelId.GetHashCode();
                }
                if (this.ChannelSecret != null)
                {
                    hashCode = (hashCode * 59) + this.ChannelSecret.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
