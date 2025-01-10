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
    /// UpdateEmailSampleRequest
    /// </summary>
    [DataContract(Name = "UpdateEmailSampleRequest")]
    public partial class UpdateEmailSampleRequest : IEquatable<UpdateEmailSampleRequest>
    {

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public EmailTypeRequest? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEmailSampleRequest" /> class.
        /// </summary>
        /// <param name="name">Specifies the name.</param>
        /// <param name="subject">Specifies the subject.</param>
        /// <param name="body">Specifies the body.</param>
        /// <param name="type">type.</param>
        public UpdateEmailSampleRequest(string name = default(string), string subject = default(string), string body = default(string), EmailTypeRequest? type = default(EmailTypeRequest?))
        {
            this.Name = name;
            this.Subject = subject;
            this.Body = body;
            this.Type = type;
        }

        /// <summary>
        /// Specifies the name
        /// </summary>
        /// <value>Specifies the name</value>
        /// <example>&quot;name&quot;</example>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Specifies the subject
        /// </summary>
        /// <value>Specifies the subject</value>
        /// <example>&quot;subject&quot;</example>
        [DataMember(Name = "subject", EmitDefaultValue = false)]
        public string Subject { get; set; }

        /// <summary>
        /// Specifies the body
        /// </summary>
        /// <value>Specifies the body</value>
        /// <example>&quot;body&quot;</example>
        [DataMember(Name = "body", EmitDefaultValue = false)]
        public string Body { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UpdateEmailSampleRequest {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  Body: ").Append(Body).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
            return this.Equals(input as UpdateEmailSampleRequest);
        }

        /// <summary>
        /// Returns true if UpdateEmailSampleRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdateEmailSampleRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateEmailSampleRequest input)
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
                    this.Subject == input.Subject ||
                    (this.Subject != null &&
                    this.Subject.Equals(input.Subject))
                ) &&
                (
                    this.Body == input.Body ||
                    (this.Body != null &&
                    this.Body.Equals(input.Body))
                ) &&
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
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
                if (this.Subject != null)
                {
                    hashCode = (hashCode * 59) + this.Subject.GetHashCode();
                }
                if (this.Body != null)
                {
                    hashCode = (hashCode * 59) + this.Body.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                return hashCode;
            }
        }

    }

}
