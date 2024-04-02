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
    /// OAuthResponse
    /// </summary>
    [DataContract(Name = "OAuthResponse")]
    public partial class OAuthResponse : IEquatable<OAuthResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected OAuthResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthResponse" /> class.
        /// </summary>
        /// <param name="url">url (required).</param>
        /// <param name="key">key (required).</param>
        public OAuthResponse(string url = default(string), string key = default(string))
        {
            // to ensure "url" is required (not null)
            if (url == null)
            {
                throw new ArgumentNullException("url is a required property for OAuthResponse and cannot be null");
            }
            this.Url = url;
            // to ensure "key" is required (not null)
            if (key == null)
            {
                throw new ArgumentNullException("key is a required property for OAuthResponse and cannot be null");
            }
            this.Key = key;
        }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = true)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets Key
        /// </summary>
        [DataMember(Name = "key", IsRequired = true, EmitDefaultValue = true)]
        public string Key { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OAuthResponse {\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
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
            return this.Equals(input as OAuthResponse);
        }

        /// <summary>
        /// Returns true if OAuthResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of OAuthResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OAuthResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.Key == input.Key ||
                    (this.Key != null &&
                    this.Key.Equals(input.Key))
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
                if (this.Url != null)
                {
                    hashCode = (hashCode * 59) + this.Url.GetHashCode();
                }
                if (this.Key != null)
                {
                    hashCode = (hashCode * 59) + this.Key.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}