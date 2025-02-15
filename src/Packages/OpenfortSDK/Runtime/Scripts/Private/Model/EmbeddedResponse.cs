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
    /// EmbeddedResponse
    /// </summary>
    [DataContract(Name = "EmbeddedResponse")]
    public partial class EmbeddedResponse : IEquatable<EmbeddedResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EmbeddedResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedResponse" /> class.
        /// </summary>
        /// <param name="share">share (required).</param>
        /// <param name="accountType">accountType (required).</param>
        /// <param name="address">address (required).</param>
        /// <param name="chainId">chainId (required).</param>
        /// <param name="deviceId">deviceId.</param>
        public EmbeddedResponse(string share = default(string), string accountType = default(string), string address = default(string), double chainId = default(double), string deviceId = default(string))
        {
            // to ensure "share" is required (not null)
            if (share == null)
            {
                throw new ArgumentNullException("share is a required property for EmbeddedResponse and cannot be null");
            }
            this.Share = share;
            // to ensure "accountType" is required (not null)
            if (accountType == null)
            {
                throw new ArgumentNullException("accountType is a required property for EmbeddedResponse and cannot be null");
            }
            this.AccountType = accountType;
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new ArgumentNullException("address is a required property for EmbeddedResponse and cannot be null");
            }
            this.Address = address;
            this.ChainId = chainId;
            this.DeviceId = deviceId;
        }

        /// <summary>
        /// Gets or Sets Share
        /// </summary>
        [DataMember(Name = "share", IsRequired = true, EmitDefaultValue = true)]
        public string Share { get; set; }

        /// <summary>
        /// Gets or Sets AccountType
        /// </summary>
        [DataMember(Name = "accountType", IsRequired = true, EmitDefaultValue = true)]
        public string AccountType { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name = "address", IsRequired = true, EmitDefaultValue = true)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets ChainId
        /// </summary>
        [DataMember(Name = "chainId", IsRequired = true, EmitDefaultValue = true)]
        public double ChainId { get; set; }

        /// <summary>
        /// Gets or Sets DeviceId
        /// </summary>
        [DataMember(Name = "deviceId", EmitDefaultValue = false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EmbeddedResponse {\n");
            sb.Append("  Share: ").Append(Share).Append("\n");
            sb.Append("  AccountType: ").Append(AccountType).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
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
            return this.Equals(input as EmbeddedResponse);
        }

        /// <summary>
        /// Returns true if EmbeddedResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of EmbeddedResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EmbeddedResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Share == input.Share ||
                    (this.Share != null &&
                    this.Share.Equals(input.Share))
                ) &&
                (
                    this.AccountType == input.AccountType ||
                    (this.AccountType != null &&
                    this.AccountType.Equals(input.AccountType))
                ) &&
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) &&
                (
                    this.ChainId == input.ChainId ||
                    this.ChainId.Equals(input.ChainId)
                ) &&
                (
                    this.DeviceId == input.DeviceId ||
                    (this.DeviceId != null &&
                    this.DeviceId.Equals(input.DeviceId))
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
                if (this.Share != null)
                {
                    hashCode = (hashCode * 59) + this.Share.GetHashCode();
                }
                if (this.AccountType != null)
                {
                    hashCode = (hashCode * 59) + this.AccountType.GetHashCode();
                }
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ChainId.GetHashCode();
                if (this.DeviceId != null)
                {
                    hashCode = (hashCode * 59) + this.DeviceId.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
