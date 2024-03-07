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
    /// RefreshTokenRequest
    /// </summary>
    [DataContract(Name = "RefreshTokenRequest")]
    public partial class RefreshTokenRequest : IEquatable<RefreshTokenRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefreshTokenRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RefreshTokenRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RefreshTokenRequest" /> class.
        /// </summary>
        /// <param name="refreshToken">Specifies the session. (required).</param>
        public RefreshTokenRequest(string refreshToken = default(string))
        {
            // to ensure "refreshToken" is required (not null)
            if (refreshToken == null)
            {
                throw new ArgumentNullException("refreshToken is a required property for RefreshTokenRequest and cannot be null");
            }
            this.RefreshToken = refreshToken;
        }

        /// <summary>
        /// Specifies the session.
        /// </summary>
        /// <value>Specifies the session.</value>
        /// <example>&quot;eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9&quot;</example>
        [DataMember(Name = "refreshToken", IsRequired = true, EmitDefaultValue = true)]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RefreshTokenRequest {\n");
            sb.Append("  RefreshToken: ").Append(RefreshToken).Append("\n");
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
            return this.Equals(input as RefreshTokenRequest);
        }

        /// <summary>
        /// Returns true if RefreshTokenRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of RefreshTokenRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RefreshTokenRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.RefreshToken == input.RefreshToken ||
                    (this.RefreshToken != null &&
                    this.RefreshToken.Equals(input.RefreshToken))
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
                if (this.RefreshToken != null)
                {
                    hashCode = (hashCode * 59) + this.RefreshToken.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
