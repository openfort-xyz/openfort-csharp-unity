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
    /// UpdateProjectApiKeyRequest
    /// </summary>
    [DataContract(Name = "UpdateProjectApiKeyRequest")]
    public partial class UpdateProjectApiKeyRequest : IEquatable<UpdateProjectApiKeyRequest>
    {

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public ApiKeyType Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProjectApiKeyRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected UpdateProjectApiKeyRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProjectApiKeyRequest" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="uuid">The API key to update. (required).</param>
        /// <param name="useForWebhooks">Whether key to use to sign webhooks..</param>
        public UpdateProjectApiKeyRequest(ApiKeyType type = default(ApiKeyType), string uuid = default(string), bool useForWebhooks = default(bool))
        {
            this.Type = type;
            // to ensure "uuid" is required (not null)
            if (uuid == null)
            {
                throw new ArgumentNullException("uuid is a required property for UpdateProjectApiKeyRequest and cannot be null");
            }
            this.Uuid = uuid;
            this.UseForWebhooks = useForWebhooks;
        }

        /// <summary>
        /// The API key to update.
        /// </summary>
        /// <value>The API key to update.</value>
        /// <example>&quot;1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef&quot;</example>
        [DataMember(Name = "uuid", IsRequired = true, EmitDefaultValue = true)]
        public string Uuid { get; set; }

        /// <summary>
        /// Whether key to use to sign webhooks.
        /// </summary>
        /// <value>Whether key to use to sign webhooks.</value>
        /// <example>true</example>
        [DataMember(Name = "use_for_webhooks", EmitDefaultValue = true)]
        public bool UseForWebhooks { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UpdateProjectApiKeyRequest {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Uuid: ").Append(Uuid).Append("\n");
            sb.Append("  UseForWebhooks: ").Append(UseForWebhooks).Append("\n");
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
            return this.Equals(input as UpdateProjectApiKeyRequest);
        }

        /// <summary>
        /// Returns true if UpdateProjectApiKeyRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdateProjectApiKeyRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateProjectApiKeyRequest input)
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
                    this.Uuid == input.Uuid ||
                    (this.Uuid != null &&
                    this.Uuid.Equals(input.Uuid))
                ) &&
                (
                    this.UseForWebhooks == input.UseForWebhooks ||
                    this.UseForWebhooks.Equals(input.UseForWebhooks)
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
                if (this.Uuid != null)
                {
                    hashCode = (hashCode * 59) + this.Uuid.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.UseForWebhooks.GetHashCode();
                return hashCode;
            }
        }

    }

}
