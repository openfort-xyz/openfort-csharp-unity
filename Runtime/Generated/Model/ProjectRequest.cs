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
    /// ProjectRequest
    /// </summary>
    [DataContract(Name = "ProjectRequest")]
    public partial class ProjectRequest : IEquatable<ProjectRequest>
    {

        /// <summary>
        /// Gets or Sets PkPolicy
        /// </summary>
        [DataMember(Name = "pkPolicy", EmitDefaultValue = false)]
        public PKPolicy? PkPolicy { get; set; }

        /// <summary>
        /// Gets or Sets PkLocation
        /// </summary>
        [DataMember(Name = "pkLocation", EmitDefaultValue = false)]
        public PKLocation? PkLocation { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ProjectRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectRequest" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="pkPolicy">pkPolicy.</param>
        /// <param name="pkLocation">pkLocation.</param>
        public ProjectRequest(string name = default(string), PKPolicy? pkPolicy = default(PKPolicy?), PKLocation? pkLocation = default(PKLocation?))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for ProjectRequest and cannot be null");
            }
            this.Name = name;
            this.PkPolicy = pkPolicy;
            this.PkLocation = pkLocation;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ProjectRequest {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  PkPolicy: ").Append(PkPolicy).Append("\n");
            sb.Append("  PkLocation: ").Append(PkLocation).Append("\n");
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
            return this.Equals(input as ProjectRequest);
        }

        /// <summary>
        /// Returns true if ProjectRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of ProjectRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProjectRequest input)
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
                ) && 
                (
                    this.PkLocation == input.PkLocation ||
                    this.PkLocation.Equals(input.PkLocation)
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
                hashCode = (hashCode * 59) + this.PkLocation.GetHashCode();
                return hashCode;
            }
        }

    }

}