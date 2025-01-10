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
    /// CreateAccountRequest
    /// </summary>
    [DataContract(Name = "CreateAccountRequest")]
    public partial class CreateAccountRequest : IEquatable<CreateAccountRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAccountRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateAccountRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAccountRequest" /> class.
        /// </summary>
        /// <param name="chainId">The chain ID. Must be a [supported chain](/chains). (required).</param>
        /// <param name="externalOwnerAddress">Use this parameter to create a new Account for Player with the provided owner address..</param>
        /// <param name="accountType">The type of smart account that will be created (e.g. ERC6551V1, UpgradeableV6, UpgradeableV5, ZKSyncUpgradeableV1). Defaults to UpgradeableV6..</param>
        /// <param name="defaultGuardian">For account types that support social recovery, wether to enable Openfort as guardian or not. Defaults to false..</param>
        /// <param name="tokenContract">If ERC6551, the address of the NFT contract to use.</param>
        /// <param name="tokenId">If ERC6551, the tokenId from the NFT contract that will serve as owner.</param>
        /// <param name="player">ID of the player this account belongs to (starts with &#x60;pla_&#x60;). If none is provided, a new player will be created..</param>
        public CreateAccountRequest(int chainId = default(int), string externalOwnerAddress = default(string), string accountType = default(string), bool defaultGuardian = default(bool), string tokenContract = default(string), long tokenId = default(long), string player = default(string))
        {
            this.ChainId = chainId;
            this.ExternalOwnerAddress = externalOwnerAddress;
            this.AccountType = accountType;
            this.DefaultGuardian = defaultGuardian;
            this.TokenContract = tokenContract;
            this.TokenId = tokenId;
            this.Player = player;
        }

        /// <summary>
        /// The chain ID. Must be a [supported chain](/chains).
        /// </summary>
        /// <value>The chain ID. Must be a [supported chain](/chains).</value>
        /// <example>80002</example>
        [DataMember(Name = "chainId", IsRequired = true, EmitDefaultValue = true)]
        public int ChainId { get; set; }

        /// <summary>
        /// Use this parameter to create a new Account for Player with the provided owner address.
        /// </summary>
        /// <value>Use this parameter to create a new Account for Player with the provided owner address.</value>
        /// <example>&quot;0x662D24Bf7Ea2dD6a7D0935F680a6056b94fE934d&quot;</example>
        [DataMember(Name = "externalOwnerAddress", EmitDefaultValue = false)]
        public string ExternalOwnerAddress { get; set; }

        /// <summary>
        /// The type of smart account that will be created (e.g. ERC6551V1, UpgradeableV6, UpgradeableV5, ZKSyncUpgradeableV1). Defaults to UpgradeableV6.
        /// </summary>
        /// <value>The type of smart account that will be created (e.g. ERC6551V1, UpgradeableV6, UpgradeableV5, ZKSyncUpgradeableV1). Defaults to UpgradeableV6.</value>
        /// <example>&quot;UpgradeableV6&quot;</example>
        [DataMember(Name = "accountType", EmitDefaultValue = false)]
        public string AccountType { get; set; }

        /// <summary>
        /// For account types that support social recovery, wether to enable Openfort as guardian or not. Defaults to false.
        /// </summary>
        /// <value>For account types that support social recovery, wether to enable Openfort as guardian or not. Defaults to false.</value>
        /// <example>true</example>
        [DataMember(Name = "defaultGuardian", EmitDefaultValue = true)]
        public bool DefaultGuardian { get; set; }

        /// <summary>
        /// If ERC6551, the address of the NFT contract to use
        /// </summary>
        /// <value>If ERC6551, the address of the NFT contract to use</value>
        /// <example>&quot;0x662D24Bf7Ea2dD6a7D0135F680a6056b94fE934d&quot;</example>
        [DataMember(Name = "tokenContract", EmitDefaultValue = false)]
        public string TokenContract { get; set; }

        /// <summary>
        /// If ERC6551, the tokenId from the NFT contract that will serve as owner
        /// </summary>
        /// <value>If ERC6551, the tokenId from the NFT contract that will serve as owner</value>
        /// <example>1</example>
        [DataMember(Name = "tokenId", EmitDefaultValue = false)]
        public long TokenId { get; set; }

        /// <summary>
        /// ID of the player this account belongs to (starts with &#x60;pla_&#x60;). If none is provided, a new player will be created.
        /// </summary>
        /// <value>ID of the player this account belongs to (starts with &#x60;pla_&#x60;). If none is provided, a new player will be created.</value>
        /// <example>&quot;pla_e0b84653-1741-4a3d-9e91-2b0fd2942f60&quot;</example>
        [DataMember(Name = "player", EmitDefaultValue = false)]
        public string Player { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateAccountRequest {\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  ExternalOwnerAddress: ").Append(ExternalOwnerAddress).Append("\n");
            sb.Append("  AccountType: ").Append(AccountType).Append("\n");
            sb.Append("  DefaultGuardian: ").Append(DefaultGuardian).Append("\n");
            sb.Append("  TokenContract: ").Append(TokenContract).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
            sb.Append("  Player: ").Append(Player).Append("\n");
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
            return this.Equals(input as CreateAccountRequest);
        }

        /// <summary>
        /// Returns true if CreateAccountRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CreateAccountRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateAccountRequest input)
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
                    (this.AccountType != null &&
                    this.AccountType.Equals(input.AccountType))
                ) &&
                (
                    this.DefaultGuardian == input.DefaultGuardian ||
                    this.DefaultGuardian.Equals(input.DefaultGuardian)
                ) &&
                (
                    this.TokenContract == input.TokenContract ||
                    (this.TokenContract != null &&
                    this.TokenContract.Equals(input.TokenContract))
                ) &&
                (
                    this.TokenId == input.TokenId ||
                    this.TokenId.Equals(input.TokenId)
                ) &&
                (
                    this.Player == input.Player ||
                    (this.Player != null &&
                    this.Player.Equals(input.Player))
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
                if (this.AccountType != null)
                {
                    hashCode = (hashCode * 59) + this.AccountType.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.DefaultGuardian.GetHashCode();
                if (this.TokenContract != null)
                {
                    hashCode = (hashCode * 59) + this.TokenContract.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.TokenId.GetHashCode();
                if (this.Player != null)
                {
                    hashCode = (hashCode * 59) + this.Player.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
