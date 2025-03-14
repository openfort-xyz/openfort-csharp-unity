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
    /// GasPerIntervalLimitPolicyRuleResponse
    /// </summary>
    [DataContract(Name = "GasPerIntervalLimitPolicyRuleResponse")]
    public partial class GasPerIntervalLimitPolicyRuleResponse : IEquatable<GasPerIntervalLimitPolicyRuleResponse>
    {

        /// <summary>
        /// Gets or Sets Object
        /// </summary>
        [DataMember(Name = "object", IsRequired = true, EmitDefaultValue = true)]
        public EntityTypePOLICYRULE Object { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public PolicyRuleTypeRATELIMIT Type { get; set; }

        /// <summary>
        /// Gets or Sets FunctionName
        /// </summary>
        [DataMember(Name = "functionName", IsRequired = true, EmitDefaultValue = true)]
        public PolicyRateLimitGASPERINTERVAL FunctionName { get; set; }

        /// <summary>
        /// Gets or Sets TimeIntervalType
        /// </summary>
        [DataMember(Name = "timeIntervalType", IsRequired = true, EmitDefaultValue = true)]
        public TimeIntervalType TimeIntervalType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GasPerIntervalLimitPolicyRuleResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GasPerIntervalLimitPolicyRuleResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GasPerIntervalLimitPolicyRuleResponse" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="_object">_object (required).</param>
        /// <param name="createdAt">createdAt (required).</param>
        /// <param name="type">type (required).</param>
        /// <param name="functionName">functionName (required).</param>
        /// <param name="gasLimit">gasLimit (required).</param>
        /// <param name="timeIntervalType">timeIntervalType (required).</param>
        /// <param name="timeIntervalValue">timeIntervalValue (required).</param>
        public GasPerIntervalLimitPolicyRuleResponse(string id = default(string), EntityTypePOLICYRULE _object = default(EntityTypePOLICYRULE), int createdAt = default(int), PolicyRuleTypeRATELIMIT type = default(PolicyRuleTypeRATELIMIT), PolicyRateLimitGASPERINTERVAL functionName = default(PolicyRateLimitGASPERINTERVAL), string gasLimit = default(string), TimeIntervalType timeIntervalType = default(TimeIntervalType), int timeIntervalValue = default(int))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for GasPerIntervalLimitPolicyRuleResponse and cannot be null");
            }
            this.Id = id;
            this.Object = _object;
            this.CreatedAt = createdAt;
            this.Type = type;
            this.FunctionName = functionName;
            // to ensure "gasLimit" is required (not null)
            if (gasLimit == null)
            {
                throw new ArgumentNullException("gasLimit is a required property for GasPerIntervalLimitPolicyRuleResponse and cannot be null");
            }
            this.GasLimit = gasLimit;
            this.TimeIntervalType = timeIntervalType;
            this.TimeIntervalValue = timeIntervalValue;
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
        /// Gets or Sets GasLimit
        /// </summary>
        [DataMember(Name = "gasLimit", IsRequired = true, EmitDefaultValue = true)]
        public string GasLimit { get; set; }

        /// <summary>
        /// Gets or Sets TimeIntervalValue
        /// </summary>
        [DataMember(Name = "timeIntervalValue", IsRequired = true, EmitDefaultValue = true)]
        public int TimeIntervalValue { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GasPerIntervalLimitPolicyRuleResponse {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Object: ").Append(Object).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  FunctionName: ").Append(FunctionName).Append("\n");
            sb.Append("  GasLimit: ").Append(GasLimit).Append("\n");
            sb.Append("  TimeIntervalType: ").Append(TimeIntervalType).Append("\n");
            sb.Append("  TimeIntervalValue: ").Append(TimeIntervalValue).Append("\n");
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
            return this.Equals(input as GasPerIntervalLimitPolicyRuleResponse);
        }

        /// <summary>
        /// Returns true if GasPerIntervalLimitPolicyRuleResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of GasPerIntervalLimitPolicyRuleResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GasPerIntervalLimitPolicyRuleResponse input)
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
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) &&
                (
                    this.FunctionName == input.FunctionName ||
                    this.FunctionName.Equals(input.FunctionName)
                ) &&
                (
                    this.GasLimit == input.GasLimit ||
                    (this.GasLimit != null &&
                    this.GasLimit.Equals(input.GasLimit))
                ) &&
                (
                    this.TimeIntervalType == input.TimeIntervalType ||
                    this.TimeIntervalType.Equals(input.TimeIntervalType)
                ) &&
                (
                    this.TimeIntervalValue == input.TimeIntervalValue ||
                    this.TimeIntervalValue.Equals(input.TimeIntervalValue)
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
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                hashCode = (hashCode * 59) + this.FunctionName.GetHashCode();
                if (this.GasLimit != null)
                {
                    hashCode = (hashCode * 59) + this.GasLimit.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.TimeIntervalType.GetHashCode();
                hashCode = (hashCode * 59) + this.TimeIntervalValue.GetHashCode();
                return hashCode;
            }
        }

    }

}
