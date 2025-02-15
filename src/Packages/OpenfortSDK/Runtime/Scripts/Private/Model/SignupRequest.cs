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
    /// SignupRequest
    /// </summary>
    [DataContract(Name = "SignupRequest")]
    public partial class SignupRequest : IEquatable<SignupRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignupRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SignupRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SignupRequest" /> class.
        /// </summary>
        /// <param name="email">The email address of the player. (required).</param>
        /// <param name="password">The password of the player. (required).</param>
        /// <param name="name">The name of the player..</param>
        /// <param name="description">The description of the player..</param>
        public SignupRequest(string email = default(string), string password = default(string), string name = default(string), string description = default(string))
        {
            // to ensure "email" is required (not null)
            if (email == null)
            {
                throw new ArgumentNullException("email is a required property for SignupRequest and cannot be null");
            }
            this.Email = email;
            // to ensure "password" is required (not null)
            if (password == null)
            {
                throw new ArgumentNullException("password is a required property for SignupRequest and cannot be null");
            }
            this.Password = password;
            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// The email address of the player.
        /// </summary>
        /// <value>The email address of the player.</value>
        /// <example>&quot;user@email.com&quot;</example>
        [DataMember(Name = "email", IsRequired = true, EmitDefaultValue = true)]
        public string Email { get; set; }

        /// <summary>
        /// The password of the player.
        /// </summary>
        /// <value>The password of the player.</value>
        /// <example>&quot;password&quot;</example>
        [DataMember(Name = "password", IsRequired = true, EmitDefaultValue = true)]
        public string Password { get; set; }

        /// <summary>
        /// The name of the player.
        /// </summary>
        /// <value>The name of the player.</value>
        /// <example>&quot;John Doe&quot;</example>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// The description of the player.
        /// </summary>
        /// <value>The description of the player.</value>
        /// <example>&quot;I&#39;m a developer.&quot;</example>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SignupRequest {\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return this.Equals(input as SignupRequest);
        }

        /// <summary>
        /// Returns true if SignupRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of SignupRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SignupRequest input)
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
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
