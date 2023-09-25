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
    /// CreatePlayerAccountRequest
    /// </summary>
    [DataContract(Name = "CreatePlayerAccountRequest")]
    public partial class CreatePlayerAccountRequest : IEquatable<CreatePlayerAccountRequest>
    {

        /// <summary>
        /// Gets or Sets AccountType
        /// </summary>
        [DataMember(Name = "accountType", EmitDefaultValue = false)]
        public DataAccountTypes? AccountType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePlayerAccountRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreatePlayerAccountRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePlayerAccountRequest" /> class.
        /// </summary>
        /// <param name="chainId">The chain id (required).</param>
        /// <param name="externalOwnerAddress">The address of the external owner.</param>
        /// <param name="accountType">accountType.</param>
        /// <param name="tokenContract">If ERC6551, the NFT contract to use.</param>
        /// <param name="tokenId">If ERC6551, the tokenID to serve as owner.</param>
        public CreatePlayerAccountRequest(int chainId = default(int), string externalOwnerAddress = default(string), DataAccountTypes? accountType = default(DataAccountTypes?), string tokenContract = default(string), double tokenId = default(double))
        {
            this.ChainId = chainId;
            this.ExternalOwnerAddress = externalOwnerAddress;
            this.AccountType = accountType;
            this.TokenContract = tokenContract;
            this.TokenId = tokenId;
        }

        /// <summary>
        /// The chain id
        /// </summary>
        /// <value>The chain id</value>
        [DataMember(Name = "chainId", IsRequired = true, EmitDefaultValue = true)]
        public int ChainId { get; set; }

        /// <summary>
        /// The address of the external owner
        /// </summary>
        /// <value>The address of the external owner</value>
        [DataMember(Name = "externalOwnerAddress", EmitDefaultValue = false)]
        public string ExternalOwnerAddress { get; set; }

        /// <summary>
        /// If ERC6551, the NFT contract to use
        /// </summary>
        /// <value>If ERC6551, the NFT contract to use</value>
        [DataMember(Name = "tokenContract", EmitDefaultValue = false)]
        public string TokenContract { get; set; }

        /// <summary>
        /// If ERC6551, the tokenID to serve as owner
        /// </summary>
        /// <value>If ERC6551, the tokenID to serve as owner</value>
        [DataMember(Name = "tokenId", EmitDefaultValue = false)]
        public double TokenId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreatePlayerAccountRequest {\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  ExternalOwnerAddress: ").Append(ExternalOwnerAddress).Append("\n");
            sb.Append("  AccountType: ").Append(AccountType).Append("\n");
            sb.Append("  TokenContract: ").Append(TokenContract).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
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
            return this.Equals(input as CreatePlayerAccountRequest);
        }

        /// <summary>
        /// Returns true if CreatePlayerAccountRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CreatePlayerAccountRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreatePlayerAccountRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ChainId == input.ChainId ||
                    this.ChainId.Equals(input.ChainId)
                ) && 
                (
                    this.ExternalOwnerAddress == input.ExternalOwnerAddress ||
                    (this.ExternalOwnerAddress != null &&
                    this.ExternalOwnerAddress.Equals(input.ExternalOwnerAddress))
                ) && 
                (
                    this.AccountType == input.AccountType ||
                    this.AccountType.Equals(input.AccountType)
                ) && 
                (
                    this.TokenContract == input.TokenContract ||
                    (this.TokenContract != null &&
                    this.TokenContract.Equals(input.TokenContract))
                ) && 
                (
                    this.TokenId == input.TokenId ||
                    this.TokenId.Equals(input.TokenId)
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
                hashCode = (hashCode * 59) + this.ChainId.GetHashCode();
                if (this.ExternalOwnerAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ExternalOwnerAddress.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.AccountType.GetHashCode();
                if (this.TokenContract != null)
                {
                    hashCode = (hashCode * 59) + this.TokenContract.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.TokenId.GetHashCode();
                return hashCode;
            }
        }

    }

}
