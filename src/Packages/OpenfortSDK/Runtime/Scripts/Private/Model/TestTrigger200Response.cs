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
    /// TestTrigger200Response
    /// </summary>
    [DataContract(Name = "TestTrigger_200_response")]
    public partial class TestTrigger200Response : IEquatable<TestTrigger200Response>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestTrigger200Response" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TestTrigger200Response() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TestTrigger200Response" /> class.
        /// </summary>
        /// <param name="sent">sent (required).</param>
        public TestTrigger200Response(bool sent = default(bool))
        {
            this.Sent = sent;
        }

        /// <summary>
        /// Gets or Sets Sent
        /// </summary>
        [DataMember(Name = "sent", IsRequired = true, EmitDefaultValue = true)]
        public bool Sent { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TestTrigger200Response {\n");
            sb.Append("  Sent: ").Append(Sent).Append("\n");
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
            return this.Equals(input as TestTrigger200Response);
        }

        /// <summary>
        /// Returns true if TestTrigger200Response instances are equal
        /// </summary>
        /// <param name="input">Instance of TestTrigger200Response to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TestTrigger200Response input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Sent == input.Sent ||
                    this.Sent.Equals(input.Sent)
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
                hashCode = (hashCode * 59) + this.Sent.GetHashCode();
                return hashCode;
            }
        }

    }

}
