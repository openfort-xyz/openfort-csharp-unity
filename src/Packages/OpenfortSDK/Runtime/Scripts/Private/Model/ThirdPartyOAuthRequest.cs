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
    /// ThirdPartyOAuthRequest
    /// </summary>
    [DataContract(Name = "ThirdPartyOAuthRequest")]
    public partial class ThirdPartyOAuthRequest : IEquatable<ThirdPartyOAuthRequest>
    {

        /// <summary>
        /// Gets or Sets Provider
        /// </summary>
        [DataMember(Name = "provider", IsRequired = true, EmitDefaultValue = true)]
        public ThirdPartyOAuthProvider Provider { get; set; }

        /// <summary>
        /// Gets or Sets TokenType
        /// </summary>
        [DataMember(Name = "tokenType", IsRequired = true, EmitDefaultValue = true)]
        public TokenType TokenType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ThirdPartyOAuthRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ThirdPartyOAuthRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ThirdPartyOAuthRequest" /> class.
        /// </summary>
        /// <param name="provider">provider (required).</param>
        /// <param name="token">Token to be verified (required).</param>
        /// <param name="tokenType">tokenType (required).</param>
        public ThirdPartyOAuthRequest(ThirdPartyOAuthProvider provider = default(ThirdPartyOAuthProvider), string token = default(string), TokenType tokenType = default(TokenType))
        {
            this.Provider = provider;
            // to ensure "token" is required (not null)
            if (token == null)
            {
                throw new ArgumentNullException("token is a required property for ThirdPartyOAuthRequest and cannot be null");
            }
            this.Token = token;
            this.TokenType = tokenType;
        }

        /// <summary>
        /// Token to be verified
        /// </summary>
        /// <value>Token to be verified</value>
        /// <example>&quot;eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9&quot;</example>
        [DataMember(Name = "token", IsRequired = true, EmitDefaultValue = true)]
        public string Token { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ThirdPartyOAuthRequest {\n");
            sb.Append("  Provider: ").Append(Provider).Append("\n");
            sb.Append("  Token: ").Append(Token).Append("\n");
            sb.Append("  TokenType: ").Append(TokenType).Append("\n");
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
            return this.Equals(input as ThirdPartyOAuthRequest);
        }

        /// <summary>
        /// Returns true if ThirdPartyOAuthRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of ThirdPartyOAuthRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ThirdPartyOAuthRequest input)
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
                    this.Token == input.Token ||
                    (this.Token != null &&
                    this.Token.Equals(input.Token))
                ) &&
                (
                    this.TokenType == input.TokenType ||
                    this.TokenType.Equals(input.TokenType)
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
                if (this.Token != null)
                {
                    hashCode = (hashCode * 59) + this.Token.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.TokenType.GetHashCode();
                return hashCode;
            }
        }

    }

}
