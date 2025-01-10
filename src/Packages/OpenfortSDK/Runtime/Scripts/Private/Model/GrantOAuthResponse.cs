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
    /// GrantOAuthResponse
    /// </summary>
    [DataContract(Name = "GrantOAuthResponse")]
    public partial class GrantOAuthResponse : IEquatable<GrantOAuthResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GrantOAuthResponse" /> class.
        /// </summary>
        /// <param name="authorizationCode">authorizationCode.</param>
        /// <param name="accessToken">accessToken.</param>
        /// <param name="refreshToken">refreshToken.</param>
        /// <param name="playerId">playerId.</param>
        public GrantOAuthResponse(string authorizationCode = default(string), string accessToken = default(string), string refreshToken = default(string), string playerId = default(string))
        {
            this.AuthorizationCode = authorizationCode;
            this.AccessToken = accessToken;
            this.RefreshToken = refreshToken;
            this.PlayerId = playerId;
        }

        /// <summary>
        /// Gets or Sets AuthorizationCode
        /// </summary>
        [DataMember(Name = "authorizationCode", EmitDefaultValue = false)]
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Gets or Sets AccessToken
        /// </summary>
        [DataMember(Name = "accessToken", EmitDefaultValue = false)]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or Sets RefreshToken
        /// </summary>
        [DataMember(Name = "refreshToken", EmitDefaultValue = false)]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or Sets PlayerId
        /// </summary>
        [DataMember(Name = "playerId", EmitDefaultValue = false)]
        public string PlayerId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GrantOAuthResponse {\n");
            sb.Append("  AuthorizationCode: ").Append(AuthorizationCode).Append("\n");
            sb.Append("  AccessToken: ").Append(AccessToken).Append("\n");
            sb.Append("  RefreshToken: ").Append(RefreshToken).Append("\n");
            sb.Append("  PlayerId: ").Append(PlayerId).Append("\n");
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
            return this.Equals(input as GrantOAuthResponse);
        }

        /// <summary>
        /// Returns true if GrantOAuthResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of GrantOAuthResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GrantOAuthResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.AuthorizationCode == input.AuthorizationCode ||
                    (this.AuthorizationCode != null &&
                    this.AuthorizationCode.Equals(input.AuthorizationCode))
                ) &&
                (
                    this.AccessToken == input.AccessToken ||
                    (this.AccessToken != null &&
                    this.AccessToken.Equals(input.AccessToken))
                ) &&
                (
                    this.RefreshToken == input.RefreshToken ||
                    (this.RefreshToken != null &&
                    this.RefreshToken.Equals(input.RefreshToken))
                ) &&
                (
                    this.PlayerId == input.PlayerId ||
                    (this.PlayerId != null &&
                    this.PlayerId.Equals(input.PlayerId))
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
                if (this.AuthorizationCode != null)
                {
                    hashCode = (hashCode * 59) + this.AuthorizationCode.GetHashCode();
                }
                if (this.AccessToken != null)
                {
                    hashCode = (hashCode * 59) + this.AccessToken.GetHashCode();
                }
                if (this.RefreshToken != null)
                {
                    hashCode = (hashCode * 59) + this.RefreshToken.GetHashCode();
                }
                if (this.PlayerId != null)
                {
                    hashCode = (hashCode * 59) + this.PlayerId.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
