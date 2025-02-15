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
    /// AbiType
    /// </summary>
    [DataContract(Name = "AbiType")]
    public partial class AbiType : IEquatable<AbiType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbiType" /> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="type">type.</param>
        /// <param name="indexed">indexed.</param>
        /// <param name="internalType">internalType.</param>
        /// <param name="components">components.</param>
        public AbiType(string name = default(string), string type = default(string), bool indexed = default(bool), Object internalType = default(Object), List<AbiType> components = default(List<AbiType>))
        {
            this.Name = name;
            this.Type = type;
            this.Indexed = indexed;
            this.InternalType = internalType;
            this.Components = components;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Indexed
        /// </summary>
        [DataMember(Name = "indexed", EmitDefaultValue = true)]
        public bool Indexed { get; set; }

        /// <summary>
        /// Gets or Sets InternalType
        /// </summary>
        [DataMember(Name = "internalType", EmitDefaultValue = true)]
        public Object InternalType { get; set; }

        /// <summary>
        /// Gets or Sets Components
        /// </summary>
        [DataMember(Name = "components", EmitDefaultValue = false)]
        public List<AbiType> Components { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AbiType {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Indexed: ").Append(Indexed).Append("\n");
            sb.Append("  InternalType: ").Append(InternalType).Append("\n");
            sb.Append("  Components: ").Append(Components).Append("\n");
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
            return this.Equals(input as AbiType);
        }

        /// <summary>
        /// Returns true if AbiType instances are equal
        /// </summary>
        /// <param name="input">Instance of AbiType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AbiType input)
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
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) &&
                (
                    this.Indexed == input.Indexed ||
                    this.Indexed.Equals(input.Indexed)
                ) &&
                (
                    this.InternalType == input.InternalType ||
                    (this.InternalType != null &&
                    this.InternalType.Equals(input.InternalType))
                ) &&
                (
                    this.Components == input.Components ||
                    this.Components != null &&
                    input.Components != null &&
                    this.Components.SequenceEqual(input.Components)
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
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Indexed.GetHashCode();
                if (this.InternalType != null)
                {
                    hashCode = (hashCode * 59) + this.InternalType.GetHashCode();
                }
                if (this.Components != null)
                {
                    hashCode = (hashCode * 59) + this.Components.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
