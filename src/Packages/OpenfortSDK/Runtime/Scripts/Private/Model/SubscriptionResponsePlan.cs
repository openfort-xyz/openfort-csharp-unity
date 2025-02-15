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
    /// SubscriptionResponsePlan
    /// </summary>
    [DataContract(Name = "SubscriptionResponse_plan")]
    public partial class SubscriptionResponsePlan : IEquatable<SubscriptionResponsePlan>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionResponsePlan" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SubscriptionResponsePlan() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionResponsePlan" /> class.
        /// </summary>
        /// <param name="price">price (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="id">id (required).</param>
        public SubscriptionResponsePlan(double price = default(double), string name = default(string), string id = default(string))
        {
            this.Price = price;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for SubscriptionResponsePlan and cannot be null");
            }
            this.Name = name;
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for SubscriptionResponsePlan and cannot be null");
            }
            this.Id = id;
        }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [DataMember(Name = "price", IsRequired = true, EmitDefaultValue = true)]
        public double Price { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SubscriptionResponsePlan {\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
            return this.Equals(input as SubscriptionResponsePlan);
        }

        /// <summary>
        /// Returns true if SubscriptionResponsePlan instances are equal
        /// </summary>
        /// <param name="input">Instance of SubscriptionResponsePlan to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SubscriptionResponsePlan input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Price == input.Price ||
                    this.Price.Equals(input.Price)
                ) &&
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
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
                hashCode = (hashCode * 59) + this.Price.GetHashCode();
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
