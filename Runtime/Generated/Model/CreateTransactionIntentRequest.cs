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
    /// CreateTransactionIntentRequest
    /// </summary>
    [DataContract(Name = "CreateTransactionIntentRequest")]
    public partial class CreateTransactionIntentRequest : IEquatable<CreateTransactionIntentRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTransactionIntentRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateTransactionIntentRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTransactionIntentRequest" /> class.
        /// </summary>
        /// <param name="chainId">The chain ID. Must be a [supported chain](/chains). (required).</param>
        /// <param name="player">ID of the Player this TransactionIntent belongs to, if one exists (starts with &#x60;pla_&#x60;).  If you omit this parameter a new Player will be created..</param>
        /// <param name="account">ID of the Account this TransactionIntent is executed with, if one exists (starts with &#x60;acc_&#x60; or &#x60;dac_&#x60;).  When providing a Player and ChainID, you can omit this parameter..</param>
        /// <param name="policy">ID of the Policy that defines the gas sponsorship strategy (starts with &#x60;pol_&#x60;). If no Policy is provided, the own Account native token funds will be used to pay for gas..</param>
        /// <param name="externalOwnerAddress">Use this parameter to create a new Account for Player with the provided owner address.  If you omit this parameter and no Account exists for the Player, a custodial Account will be created..</param>
        /// <param name="optimistic">Set to &#x60;true&#x60; to indicate that the transactionIntent request should be resolved as soon as possible, after the transactionIntent is created and simulated and before it arrives on chain..</param>
        /// <param name="confirmationBlocks">Specify the number of confirmation blocks after which the confirmation webhook will be sent when the transaction arrives on-chain. Default is 5..</param>
        /// <param name="interactions">interactions (required).</param>
        public CreateTransactionIntentRequest(int chainId = default(int), string player = default(string), string account = default(string), string policy = default(string), string externalOwnerAddress = default(string), bool optimistic = default(bool), int confirmationBlocks = default(int), List<Interaction> interactions = default(List<Interaction>))
        {
            this.ChainId = chainId;
            // to ensure "interactions" is required (not null)
            if (interactions == null)
            {
                throw new ArgumentNullException("interactions is a required property for CreateTransactionIntentRequest and cannot be null");
            }
            this.Interactions = interactions;
            this.Player = player;
            this.Account = account;
            this.Policy = policy;
            this.ExternalOwnerAddress = externalOwnerAddress;
            this.Optimistic = optimistic;
            this.ConfirmationBlocks = confirmationBlocks;
        }

        /// <summary>
        /// The chain ID. Must be a [supported chain](/chains).
        /// </summary>
        /// <value>The chain ID. Must be a [supported chain](/chains).</value>
        /// <example>80001</example>
        [DataMember(Name = "chainId", IsRequired = true, EmitDefaultValue = true)]
        public int ChainId { get; set; }

        /// <summary>
        /// ID of the Player this TransactionIntent belongs to, if one exists (starts with &#x60;pla_&#x60;).  If you omit this parameter a new Player will be created.
        /// </summary>
        /// <value>ID of the Player this TransactionIntent belongs to, if one exists (starts with &#x60;pla_&#x60;).  If you omit this parameter a new Player will be created.</value>
        /// <example>&quot;pla_e0b84653-1741-4a3d-9e91-2b0fd2942f60&quot;</example>
        [DataMember(Name = "player", EmitDefaultValue = false)]
        public string Player { get; set; }

        /// <summary>
        /// ID of the Account this TransactionIntent is executed with, if one exists (starts with &#x60;acc_&#x60; or &#x60;dac_&#x60;).  When providing a Player and ChainID, you can omit this parameter.
        /// </summary>
        /// <value>ID of the Account this TransactionIntent is executed with, if one exists (starts with &#x60;acc_&#x60; or &#x60;dac_&#x60;).  When providing a Player and ChainID, you can omit this parameter.</value>
        /// <example>&quot;acc_e1b24353-1741-4a3d-9e91-2b0fd2942f60&quot;</example>
        [DataMember(Name = "account", EmitDefaultValue = false)]
        public string Account { get; set; }

        /// <summary>
        /// ID of the Policy that defines the gas sponsorship strategy (starts with &#x60;pol_&#x60;). If no Policy is provided, the own Account native token funds will be used to pay for gas.
        /// </summary>
        /// <value>ID of the Policy that defines the gas sponsorship strategy (starts with &#x60;pol_&#x60;). If no Policy is provided, the own Account native token funds will be used to pay for gas.</value>
        /// <example>&quot;pol_7e07ae30-2a4d-48fa-803f-361da94905dd&quot;</example>
        [DataMember(Name = "policy", EmitDefaultValue = false)]
        public string Policy { get; set; }

        /// <summary>
        /// Use this parameter to create a new Account for Player with the provided owner address.  If you omit this parameter and no Account exists for the Player, a custodial Account will be created.
        /// </summary>
        /// <value>Use this parameter to create a new Account for Player with the provided owner address.  If you omit this parameter and no Account exists for the Player, a custodial Account will be created.</value>
        /// <example>&quot;0x1234567890abcdef1234567890abcdef12345678&quot;</example>
        [DataMember(Name = "externalOwnerAddress", EmitDefaultValue = false)]
        public string ExternalOwnerAddress { get; set; }

        /// <summary>
        /// Set to &#x60;true&#x60; to indicate that the transactionIntent request should be resolved as soon as possible, after the transactionIntent is created and simulated and before it arrives on chain.
        /// </summary>
        /// <value>Set to &#x60;true&#x60; to indicate that the transactionIntent request should be resolved as soon as possible, after the transactionIntent is created and simulated and before it arrives on chain.</value>
        /// <example>true</example>
        [DataMember(Name = "optimistic", EmitDefaultValue = true)]
        public bool Optimistic { get; set; }

        /// <summary>
        /// Specify the number of confirmation blocks after which the confirmation webhook will be sent when the transaction arrives on-chain. Default is 5.
        /// </summary>
        /// <value>Specify the number of confirmation blocks after which the confirmation webhook will be sent when the transaction arrives on-chain. Default is 5.</value>
        /// <example>5</example>
        [DataMember(Name = "confirmationBlocks", EmitDefaultValue = false)]
        public int ConfirmationBlocks { get; set; }

        /// <summary>
        /// Gets or Sets Interactions
        /// </summary>
        [DataMember(Name = "interactions", IsRequired = true, EmitDefaultValue = true)]
        public List<Interaction> Interactions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateTransactionIntentRequest {\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  Player: ").Append(Player).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  Policy: ").Append(Policy).Append("\n");
            sb.Append("  ExternalOwnerAddress: ").Append(ExternalOwnerAddress).Append("\n");
            sb.Append("  Optimistic: ").Append(Optimistic).Append("\n");
            sb.Append("  ConfirmationBlocks: ").Append(ConfirmationBlocks).Append("\n");
            sb.Append("  Interactions: ").Append(Interactions).Append("\n");
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
            return this.Equals(input as CreateTransactionIntentRequest);
        }

        /// <summary>
        /// Returns true if CreateTransactionIntentRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CreateTransactionIntentRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateTransactionIntentRequest input)
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
                    this.Player == input.Player ||
                    (this.Player != null &&
                    this.Player.Equals(input.Player))
                ) && 
                (
                    this.Account == input.Account ||
                    (this.Account != null &&
                    this.Account.Equals(input.Account))
                ) && 
                (
                    this.Policy == input.Policy ||
                    (this.Policy != null &&
                    this.Policy.Equals(input.Policy))
                ) && 
                (
                    this.ExternalOwnerAddress == input.ExternalOwnerAddress ||
                    (this.ExternalOwnerAddress != null &&
                    this.ExternalOwnerAddress.Equals(input.ExternalOwnerAddress))
                ) && 
                (
                    this.Optimistic == input.Optimistic ||
                    this.Optimistic.Equals(input.Optimistic)
                ) && 
                (
                    this.ConfirmationBlocks == input.ConfirmationBlocks ||
                    this.ConfirmationBlocks.Equals(input.ConfirmationBlocks)
                ) && 
                (
                    this.Interactions == input.Interactions ||
                    this.Interactions != null &&
                    input.Interactions != null &&
                    this.Interactions.SequenceEqual(input.Interactions)
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
                if (this.Player != null)
                {
                    hashCode = (hashCode * 59) + this.Player.GetHashCode();
                }
                if (this.Account != null)
                {
                    hashCode = (hashCode * 59) + this.Account.GetHashCode();
                }
                if (this.Policy != null)
                {
                    hashCode = (hashCode * 59) + this.Policy.GetHashCode();
                }
                if (this.ExternalOwnerAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ExternalOwnerAddress.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Optimistic.GetHashCode();
                hashCode = (hashCode * 59) + this.ConfirmationBlocks.GetHashCode();
                if (this.Interactions != null)
                {
                    hashCode = (hashCode * 59) + this.Interactions.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
