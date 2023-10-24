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
using OpenAPIDateConverter = Openfort.Client.OpenAPIDateConverter;

namespace Openfort.Model
{
    /// <summary>
    /// PaymasterDepositorResponse
    /// </summary>
    [DataContract(Name = "PaymasterDepositorResponse")]
    public partial class PaymasterDepositorResponse : IEquatable<PaymasterDepositorResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymasterDepositorResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PaymasterDepositorResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymasterDepositorResponse" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="depositorAddress">depositorAddress (required).</param>
        public PaymasterDepositorResponse(string id = default(string), string depositorAddress = default(string))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for PaymasterDepositorResponse and cannot be null");
            }
            this.Id = id;
            // to ensure "depositorAddress" is required (not null)
            if (depositorAddress == null)
            {
                throw new ArgumentNullException("depositorAddress is a required property for PaymasterDepositorResponse and cannot be null");
            }
            this.DepositorAddress = depositorAddress;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets DepositorAddress
        /// </summary>
        [DataMember(Name = "depositorAddress", IsRequired = true, EmitDefaultValue = true)]
        public string DepositorAddress { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PaymasterDepositorResponse {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DepositorAddress: ").Append(DepositorAddress).Append("\n");
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
            return this.Equals(input as PaymasterDepositorResponse);
        }

        /// <summary>
        /// Returns true if PaymasterDepositorResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of PaymasterDepositorResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PaymasterDepositorResponse input)
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
                    this.DepositorAddress == input.DepositorAddress ||
                    (this.DepositorAddress != null &&
                    this.DepositorAddress.Equals(input.DepositorAddress))
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
                if (this.DepositorAddress != null)
                {
                    hashCode = (hashCode * 59) + this.DepositorAddress.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}