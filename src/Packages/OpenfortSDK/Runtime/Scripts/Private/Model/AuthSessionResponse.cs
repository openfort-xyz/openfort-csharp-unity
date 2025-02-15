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
    /// AuthSessionResponse
    /// </summary>
    [DataContract(Name = "AuthSessionResponse")]
    public partial class AuthSessionResponse : IEquatable<AuthSessionResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthSessionResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AuthSessionResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthSessionResponse" /> class.
        /// </summary>
        /// <param name="livemode">livemode (required).</param>
        /// <param name="projectId">projectId (required).</param>
        /// <param name="playerId">playerId (required).</param>
        /// <param name="issuer">issuer (required).</param>
        /// <param name="issuedAt">issuedAt (required).</param>
        /// <param name="expiration">expiration (required).</param>
        /// <param name="sessionId">sessionId (required).</param>
        public AuthSessionResponse(bool livemode = default(bool), string projectId = default(string), string playerId = default(string), string issuer = default(string), double issuedAt = default(double), double expiration = default(double), string sessionId = default(string))
        {
            this.Livemode = livemode;
            // to ensure "projectId" is required (not null)
            if (projectId == null)
            {
                throw new ArgumentNullException("projectId is a required property for AuthSessionResponse and cannot be null");
            }
            this.ProjectId = projectId;
            // to ensure "playerId" is required (not null)
            if (playerId == null)
            {
                throw new ArgumentNullException("playerId is a required property for AuthSessionResponse and cannot be null");
            }
            this.PlayerId = playerId;
            // to ensure "issuer" is required (not null)
            if (issuer == null)
            {
                throw new ArgumentNullException("issuer is a required property for AuthSessionResponse and cannot be null");
            }
            this.Issuer = issuer;
            this.IssuedAt = issuedAt;
            this.Expiration = expiration;
            // to ensure "sessionId" is required (not null)
            if (sessionId == null)
            {
                throw new ArgumentNullException("sessionId is a required property for AuthSessionResponse and cannot be null");
            }
            this.SessionId = sessionId;
        }

        /// <summary>
        /// Gets or Sets Livemode
        /// </summary>
        [DataMember(Name = "livemode", IsRequired = true, EmitDefaultValue = true)]
        public bool Livemode { get; set; }

        /// <summary>
        /// Gets or Sets ProjectId
        /// </summary>
        [DataMember(Name = "projectId", IsRequired = true, EmitDefaultValue = true)]
        public string ProjectId { get; set; }

        /// <summary>
        /// Gets or Sets PlayerId
        /// </summary>
        [DataMember(Name = "playerId", IsRequired = true, EmitDefaultValue = true)]
        public string PlayerId { get; set; }

        /// <summary>
        /// Gets or Sets Issuer
        /// </summary>
        [DataMember(Name = "issuer", IsRequired = true, EmitDefaultValue = true)]
        public string Issuer { get; set; }

        /// <summary>
        /// Gets or Sets IssuedAt
        /// </summary>
        [DataMember(Name = "issuedAt", IsRequired = true, EmitDefaultValue = true)]
        public double IssuedAt { get; set; }

        /// <summary>
        /// Gets or Sets Expiration
        /// </summary>
        [DataMember(Name = "expiration", IsRequired = true, EmitDefaultValue = true)]
        public double Expiration { get; set; }

        /// <summary>
        /// Gets or Sets SessionId
        /// </summary>
        [DataMember(Name = "sessionId", IsRequired = true, EmitDefaultValue = true)]
        public string SessionId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AuthSessionResponse {\n");
            sb.Append("  Livemode: ").Append(Livemode).Append("\n");
            sb.Append("  ProjectId: ").Append(ProjectId).Append("\n");
            sb.Append("  PlayerId: ").Append(PlayerId).Append("\n");
            sb.Append("  Issuer: ").Append(Issuer).Append("\n");
            sb.Append("  IssuedAt: ").Append(IssuedAt).Append("\n");
            sb.Append("  Expiration: ").Append(Expiration).Append("\n");
            sb.Append("  SessionId: ").Append(SessionId).Append("\n");
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
            return this.Equals(input as AuthSessionResponse);
        }

        /// <summary>
        /// Returns true if AuthSessionResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthSessionResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthSessionResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Livemode == input.Livemode ||
                    this.Livemode.Equals(input.Livemode)
                ) &&
                (
                    this.ProjectId == input.ProjectId ||
                    (this.ProjectId != null &&
                    this.ProjectId.Equals(input.ProjectId))
                ) &&
                (
                    this.PlayerId == input.PlayerId ||
                    (this.PlayerId != null &&
                    this.PlayerId.Equals(input.PlayerId))
                ) &&
                (
                    this.Issuer == input.Issuer ||
                    (this.Issuer != null &&
                    this.Issuer.Equals(input.Issuer))
                ) &&
                (
                    this.IssuedAt == input.IssuedAt ||
                    this.IssuedAt.Equals(input.IssuedAt)
                ) &&
                (
                    this.Expiration == input.Expiration ||
                    this.Expiration.Equals(input.Expiration)
                ) &&
                (
                    this.SessionId == input.SessionId ||
                    (this.SessionId != null &&
                    this.SessionId.Equals(input.SessionId))
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
                hashCode = (hashCode * 59) + this.Livemode.GetHashCode();
                if (this.ProjectId != null)
                {
                    hashCode = (hashCode * 59) + this.ProjectId.GetHashCode();
                }
                if (this.PlayerId != null)
                {
                    hashCode = (hashCode * 59) + this.PlayerId.GetHashCode();
                }
                if (this.Issuer != null)
                {
                    hashCode = (hashCode * 59) + this.Issuer.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.IssuedAt.GetHashCode();
                hashCode = (hashCode * 59) + this.Expiration.GetHashCode();
                if (this.SessionId != null)
                {
                    hashCode = (hashCode * 59) + this.SessionId.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
