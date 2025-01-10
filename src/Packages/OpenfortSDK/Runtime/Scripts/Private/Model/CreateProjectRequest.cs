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
    /// CreateProjectRequest
    /// </summary>
    [DataContract(Name = "CreateProjectRequest")]
    public partial class CreateProjectRequest : IEquatable<CreateProjectRequest>
    {

        /// <summary>
        /// Gets or Sets PkPolicy
        /// </summary>
        [DataMember(Name = "pkPolicy", EmitDefaultValue = false)]
        public PrivateKeyPolicy? PkPolicy { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProjectRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateProjectRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProjectRequest" /> class.
        /// </summary>
        /// <param name="name">Name of the project. (required).</param>
        /// <param name="pkPolicy">pkPolicy.</param>
        public CreateProjectRequest(string name = default(string), PrivateKeyPolicy? pkPolicy = default(PrivateKeyPolicy?))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for CreateProjectRequest and cannot be null");
            }
            this.Name = name;
            this.PkPolicy = pkPolicy;
        }

        /// <summary>
        /// Name of the project.
        /// </summary>
        /// <value>Name of the project.</value>
        /// <example>&quot;My Project&quot;</example>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateProjectRequest {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  PkPolicy: ").Append(PkPolicy).Append("\n");
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
            return this.Equals(input as CreateProjectRequest);
        }

        /// <summary>
        /// Returns true if CreateProjectRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CreateProjectRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateProjectRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.PkPolicy == input.PkPolicy ||
                    this.PkPolicy.Equals(input.PkPolicy)
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.PkPolicy.GetHashCode();
                return hashCode;
            }
        }

    }

}
