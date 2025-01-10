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
    /// CreateSubscriptionRequest
    /// </summary>
    [DataContract(Name = "CreateSubscriptionRequest")]
    public partial class CreateSubscriptionRequest : IEquatable<CreateSubscriptionRequest>
    {

        /// <summary>
        /// Gets or Sets Topic
        /// </summary>
        [DataMember(Name = "topic", IsRequired = true, EmitDefaultValue = true)]
        public APITopic Topic { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSubscriptionRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateSubscriptionRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSubscriptionRequest" /> class.
        /// </summary>
        /// <param name="topic">topic (required).</param>
        /// <param name="triggers">Specifies the triggers of the subscription (required).</param>
        public CreateSubscriptionRequest(APITopic topic = default(APITopic), List<CreateTriggerRequest> triggers = default(List<CreateTriggerRequest>))
        {
            this.Topic = topic;
            // to ensure "triggers" is required (not null)
            if (triggers == null)
            {
                throw new ArgumentNullException("triggers is a required property for CreateSubscriptionRequest and cannot be null");
            }
            this.Triggers = triggers;
        }

        /// <summary>
        /// Specifies the triggers of the subscription
        /// </summary>
        /// <value>Specifies the triggers of the subscription</value>
        [DataMember(Name = "triggers", IsRequired = true, EmitDefaultValue = true)]
        public List<CreateTriggerRequest> Triggers { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateSubscriptionRequest {\n");
            sb.Append("  Topic: ").Append(Topic).Append("\n");
            sb.Append("  Triggers: ").Append(Triggers).Append("\n");
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
            return this.Equals(input as CreateSubscriptionRequest);
        }

        /// <summary>
        /// Returns true if CreateSubscriptionRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CreateSubscriptionRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateSubscriptionRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Topic == input.Topic ||
                    this.Topic.Equals(input.Topic)
                ) &&
                (
                    this.Triggers == input.Triggers ||
                    this.Triggers != null &&
                    input.Triggers != null &&
                    this.Triggers.SequenceEqual(input.Triggers)
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
                hashCode = (hashCode * 59) + this.Topic.GetHashCode();
                if (this.Triggers != null)
                {
                    hashCode = (hashCode * 59) + this.Triggers.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
