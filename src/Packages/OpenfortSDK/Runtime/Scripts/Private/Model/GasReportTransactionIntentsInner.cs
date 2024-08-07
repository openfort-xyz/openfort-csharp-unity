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
    /// GasReportTransactionIntentsInner
    /// </summary>
    [DataContract(Name = "GasReport_transactionIntents_inner")]
    public partial class GasReportTransactionIntentsInner : IEquatable<GasReportTransactionIntentsInner>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GasReportTransactionIntentsInner" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GasReportTransactionIntentsInner() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GasReportTransactionIntentsInner" /> class.
        /// </summary>
        /// <param name="gasFeeInUSD">gasFeeInUSD (required).</param>
        /// <param name="gasUsed">gasUsed (required).</param>
        /// <param name="gasPrice">gasPrice (required).</param>
        /// <param name="gasFee">gasFee (required).</param>
        /// <param name="id">id (required).</param>
        public GasReportTransactionIntentsInner(string gasFeeInUSD = default(string), string gasUsed = default(string), string gasPrice = default(string), string gasFee = default(string), string id = default(string))
        {
            // to ensure "gasFeeInUSD" is required (not null)
            if (gasFeeInUSD == null)
            {
                throw new ArgumentNullException("gasFeeInUSD is a required property for GasReportTransactionIntentsInner and cannot be null");
            }
            this.GasFeeInUSD = gasFeeInUSD;
            // to ensure "gasUsed" is required (not null)
            if (gasUsed == null)
            {
                throw new ArgumentNullException("gasUsed is a required property for GasReportTransactionIntentsInner and cannot be null");
            }
            this.GasUsed = gasUsed;
            // to ensure "gasPrice" is required (not null)
            if (gasPrice == null)
            {
                throw new ArgumentNullException("gasPrice is a required property for GasReportTransactionIntentsInner and cannot be null");
            }
            this.GasPrice = gasPrice;
            // to ensure "gasFee" is required (not null)
            if (gasFee == null)
            {
                throw new ArgumentNullException("gasFee is a required property for GasReportTransactionIntentsInner and cannot be null");
            }
            this.GasFee = gasFee;
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for GasReportTransactionIntentsInner and cannot be null");
            }
            this.Id = id;
        }

        /// <summary>
        /// Gets or Sets GasFeeInUSD
        /// </summary>
        [DataMember(Name = "gasFeeInUSD", IsRequired = true, EmitDefaultValue = true)]
        public string GasFeeInUSD { get; set; }

        /// <summary>
        /// Gets or Sets GasUsed
        /// </summary>
        [DataMember(Name = "gasUsed", IsRequired = true, EmitDefaultValue = true)]
        public string GasUsed { get; set; }

        /// <summary>
        /// Gets or Sets GasPrice
        /// </summary>
        [DataMember(Name = "gasPrice", IsRequired = true, EmitDefaultValue = true)]
        public string GasPrice { get; set; }

        /// <summary>
        /// Gets or Sets GasFee
        /// </summary>
        [DataMember(Name = "gasFee", IsRequired = true, EmitDefaultValue = true)]
        public string GasFee { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GasReportTransactionIntentsInner {\n");
            sb.Append("  GasFeeInUSD: ").Append(GasFeeInUSD).Append("\n");
            sb.Append("  GasUsed: ").Append(GasUsed).Append("\n");
            sb.Append("  GasPrice: ").Append(GasPrice).Append("\n");
            sb.Append("  GasFee: ").Append(GasFee).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
            return this.Equals(input as GasReportTransactionIntentsInner);
        }

        /// <summary>
        /// Returns true if GasReportTransactionIntentsInner instances are equal
        /// </summary>
        /// <param name="input">Instance of GasReportTransactionIntentsInner to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GasReportTransactionIntentsInner input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.GasFeeInUSD == input.GasFeeInUSD ||
                    (this.GasFeeInUSD != null &&
                    this.GasFeeInUSD.Equals(input.GasFeeInUSD))
                ) &&
                (
                    this.GasUsed == input.GasUsed ||
                    (this.GasUsed != null &&
                    this.GasUsed.Equals(input.GasUsed))
                ) &&
                (
                    this.GasPrice == input.GasPrice ||
                    (this.GasPrice != null &&
                    this.GasPrice.Equals(input.GasPrice))
                ) &&
                (
                    this.GasFee == input.GasFee ||
                    (this.GasFee != null &&
                    this.GasFee.Equals(input.GasFee))
                ) &&
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
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
                if (this.GasFeeInUSD != null)
                {
                    hashCode = (hashCode * 59) + this.GasFeeInUSD.GetHashCode();
                }
                if (this.GasUsed != null)
                {
                    hashCode = (hashCode * 59) + this.GasUsed.GetHashCode();
                }
                if (this.GasPrice != null)
                {
                    hashCode = (hashCode * 59) + this.GasPrice.GetHashCode();
                }
                if (this.GasFee != null)
                {
                    hashCode = (hashCode * 59) + this.GasFee.GetHashCode();
                }
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
