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
    /// CreatePolicyRuleRequest
    /// </summary>
    [DataContract(Name = "CreatePolicyRuleRequest")]
    public partial class CreatePolicyRuleRequest : IEquatable<CreatePolicyRuleRequest>
    {

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public PolicyRuleType Type { get; set; }

        /// <summary>
        /// Gets or Sets TimeIntervalType
        /// </summary>
        [DataMember(Name = "timeIntervalType", EmitDefaultValue = false)]
        public TimeIntervalType? TimeIntervalType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePolicyRuleRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreatePolicyRuleRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePolicyRuleRequest" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="functionName">Name of the function in the contract to allow. If you want to allow all functions, use the wildcard &#39;All functions&#39;..</param>
        /// <param name="contract">The contract ID you want to interact with. Must have been added to Openfort first, starts with &#x60;con_&#x60;..</param>
        /// <param name="wildcard">When using &#x60;contract_functions&#x60; type, set this to &#x60;true&#x60; to allow all contracts..</param>
        /// <param name="gasLimit">Gas limit in WEI (i.e. factor 10^18)..</param>
        /// <param name="countLimit">Number of times the function will be sponsored..</param>
        /// <param name="timeIntervalType">timeIntervalType.</param>
        /// <param name="timeIntervalValue">Time interval value..</param>
        /// <param name="policy">The unique Policy ID to add the rule to (starts with pol_). (required).</param>
        public CreatePolicyRuleRequest(PolicyRuleType type = default(PolicyRuleType), string functionName = default(string), string contract = default(string), bool wildcard = default(bool), string gasLimit = default(string), int countLimit = default(int), TimeIntervalType? timeIntervalType = default(TimeIntervalType?), int timeIntervalValue = default(int), string policy = default(string))
        {
            this.Type = type;
            // to ensure "policy" is required (not null)
            if (policy == null)
            {
                throw new ArgumentNullException("policy is a required property for CreatePolicyRuleRequest and cannot be null");
            }
            this.Policy = policy;
            this.FunctionName = functionName;
            this.Contract = contract;
            this.Wildcard = wildcard;
            this.GasLimit = gasLimit;
            this.CountLimit = countLimit;
            this.TimeIntervalType = timeIntervalType;
            this.TimeIntervalValue = timeIntervalValue;
        }

        /// <summary>
        /// Name of the function in the contract to allow. If you want to allow all functions, use the wildcard &#39;All functions&#39;.
        /// </summary>
        /// <value>Name of the function in the contract to allow. If you want to allow all functions, use the wildcard &#39;All functions&#39;.</value>
        /// <example>&quot;All functions&quot;</example>
        [DataMember(Name = "functionName", EmitDefaultValue = false)]
        public string FunctionName { get; set; }

        /// <summary>
        /// The contract ID you want to interact with. Must have been added to Openfort first, starts with &#x60;con_&#x60;.
        /// </summary>
        /// <value>The contract ID you want to interact with. Must have been added to Openfort first, starts with &#x60;con_&#x60;.</value>
        /// <example>&quot;con_0cddb398-1dc6-4e6f-8726-9ec7cea85f35&quot;</example>
        [DataMember(Name = "contract", EmitDefaultValue = false)]
        public string Contract { get; set; }

        /// <summary>
        /// When using &#x60;contract_functions&#x60; type, set this to &#x60;true&#x60; to allow all contracts.
        /// </summary>
        /// <value>When using &#x60;contract_functions&#x60; type, set this to &#x60;true&#x60; to allow all contracts.</value>
        /// <example>true</example>
        [DataMember(Name = "wildcard", EmitDefaultValue = true)]
        public bool Wildcard { get; set; }

        /// <summary>
        /// Gas limit in WEI (i.e. factor 10^18).
        /// </summary>
        /// <value>Gas limit in WEI (i.e. factor 10^18).</value>
        /// <example>&quot;1000000000000000000&quot;</example>
        [DataMember(Name = "gasLimit", EmitDefaultValue = false)]
        public string GasLimit { get; set; }

        /// <summary>
        /// Number of times the function will be sponsored.
        /// </summary>
        /// <value>Number of times the function will be sponsored.</value>
        /// <example>1</example>
        [DataMember(Name = "countLimit", EmitDefaultValue = false)]
        public int CountLimit { get; set; }

        /// <summary>
        /// Time interval value.
        /// </summary>
        /// <value>Time interval value.</value>
        /// <example>1</example>
        [DataMember(Name = "timeIntervalValue", EmitDefaultValue = false)]
        public int TimeIntervalValue { get; set; }

        /// <summary>
        /// The unique Policy ID to add the rule to (starts with pol_).
        /// </summary>
        /// <value>The unique Policy ID to add the rule to (starts with pol_).</value>
        /// <example>&quot;pol_7e07ae30-2a4d-48fa-803f-361da94905dd&quot;</example>
        [DataMember(Name = "policy", IsRequired = true, EmitDefaultValue = true)]
        public string Policy { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreatePolicyRuleRequest {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  FunctionName: ").Append(FunctionName).Append("\n");
            sb.Append("  Contract: ").Append(Contract).Append("\n");
            sb.Append("  Wildcard: ").Append(Wildcard).Append("\n");
            sb.Append("  GasLimit: ").Append(GasLimit).Append("\n");
            sb.Append("  CountLimit: ").Append(CountLimit).Append("\n");
            sb.Append("  TimeIntervalType: ").Append(TimeIntervalType).Append("\n");
            sb.Append("  TimeIntervalValue: ").Append(TimeIntervalValue).Append("\n");
            sb.Append("  Policy: ").Append(Policy).Append("\n");
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
            return this.Equals(input as CreatePolicyRuleRequest);
        }

        /// <summary>
        /// Returns true if CreatePolicyRuleRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CreatePolicyRuleRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreatePolicyRuleRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) &&
                (
                    this.FunctionName == input.FunctionName ||
                    (this.FunctionName != null &&
                    this.FunctionName.Equals(input.FunctionName))
                ) &&
                (
                    this.Contract == input.Contract ||
                    (this.Contract != null &&
                    this.Contract.Equals(input.Contract))
                ) &&
                (
                    this.Wildcard == input.Wildcard ||
                    this.Wildcard.Equals(input.Wildcard)
                ) &&
                (
                    this.GasLimit == input.GasLimit ||
                    (this.GasLimit != null &&
                    this.GasLimit.Equals(input.GasLimit))
                ) &&
                (
                    this.CountLimit == input.CountLimit ||
                    this.CountLimit.Equals(input.CountLimit)
                ) &&
                (
                    this.TimeIntervalType == input.TimeIntervalType ||
                    this.TimeIntervalType.Equals(input.TimeIntervalType)
                ) &&
                (
                    this.TimeIntervalValue == input.TimeIntervalValue ||
                    this.TimeIntervalValue.Equals(input.TimeIntervalValue)
                ) &&
                (
                    this.Policy == input.Policy ||
                    (this.Policy != null &&
                    this.Policy.Equals(input.Policy))
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
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                if (this.FunctionName != null)
                {
                    hashCode = (hashCode * 59) + this.FunctionName.GetHashCode();
                }
                if (this.Contract != null)
                {
                    hashCode = (hashCode * 59) + this.Contract.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Wildcard.GetHashCode();
                if (this.GasLimit != null)
                {
                    hashCode = (hashCode * 59) + this.GasLimit.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.CountLimit.GetHashCode();
                hashCode = (hashCode * 59) + this.TimeIntervalType.GetHashCode();
                hashCode = (hashCode * 59) + this.TimeIntervalValue.GetHashCode();
                if (this.Policy != null)
                {
                    hashCode = (hashCode * 59) + this.Policy.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
