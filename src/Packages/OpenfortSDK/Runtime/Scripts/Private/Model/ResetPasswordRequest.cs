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
    /// ResetPasswordRequest
    /// </summary>
    [DataContract(Name = "ResetPasswordRequest")]
    public partial class ResetPasswordRequest : IEquatable<ResetPasswordRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResetPasswordRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ResetPasswordRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ResetPasswordRequest" /> class.
        /// </summary>
        /// <param name="email">The email address of the user. (required).</param>
        /// <param name="password">The new password of the user. (required).</param>
        /// <param name="state">Unique value to identify the request. It&#39;s used to mitigate CSRF attacks..</param>
        /// <param name="challenge">challenge.</param>
        public ResetPasswordRequest(string email = default(string), string password = default(string), string state = default(string), CodeChallengeVerify challenge = default(CodeChallengeVerify))
        {
            // to ensure "email" is required (not null)
            if (email == null)
            {
                throw new ArgumentNullException("email is a required property for ResetPasswordRequest and cannot be null");
            }
            this.Email = email;
            // to ensure "password" is required (not null)
            if (password == null)
            {
                throw new ArgumentNullException("password is a required property for ResetPasswordRequest and cannot be null");
            }
            this.Password = password;
            this.State = state;
            this.Challenge = challenge;
        }

        /// <summary>
        /// The email address of the user.
        /// </summary>
        /// <value>The email address of the user.</value>
        /// <example>&quot;user@email.com&quot;</example>
        [DataMember(Name = "email", IsRequired = true, EmitDefaultValue = true)]
        public string Email { get; set; }

        /// <summary>
        /// The new password of the user.
        /// </summary>
        /// <value>The new password of the user.</value>
        /// <example>&quot;password&quot;</example>
        [DataMember(Name = "password", IsRequired = true, EmitDefaultValue = true)]
        public string Password { get; set; }

        /// <summary>
        /// Unique value to identify the request. It&#39;s used to mitigate CSRF attacks.
        /// </summary>
        /// <value>Unique value to identify the request. It&#39;s used to mitigate CSRF attacks.</value>
        /// <example>&quot;515151&quot;</example>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        /// <summary>
        /// Gets or Sets Challenge
        /// </summary>
        [DataMember(Name = "challenge", EmitDefaultValue = false)]
        public CodeChallengeVerify Challenge { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ResetPasswordRequest {\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Challenge: ").Append(Challenge).Append("\n");
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
            return this.Equals(input as ResetPasswordRequest);
        }

        /// <summary>
        /// Returns true if ResetPasswordRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of ResetPasswordRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ResetPasswordRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) &&
                (
                    this.Password == input.Password ||
                    (this.Password != null &&
                    this.Password.Equals(input.Password))
                ) &&
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
                ) &&
                (
                    this.Challenge == input.Challenge ||
                    (this.Challenge != null &&
                    this.Challenge.Equals(input.Challenge))
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
                if (this.Email != null)
                {
                    hashCode = (hashCode * 59) + this.Email.GetHashCode();
                }
                if (this.Password != null)
                {
                    hashCode = (hashCode * 59) + this.Password.GetHashCode();
                }
                if (this.State != null)
                {
                    hashCode = (hashCode * 59) + this.State.GetHashCode();
                }
                if (this.Challenge != null)
                {
                    hashCode = (hashCode * 59) + this.Challenge.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
