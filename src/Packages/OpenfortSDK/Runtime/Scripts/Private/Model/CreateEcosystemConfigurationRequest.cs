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
    /// CreateEcosystemConfigurationRequest
    /// </summary>
    [DataContract(Name = "CreateEcosystemConfigurationRequest")]
    public partial class CreateEcosystemConfigurationRequest : IEquatable<CreateEcosystemConfigurationRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEcosystemConfigurationRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateEcosystemConfigurationRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEcosystemConfigurationRequest" /> class.
        /// </summary>
        /// <param name="customDomain">Custom domain of the ecosystem. (required).</param>
        /// <param name="primaryColor">Primary color of the ecosystem. (required).</param>
        /// <param name="primaryColorForeground">Primary color foreground of the ecosystem. (required).</param>
        /// <param name="radius">Radius of the ecosystem. (required).</param>
        /// <param name="logoUrl">Logo URL of the ecosystem. (required).</param>
        public CreateEcosystemConfigurationRequest(string customDomain = default(string), string primaryColor = default(string), string primaryColorForeground = default(string), string radius = default(string), string logoUrl = default(string))
        {
            // to ensure "customDomain" is required (not null)
            if (customDomain == null)
            {
                throw new ArgumentNullException("customDomain is a required property for CreateEcosystemConfigurationRequest and cannot be null");
            }
            this.CustomDomain = customDomain;
            // to ensure "primaryColor" is required (not null)
            if (primaryColor == null)
            {
                throw new ArgumentNullException("primaryColor is a required property for CreateEcosystemConfigurationRequest and cannot be null");
            }
            this.PrimaryColor = primaryColor;
            // to ensure "primaryColorForeground" is required (not null)
            if (primaryColorForeground == null)
            {
                throw new ArgumentNullException("primaryColorForeground is a required property for CreateEcosystemConfigurationRequest and cannot be null");
            }
            this.PrimaryColorForeground = primaryColorForeground;
            // to ensure "radius" is required (not null)
            if (radius == null)
            {
                throw new ArgumentNullException("radius is a required property for CreateEcosystemConfigurationRequest and cannot be null");
            }
            this.Radius = radius;
            // to ensure "logoUrl" is required (not null)
            if (logoUrl == null)
            {
                throw new ArgumentNullException("logoUrl is a required property for CreateEcosystemConfigurationRequest and cannot be null");
            }
            this.LogoUrl = logoUrl;
        }

        /// <summary>
        /// Custom domain of the ecosystem.
        /// </summary>
        /// <value>Custom domain of the ecosystem.</value>
        [DataMember(Name = "customDomain", IsRequired = true, EmitDefaultValue = true)]
        public string CustomDomain { get; set; }

        /// <summary>
        /// Primary color of the ecosystem.
        /// </summary>
        /// <value>Primary color of the ecosystem.</value>
        [DataMember(Name = "primaryColor", IsRequired = true, EmitDefaultValue = true)]
        public string PrimaryColor { get; set; }

        /// <summary>
        /// Primary color foreground of the ecosystem.
        /// </summary>
        /// <value>Primary color foreground of the ecosystem.</value>
        [DataMember(Name = "primaryColorForeground", IsRequired = true, EmitDefaultValue = true)]
        public string PrimaryColorForeground { get; set; }

        /// <summary>
        /// Radius of the ecosystem.
        /// </summary>
        /// <value>Radius of the ecosystem.</value>
        [DataMember(Name = "radius", IsRequired = true, EmitDefaultValue = true)]
        public string Radius { get; set; }

        /// <summary>
        /// Logo URL of the ecosystem.
        /// </summary>
        /// <value>Logo URL of the ecosystem.</value>
        [DataMember(Name = "logoUrl", IsRequired = true, EmitDefaultValue = true)]
        public string LogoUrl { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateEcosystemConfigurationRequest {\n");
            sb.Append("  CustomDomain: ").Append(CustomDomain).Append("\n");
            sb.Append("  PrimaryColor: ").Append(PrimaryColor).Append("\n");
            sb.Append("  PrimaryColorForeground: ").Append(PrimaryColorForeground).Append("\n");
            sb.Append("  Radius: ").Append(Radius).Append("\n");
            sb.Append("  LogoUrl: ").Append(LogoUrl).Append("\n");
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
            return this.Equals(input as CreateEcosystemConfigurationRequest);
        }

        /// <summary>
        /// Returns true if CreateEcosystemConfigurationRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CreateEcosystemConfigurationRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateEcosystemConfigurationRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.CustomDomain == input.CustomDomain ||
                    (this.CustomDomain != null &&
                    this.CustomDomain.Equals(input.CustomDomain))
                ) &&
                (
                    this.PrimaryColor == input.PrimaryColor ||
                    (this.PrimaryColor != null &&
                    this.PrimaryColor.Equals(input.PrimaryColor))
                ) &&
                (
                    this.PrimaryColorForeground == input.PrimaryColorForeground ||
                    (this.PrimaryColorForeground != null &&
                    this.PrimaryColorForeground.Equals(input.PrimaryColorForeground))
                ) &&
                (
                    this.Radius == input.Radius ||
                    (this.Radius != null &&
                    this.Radius.Equals(input.Radius))
                ) &&
                (
                    this.LogoUrl == input.LogoUrl ||
                    (this.LogoUrl != null &&
                    this.LogoUrl.Equals(input.LogoUrl))
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
                if (this.CustomDomain != null)
                {
                    hashCode = (hashCode * 59) + this.CustomDomain.GetHashCode();
                }
                if (this.PrimaryColor != null)
                {
                    hashCode = (hashCode * 59) + this.PrimaryColor.GetHashCode();
                }
                if (this.PrimaryColorForeground != null)
                {
                    hashCode = (hashCode * 59) + this.PrimaryColorForeground.GetHashCode();
                }
                if (this.Radius != null)
                {
                    hashCode = (hashCode * 59) + this.Radius.GetHashCode();
                }
                if (this.LogoUrl != null)
                {
                    hashCode = (hashCode * 59) + this.LogoUrl.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
