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
    /// CreateApiAuthorizedNetworkRequest
    /// </summary>
    [DataContract(Name = "CreateApiAuthorizedNetworkRequest")]
    public partial class CreateApiAuthorizedNetworkRequest : IEquatable<CreateApiAuthorizedNetworkRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateApiAuthorizedNetworkRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateApiAuthorizedNetworkRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateApiAuthorizedNetworkRequest" /> class.
        /// </summary>
        /// <param name="name">The name of the authorized network. (required).</param>
        /// <param name="network">The network address. (required).</param>
        public CreateApiAuthorizedNetworkRequest(string name = default(string), string network = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for CreateApiAuthorizedNetworkRequest and cannot be null");
            }
            this.Name = name;
            // to ensure "network" is required (not null)
            if (network == null)
            {
                throw new ArgumentNullException("network is a required property for CreateApiAuthorizedNetworkRequest and cannot be null");
            }
            this.Network = network;
        }

        /// <summary>
        /// The name of the authorized network.
        /// </summary>
        /// <value>The name of the authorized network.</value>
        /// <example>&quot;My Authorized Network&quot;</example>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// The network address.
        /// </summary>
        /// <value>The network address.</value>
        [DataMember(Name = "network", IsRequired = true, EmitDefaultValue = true)]
        public string Network { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateApiAuthorizedNetworkRequest {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Network: ").Append(Network).Append("\n");
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
            return this.Equals(input as CreateApiAuthorizedNetworkRequest);
        }

        /// <summary>
        /// Returns true if CreateApiAuthorizedNetworkRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CreateApiAuthorizedNetworkRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateApiAuthorizedNetworkRequest input)
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
                    this.Network == input.Network ||
                    (this.Network != null &&
                    this.Network.Equals(input.Network))
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
                if (this.Network != null)
                {
                    hashCode = (hashCode * 59) + this.Network.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
