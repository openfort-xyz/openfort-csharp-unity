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
    /// CreateEventRequest
    /// </summary>
    [DataContract(Name = "CreateEventRequest")]
    public partial class CreateEventRequest : IEquatable<CreateEventRequest>
    {

        /// <summary>
        /// Gets or Sets Topic
        /// </summary>
        [DataMember(Name = "topic", IsRequired = true, EmitDefaultValue = true)]
        public APITopic Topic { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEventRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateEventRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEventRequest" /> class.
        /// </summary>
        /// <param name="name">Specifies the name of the event (required).</param>
        /// <param name="topic">topic (required).</param>
        /// <param name="contract">Specifies the contract id (if the event is a contract event).</param>
        /// <param name="functionArgs">Specifies the function arguments (if the event is a contract event).</param>
        /// <param name="functionName">Specifies the function name (if the event is a contract event).</param>
        /// <param name="developerAccount">Specifies the developer account id (if the event is a developer account event).</param>
        /// <param name="chainId">Specifies the chain id (if the event is a developer account event).</param>
        /// <param name="threshold">Threshold for the event (if the event is a contract, dev account or project event).</param>
        /// <param name="numberOfBlocks">Specifies the number of confirmations required for the event to trigger.</param>
        public CreateEventRequest(string name = default(string), APITopic topic = default(APITopic), string contract = default(string), List<string> functionArgs = default(List<string>), string functionName = default(string), string developerAccount = default(string), double chainId = default(double), string threshold = default(string), double numberOfBlocks = default(double))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for CreateEventRequest and cannot be null");
            }
            this.Name = name;
            this.Topic = topic;
            this.Contract = contract;
            this.FunctionArgs = functionArgs;
            this.FunctionName = functionName;
            this.DeveloperAccount = developerAccount;
            this.ChainId = chainId;
            this.Threshold = threshold;
            this.NumberOfBlocks = numberOfBlocks;
        }

        /// <summary>
        /// Specifies the name of the event
        /// </summary>
        /// <value>Specifies the name of the event</value>
        /// <example>&quot;Event Name&quot;</example>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Specifies the contract id (if the event is a contract event)
        /// </summary>
        /// <value>Specifies the contract id (if the event is a contract event)</value>
        /// <example>&quot;con_6f6c9067-89fa-4fc8-ac72-c242a268c584&quot;</example>
        [DataMember(Name = "contract", EmitDefaultValue = false)]
        public string Contract { get; set; }

        /// <summary>
        /// Specifies the function arguments (if the event is a contract event)
        /// </summary>
        /// <value>Specifies the function arguments (if the event is a contract event)</value>
        [DataMember(Name = "functionArgs", EmitDefaultValue = false)]
        public List<string> FunctionArgs { get; set; }

        /// <summary>
        /// Specifies the function name (if the event is a contract event)
        /// </summary>
        /// <value>Specifies the function name (if the event is a contract event)</value>
        /// <example>&quot;functionName&quot;</example>
        [DataMember(Name = "functionName", EmitDefaultValue = false)]
        public string FunctionName { get; set; }

        /// <summary>
        /// Specifies the developer account id (if the event is a developer account event)
        /// </summary>
        /// <value>Specifies the developer account id (if the event is a developer account event)</value>
        /// <example>&quot;dev_6f6c9067-89fa-4fc8-ac72-c242a268c584&quot;</example>
        [DataMember(Name = "developerAccount", EmitDefaultValue = false)]
        public string DeveloperAccount { get; set; }

        /// <summary>
        /// Specifies the chain id (if the event is a developer account event)
        /// </summary>
        /// <value>Specifies the chain id (if the event is a developer account event)</value>
        /// <example>80001</example>
        [DataMember(Name = "chainId", EmitDefaultValue = false)]
        public double ChainId { get; set; }

        /// <summary>
        /// Threshold for the event (if the event is a contract, dev account or project event)
        /// </summary>
        /// <value>Threshold for the event (if the event is a contract, dev account or project event)</value>
        [DataMember(Name = "threshold", EmitDefaultValue = false)]
        public string Threshold { get; set; }

        /// <summary>
        /// Specifies the number of confirmations required for the event to trigger
        /// </summary>
        /// <value>Specifies the number of confirmations required for the event to trigger</value>
        /// <example>10</example>
        [DataMember(Name = "numberOfBlocks", EmitDefaultValue = false)]
        public double NumberOfBlocks { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateEventRequest {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Topic: ").Append(Topic).Append("\n");
            sb.Append("  Contract: ").Append(Contract).Append("\n");
            sb.Append("  FunctionArgs: ").Append(FunctionArgs).Append("\n");
            sb.Append("  FunctionName: ").Append(FunctionName).Append("\n");
            sb.Append("  DeveloperAccount: ").Append(DeveloperAccount).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  Threshold: ").Append(Threshold).Append("\n");
            sb.Append("  NumberOfBlocks: ").Append(NumberOfBlocks).Append("\n");
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
            return this.Equals(input as CreateEventRequest);
        }

        /// <summary>
        /// Returns true if CreateEventRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CreateEventRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateEventRequest input)
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
                    this.Topic == input.Topic ||
                    this.Topic.Equals(input.Topic)
                ) &&
                (
                    this.Contract == input.Contract ||
                    (this.Contract != null &&
                    this.Contract.Equals(input.Contract))
                ) &&
                (
                    this.FunctionArgs == input.FunctionArgs ||
                    this.FunctionArgs != null &&
                    input.FunctionArgs != null &&
                    this.FunctionArgs.SequenceEqual(input.FunctionArgs)
                ) &&
                (
                    this.FunctionName == input.FunctionName ||
                    (this.FunctionName != null &&
                    this.FunctionName.Equals(input.FunctionName))
                ) &&
                (
                    this.DeveloperAccount == input.DeveloperAccount ||
                    (this.DeveloperAccount != null &&
                    this.DeveloperAccount.Equals(input.DeveloperAccount))
                ) &&
                (
                    this.ChainId == input.ChainId ||
                    this.ChainId.Equals(input.ChainId)
                ) &&
                (
                    this.Threshold == input.Threshold ||
                    (this.Threshold != null &&
                    this.Threshold.Equals(input.Threshold))
                ) &&
                (
                    this.NumberOfBlocks == input.NumberOfBlocks ||
                    this.NumberOfBlocks.Equals(input.NumberOfBlocks)
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
                hashCode = (hashCode * 59) + this.Topic.GetHashCode();
                if (this.Contract != null)
                {
                    hashCode = (hashCode * 59) + this.Contract.GetHashCode();
                }
                if (this.FunctionArgs != null)
                {
                    hashCode = (hashCode * 59) + this.FunctionArgs.GetHashCode();
                }
                if (this.FunctionName != null)
                {
                    hashCode = (hashCode * 59) + this.FunctionName.GetHashCode();
                }
                if (this.DeveloperAccount != null)
                {
                    hashCode = (hashCode * 59) + this.DeveloperAccount.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ChainId.GetHashCode();
                if (this.Threshold != null)
                {
                    hashCode = (hashCode * 59) + this.Threshold.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.NumberOfBlocks.GetHashCode();
                return hashCode;
            }
        }

    }

}
