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
    /// Plan
    /// </summary>
    [DataContract(Name = "Plan")]
    public partial class Plan : IEquatable<Plan>
    {
        /// <summary>
        /// Defines ChangeType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChangeTypeEnum
        {
            /// <summary>
            /// Enum Upgrade for value: upgrade
            /// </summary>
            [EnumMember(Value = "upgrade")]
            Upgrade = 1,

            /// <summary>
            /// Enum Downgrade for value: downgrade
            /// </summary>
            [EnumMember(Value = "downgrade")]
            Downgrade = 2,

            /// <summary>
            /// Enum None for value: none
            /// </summary>
            [EnumMember(Value = "none")]
            None = 3

        }


        /// <summary>
        /// Gets or Sets ChangeType
        /// </summary>
        [DataMember(Name = "change_type", IsRequired = true, EmitDefaultValue = true)]
        public ChangeTypeEnum ChangeType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Plan" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Plan() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Plan" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="price">price (required).</param>
        /// <param name="isCurrent">isCurrent (required).</param>
        /// <param name="changeType">changeType (required).</param>
        public Plan(string id = default(string), string name = default(string), double price = default(double), bool isCurrent = default(bool), ChangeTypeEnum changeType = default(ChangeTypeEnum))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for Plan and cannot be null");
            }
            this.Id = id;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for Plan and cannot be null");
            }
            this.Name = name;
            this.Price = price;
            this.IsCurrent = isCurrent;
            this.ChangeType = changeType;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [DataMember(Name = "price", IsRequired = true, EmitDefaultValue = true)]
        public double Price { get; set; }

        /// <summary>
        /// Gets or Sets IsCurrent
        /// </summary>
        [DataMember(Name = "is_current", IsRequired = true, EmitDefaultValue = true)]
        public bool IsCurrent { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Plan {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  IsCurrent: ").Append(IsCurrent).Append("\n");
            sb.Append("  ChangeType: ").Append(ChangeType).Append("\n");
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
            return this.Equals(input as Plan);
        }

        /// <summary>
        /// Returns true if Plan instances are equal
        /// </summary>
        /// <param name="input">Instance of Plan to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Plan input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) &&
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.Price == input.Price ||
                    this.Price.Equals(input.Price)
                ) &&
                (
                    this.IsCurrent == input.IsCurrent ||
                    this.IsCurrent.Equals(input.IsCurrent)
                ) &&
                (
                    this.ChangeType == input.ChangeType ||
                    this.ChangeType.Equals(input.ChangeType)
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
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Price.GetHashCode();
                hashCode = (hashCode * 59) + this.IsCurrent.GetHashCode();
                hashCode = (hashCode * 59) + this.ChangeType.GetHashCode();
                return hashCode;
            }
        }

    }

}
