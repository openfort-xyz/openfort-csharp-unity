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
    /// ChargeCustomTokenPolicyStrategy
    /// </summary>
    [DataContract(Name = "ChargeCustomTokenPolicyStrategy")]
    public partial class ChargeCustomTokenPolicyStrategy : IEquatable<ChargeCustomTokenPolicyStrategy>
    {

        /// <summary>
        /// Gets or Sets SponsorSchema
        /// </summary>
        [DataMember(Name = "sponsorSchema", IsRequired = true, EmitDefaultValue = true)]
        public SponsorSchemaCHARGECUSTOMTOKENS SponsorSchema { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChargeCustomTokenPolicyStrategy" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ChargeCustomTokenPolicyStrategy() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChargeCustomTokenPolicyStrategy" /> class.
        /// </summary>
        /// <param name="sponsorSchema">sponsorSchema (required).</param>
        /// <param name="tokenContract">tokenContract (required).</param>
        /// <param name="tokenContractAmount">tokenContractAmount (required).</param>
        public ChargeCustomTokenPolicyStrategy(SponsorSchemaCHARGECUSTOMTOKENS sponsorSchema = default(SponsorSchemaCHARGECUSTOMTOKENS), string tokenContract = default(string), string tokenContractAmount = default(string))
        {
            this.SponsorSchema = sponsorSchema;
            // to ensure "tokenContract" is required (not null)
            if (tokenContract == null)
            {
                throw new ArgumentNullException("tokenContract is a required property for ChargeCustomTokenPolicyStrategy and cannot be null");
            }
            this.TokenContract = tokenContract;
            // to ensure "tokenContractAmount" is required (not null)
            if (tokenContractAmount == null)
            {
                throw new ArgumentNullException("tokenContractAmount is a required property for ChargeCustomTokenPolicyStrategy and cannot be null");
            }
            this.TokenContractAmount = tokenContractAmount;
        }

        /// <summary>
        /// Gets or Sets TokenContract
        /// </summary>
        [DataMember(Name = "tokenContract", IsRequired = true, EmitDefaultValue = true)]
        public string TokenContract { get; set; }

        /// <summary>
        /// Gets or Sets TokenContractAmount
        /// </summary>
        [DataMember(Name = "tokenContractAmount", IsRequired = true, EmitDefaultValue = true)]
        public string TokenContractAmount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ChargeCustomTokenPolicyStrategy {\n");
            sb.Append("  SponsorSchema: ").Append(SponsorSchema).Append("\n");
            sb.Append("  TokenContract: ").Append(TokenContract).Append("\n");
            sb.Append("  TokenContractAmount: ").Append(TokenContractAmount).Append("\n");
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
            return this.Equals(input as ChargeCustomTokenPolicyStrategy);
        }

        /// <summary>
        /// Returns true if ChargeCustomTokenPolicyStrategy instances are equal
        /// </summary>
        /// <param name="input">Instance of ChargeCustomTokenPolicyStrategy to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChargeCustomTokenPolicyStrategy input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.SponsorSchema == input.SponsorSchema ||
                    this.SponsorSchema.Equals(input.SponsorSchema)
                ) && 
                (
                    this.TokenContract == input.TokenContract ||
                    (this.TokenContract != null &&
                    this.TokenContract.Equals(input.TokenContract))
                ) && 
                (
                    this.TokenContractAmount == input.TokenContractAmount ||
                    (this.TokenContractAmount != null &&
                    this.TokenContractAmount.Equals(input.TokenContractAmount))
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
                hashCode = (hashCode * 59) + this.SponsorSchema.GetHashCode();
                if (this.TokenContract != null)
                {
                    hashCode = (hashCode * 59) + this.TokenContract.GetHashCode();
                }
                if (this.TokenContractAmount != null)
                {
                    hashCode = (hashCode * 59) + this.TokenContractAmount.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
