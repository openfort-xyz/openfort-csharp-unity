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
    /// PlayerListQueries
    /// </summary>
    [DataContract(Name = "PlayerListQueries")]
    public partial class PlayerListQueries : IEquatable<PlayerListQueries>
    {

        /// <summary>
        /// Gets or Sets Order
        /// </summary>
        [DataMember(Name = "order", EmitDefaultValue = false)]
        public SortOrder? Order { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerListQueries" /> class.
        /// </summary>
        /// <param name="limit">Specifies the maximum number of records to return..</param>
        /// <param name="skip">Specifies the offset for the first records to return..</param>
        /// <param name="order">order.</param>
        /// <param name="expand">Specifies the fields to expand in the response..</param>
        /// <param name="name">Filter by player name..</param>
        public PlayerListQueries(int limit = default(int), int skip = default(int), SortOrder? order = default(SortOrder?), List<PlayerResponseExpandable> expand = default(List<PlayerResponseExpandable>), string name = default(string))
        {
            this.Limit = limit;
            this.Skip = skip;
            this.Order = order;
            this.Expand = expand;
            this.Name = name;
        }

        /// <summary>
        /// Specifies the maximum number of records to return.
        /// </summary>
        /// <value>Specifies the maximum number of records to return.</value>
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int Limit { get; set; }

        /// <summary>
        /// Specifies the offset for the first records to return.
        /// </summary>
        /// <value>Specifies the offset for the first records to return.</value>
        [DataMember(Name = "skip", EmitDefaultValue = false)]
        public int Skip { get; set; }

        /// <summary>
        /// Specifies the fields to expand in the response.
        /// </summary>
        /// <value>Specifies the fields to expand in the response.</value>
        [DataMember(Name = "expand", EmitDefaultValue = false)]
        public List<PlayerResponseExpandable> Expand { get; set; }

        /// <summary>
        /// Filter by player name.
        /// </summary>
        /// <value>Filter by player name.</value>
        /// <example>&quot;John&quot;</example>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PlayerListQueries {\n");
            sb.Append("  Limit: ").Append(Limit).Append("\n");
            sb.Append("  Skip: ").Append(Skip).Append("\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
            sb.Append("  Expand: ").Append(Expand).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
            return this.Equals(input as PlayerListQueries);
        }

        /// <summary>
        /// Returns true if PlayerListQueries instances are equal
        /// </summary>
        /// <param name="input">Instance of PlayerListQueries to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PlayerListQueries input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Limit == input.Limit ||
                    this.Limit.Equals(input.Limit)
                ) &&
                (
                    this.Skip == input.Skip ||
                    this.Skip.Equals(input.Skip)
                ) &&
                (
                    this.Order == input.Order ||
                    this.Order.Equals(input.Order)
                ) &&
                (
                    this.Expand == input.Expand ||
                    this.Expand != null &&
                    input.Expand != null &&
                    this.Expand.SequenceEqual(input.Expand)
                ) &&
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
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
                hashCode = (hashCode * 59) + this.Limit.GetHashCode();
                hashCode = (hashCode * 59) + this.Skip.GetHashCode();
                hashCode = (hashCode * 59) + this.Order.GetHashCode();
                if (this.Expand != null)
                {
                    hashCode = (hashCode * 59) + this.Expand.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
