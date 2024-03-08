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
    /// AuthResponse
    /// </summary>
    [DataContract(Name = "AuthResponse")]
    public partial class AuthResponse : IEquatable<AuthResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AuthResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthResponse" /> class.
        /// </summary>
        /// <param name="player">player (required).</param>
        /// <param name="token">JWT access token. (required).</param>
        /// <param name="refreshToken">Refresh token. (required).</param>
        public AuthResponse(AuthPlayerResponse player = default(AuthPlayerResponse), string token = default(string), string refreshToken = default(string))
        {
            // to ensure "player" is required (not null)
            if (player == null)
            {
                throw new ArgumentNullException("player is a required property for AuthResponse and cannot be null");
            }
            this.Player = player;
            // to ensure "token" is required (not null)
            if (token == null)
            {
                throw new ArgumentNullException("token is a required property for AuthResponse and cannot be null");
            }
            this.Token = token;
            // to ensure "refreshToken" is required (not null)
            if (refreshToken == null)
            {
                throw new ArgumentNullException("refreshToken is a required property for AuthResponse and cannot be null");
            }
            this.RefreshToken = refreshToken;
        }

        /// <summary>
        /// Gets or Sets Player
        /// </summary>
        [DataMember(Name = "player", IsRequired = true, EmitDefaultValue = true)]
        public AuthPlayerResponse Player { get; set; }

        /// <summary>
        /// JWT access token.
        /// </summary>
        /// <value>JWT access token.</value>
        [DataMember(Name = "token", IsRequired = true, EmitDefaultValue = true)]
        public string Token { get; set; }

        /// <summary>
        /// Refresh token.
        /// </summary>
        /// <value>Refresh token.</value>
        [DataMember(Name = "refreshToken", IsRequired = true, EmitDefaultValue = true)]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AuthResponse {\n");
            sb.Append("  Player: ").Append(Player).Append("\n");
            sb.Append("  Token: ").Append(Token).Append("\n");
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
            return this.Equals(input as AuthResponse);
        }

        /// <summary>
        /// Returns true if AuthResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Player == input.Player ||
                    (this.Player != null &&
                    this.Player.Equals(input.Player))
                ) && 
                (
                    this.Token == input.Token ||
                    (this.Token != null &&
                    this.Token.Equals(input.Token))
                ) && 
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
                if (this.Player != null)
                {
                    hashCode = (hashCode * 59) + this.Player.GetHashCode();
                }
                if (this.Token != null)
                {
                    hashCode = (hashCode * 59) + this.Token.GetHashCode();
                }
                if (this.RefreshToken != null)
                {
                    hashCode = (hashCode * 59) + this.RefreshToken.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
