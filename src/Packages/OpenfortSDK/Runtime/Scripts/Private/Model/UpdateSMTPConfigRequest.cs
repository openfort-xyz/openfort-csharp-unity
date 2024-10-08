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
    /// UpdateSMTPConfigRequest
    /// </summary>
    [DataContract(Name = "UpdateSMTPConfigRequest")]
    public partial class UpdateSMTPConfigRequest : IEquatable<UpdateSMTPConfigRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSMTPConfigRequest" /> class.
        /// </summary>
        /// <param name="user">Specifies the user name.</param>
        /// <param name="pass">Specifies the password.</param>
        /// <param name="host">Specifies the host.</param>
        /// <param name="port">Specifies the port.</param>
        /// <param name="useSSL">Specifies the use SSL.</param>
        public UpdateSMTPConfigRequest(string user = default(string), string pass = default(string), string host = default(string), double port = default(double), bool useSSL = default(bool))
        {
            this.User = user;
            this.Pass = pass;
            this.Host = host;
            this.Port = port;
            this.UseSSL = useSSL;
        }

        /// <summary>
        /// Specifies the user name
        /// </summary>
        /// <value>Specifies the user name</value>
        /// <example>&quot;user&quot;</example>
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public string User { get; set; }

        /// <summary>
        /// Specifies the password
        /// </summary>
        /// <value>Specifies the password</value>
        /// <example>&quot;pass&quot;</example>
        [DataMember(Name = "pass", EmitDefaultValue = false)]
        public string Pass { get; set; }

        /// <summary>
        /// Specifies the host
        /// </summary>
        /// <value>Specifies the host</value>
        /// <example>&quot;host&quot;</example>
        [DataMember(Name = "host", EmitDefaultValue = false)]
        public string Host { get; set; }

        /// <summary>
        /// Specifies the port
        /// </summary>
        /// <value>Specifies the port</value>
        /// <example>0</example>
        [DataMember(Name = "port", EmitDefaultValue = false)]
        public double Port { get; set; }

        /// <summary>
        /// Specifies the use SSL
        /// </summary>
        /// <value>Specifies the use SSL</value>
        /// <example>true</example>
        [DataMember(Name = "useSSL", EmitDefaultValue = true)]
        public bool UseSSL { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UpdateSMTPConfigRequest {\n");
            sb.Append("  User: ").Append(User).Append("\n");
            sb.Append("  Pass: ").Append(Pass).Append("\n");
            sb.Append("  Host: ").Append(Host).Append("\n");
            sb.Append("  Port: ").Append(Port).Append("\n");
            sb.Append("  UseSSL: ").Append(UseSSL).Append("\n");
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
            return this.Equals(input as UpdateSMTPConfigRequest);
        }

        /// <summary>
        /// Returns true if UpdateSMTPConfigRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdateSMTPConfigRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateSMTPConfigRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.User == input.User ||
                    (this.User != null &&
                    this.User.Equals(input.User))
                ) &&
                (
                    this.Pass == input.Pass ||
                    (this.Pass != null &&
                    this.Pass.Equals(input.Pass))
                ) &&
                (
                    this.Host == input.Host ||
                    (this.Host != null &&
                    this.Host.Equals(input.Host))
                ) &&
                (
                    this.Port == input.Port ||
                    this.Port.Equals(input.Port)
                ) &&
                (
                    this.UseSSL == input.UseSSL ||
                    this.UseSSL.Equals(input.UseSSL)
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
                if (this.User != null)
                {
                    hashCode = (hashCode * 59) + this.User.GetHashCode();
                }
                if (this.Pass != null)
                {
                    hashCode = (hashCode * 59) + this.Pass.GetHashCode();
                }
                if (this.Host != null)
                {
                    hashCode = (hashCode * 59) + this.Host.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Port.GetHashCode();
                hashCode = (hashCode * 59) + this.UseSSL.GetHashCode();
                return hashCode;
            }
        }

    }

}
