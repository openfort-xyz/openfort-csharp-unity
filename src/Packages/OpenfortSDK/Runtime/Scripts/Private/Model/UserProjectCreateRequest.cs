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
    /// UserProjectCreateRequest
    /// </summary>
    [DataContract(Name = "UserProjectCreateRequest")]
    public partial class UserProjectCreateRequest : IEquatable<UserProjectCreateRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProjectCreateRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected UserProjectCreateRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProjectCreateRequest" /> class.
        /// </summary>
        /// <param name="role">role.</param>
        /// <param name="email">The email of the user to add. (required).</param>
        public UserProjectCreateRequest(UserProjectCreateRequestRole role = default(UserProjectCreateRequestRole), string email = default(string))
        {
            // to ensure "email" is required (not null)
            if (email == null)
            {
                throw new ArgumentNullException("email is a required property for UserProjectCreateRequest and cannot be null");
            }
            this.Email = email;
            this.Role = role;
        }

        /// <summary>
        /// Gets or Sets Role
        /// </summary>
        [DataMember(Name = "role", EmitDefaultValue = false)]
        public UserProjectCreateRequestRole Role { get; set; }

        /// <summary>
        /// The email of the user to add.
        /// </summary>
        /// <value>The email of the user to add.</value>
        /// <example>&quot;name@company.com&quot;</example>
        [DataMember(Name = "email", IsRequired = true, EmitDefaultValue = true)]
        public string Email { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserProjectCreateRequest {\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
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
            return this.Equals(input as UserProjectCreateRequest);
        }

        /// <summary>
        /// Returns true if UserProjectCreateRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of UserProjectCreateRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserProjectCreateRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Role == input.Role ||
                    (this.Role != null &&
                    this.Role.Equals(input.Role))
                ) &&
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
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
                if (this.Role != null)
                {
                    hashCode = (hashCode * 59) + this.Role.GetHashCode();
                }
                if (this.Email != null)
                {
                    hashCode = (hashCode * 59) + this.Email.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
