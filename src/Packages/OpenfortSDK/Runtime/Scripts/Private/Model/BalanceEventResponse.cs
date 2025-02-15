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
    /// BalanceEventResponse
    /// </summary>
    [DataContract(Name = "BalanceEventResponse")]
    public partial class BalanceEventResponse : IEquatable<BalanceEventResponse>
    {

        /// <summary>
        /// Gets or Sets Object
        /// </summary>
        [DataMember(Name = "object", IsRequired = true, EmitDefaultValue = true)]
        public EntityTypeEVENT Object { get; set; }

        /// <summary>
        /// Gets or Sets Topic
        /// </summary>
        [DataMember(Name = "topic", IsRequired = true, EmitDefaultValue = true)]
        public APITopicBALANCEPROJECT Topic { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceEventResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BalanceEventResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceEventResponse" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="_object">_object (required).</param>
        /// <param name="createdAt">createdAt (required).</param>
        /// <param name="topic">topic (required).</param>
        /// <param name="threshold">threshold (required).</param>
        public BalanceEventResponse(string id = default(string), EntityTypeEVENT _object = default(EntityTypeEVENT), int createdAt = default(int), APITopicBALANCEPROJECT topic = default(APITopicBALANCEPROJECT), string threshold = default(string))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for BalanceEventResponse and cannot be null");
            }
            this.Id = id;
            this.Object = _object;
            this.CreatedAt = createdAt;
            this.Topic = topic;
            // to ensure "threshold" is required (not null)
            if (threshold == null)
            {
                throw new ArgumentNullException("threshold is a required property for BalanceEventResponse and cannot be null");
            }
            this.Threshold = threshold;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "createdAt", IsRequired = true, EmitDefaultValue = true)]
        public int CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets Threshold
        /// </summary>
        [DataMember(Name = "threshold", IsRequired = true, EmitDefaultValue = true)]
        public string Threshold { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BalanceEventResponse {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Object: ").Append(Object).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Topic: ").Append(Topic).Append("\n");
            sb.Append("  Threshold: ").Append(Threshold).Append("\n");
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
            return this.Equals(input as BalanceEventResponse);
        }

        /// <summary>
        /// Returns true if BalanceEventResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of BalanceEventResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BalanceEventResponse input)
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
                    this.Object == input.Object ||
                    this.Object.Equals(input.Object)
                ) &&
                (
                    this.CreatedAt == input.CreatedAt ||
                    this.CreatedAt.Equals(input.CreatedAt)
                ) &&
                (
                    this.Topic == input.Topic ||
                    this.Topic.Equals(input.Topic)
                ) &&
                (
                    this.Threshold == input.Threshold ||
                    (this.Threshold != null &&
                    this.Threshold.Equals(input.Threshold))
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
                hashCode = (hashCode * 59) + this.Object.GetHashCode();
                hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                hashCode = (hashCode * 59) + this.Topic.GetHashCode();
                if (this.Threshold != null)
                {
                    hashCode = (hashCode * 59) + this.Threshold.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
