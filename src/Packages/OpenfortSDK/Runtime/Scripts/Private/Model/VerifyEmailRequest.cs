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
    /// VerifyEmailRequest
    /// </summary>
    [DataContract(Name = "VerifyEmailRequest")]
    public partial class VerifyEmailRequest : IEquatable<VerifyEmailRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VerifyEmailRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected VerifyEmailRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="VerifyEmailRequest" /> class.
        /// </summary>
        /// <param name="email">The email address of the user. (required).</param>
        /// <param name="token">Unique value to identify the request. Obtained from the email. (required).</param>
        /// <param name="challenge">challenge.</param>
        public VerifyEmailRequest(string email = default(string), string token = default(string), CodeChallengeVerify challenge = default(CodeChallengeVerify))
        {
            // to ensure "email" is required (not null)
            if (email == null)
            {
                throw new ArgumentNullException("email is a required property for VerifyEmailRequest and cannot be null");
            }
            this.Email = email;
            // to ensure "token" is required (not null)
            if (token == null)
            {
                throw new ArgumentNullException("token is a required property for VerifyEmailRequest and cannot be null");
            }
            this.Token = token;
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
        /// Unique value to identify the request. Obtained from the email.
        /// </summary>
        /// <value>Unique value to identify the request. Obtained from the email.</value>
        /// <example>&quot;515151&quot;</example>
        [DataMember(Name = "token", IsRequired = true, EmitDefaultValue = true)]
        public string Token { get; set; }

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
            sb.Append("class VerifyEmailRequest {\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Token: ").Append(Token).Append("\n");
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
            return this.Equals(input as VerifyEmailRequest);
        }

        /// <summary>
        /// Returns true if VerifyEmailRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of VerifyEmailRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VerifyEmailRequest input)
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
                    this.Token == input.Token ||
                    (this.Token != null &&
                    this.Token.Equals(input.Token))
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
                if (this.Token != null)
                {
                    hashCode = (hashCode * 59) + this.Token.GetHashCode();
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
