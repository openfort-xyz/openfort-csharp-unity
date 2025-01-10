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
    /// TransactionIntentResponse
    /// </summary>
    [DataContract(Name = "TransactionIntentResponse")]
    public partial class TransactionIntentResponse : IEquatable<TransactionIntentResponse>
    {

        /// <summary>
        /// Gets or Sets Object
        /// </summary>
        [DataMember(Name = "object", IsRequired = true, EmitDefaultValue = true)]
        public EntityTypeTRANSACTIONINTENT Object { get; set; }

        /// <summary>
        /// Gets or Sets AbstractionType
        /// </summary>
        [DataMember(Name = "abstractionType", IsRequired = true, EmitDefaultValue = true)]
        public TransactionAbstractionType AbstractionType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionIntentResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransactionIntentResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionIntentResponse" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="_object">_object (required).</param>
        /// <param name="createdAt">createdAt (required).</param>
        /// <param name="updatedAt">The unix timestamp in seconds when the transactionIntent was created. (required).</param>
        /// <param name="chainId">The chain ID. (required).</param>
        /// <param name="abstractionType">abstractionType (required).</param>
        /// <param name="details">details.</param>
        /// <param name="userOperationHash">userOperationHash.</param>
        /// <param name="userOperation">userOperation.</param>
        /// <param name="response">response.</param>
        /// <param name="interactions">interactions.</param>
        /// <param name="nextAction">nextAction.</param>
        /// <param name="policy">policy.</param>
        /// <param name="player">player.</param>
        /// <param name="account">account (required).</param>
        public TransactionIntentResponse(string id = default(string), EntityTypeTRANSACTIONINTENT _object = default(EntityTypeTRANSACTIONINTENT), int createdAt = default(int), int updatedAt = default(int), int chainId = default(int), TransactionAbstractionType abstractionType = default(TransactionAbstractionType), TransactionIntentDetails details = default(TransactionIntentDetails), string userOperationHash = default(string), Object userOperation = default(Object), ResponseResponse response = default(ResponseResponse), List<Interaction> interactions = default(List<Interaction>), NextActionResponse nextAction = default(NextActionResponse), TransactionIntentResponsePolicy policy = default(TransactionIntentResponsePolicy), TransactionIntentResponsePlayer player = default(TransactionIntentResponsePlayer), TransactionIntentResponseAccount account = default(TransactionIntentResponseAccount))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for TransactionIntentResponse and cannot be null");
            }
            this.Id = id;
            this.Object = _object;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.ChainId = chainId;
            this.AbstractionType = abstractionType;
            // to ensure "account" is required (not null)
            if (account == null)
            {
                throw new ArgumentNullException("account is a required property for TransactionIntentResponse and cannot be null");
            }
            this.Account = account;
            this.Details = details;
            this.UserOperationHash = userOperationHash;
            this.UserOperation = userOperation;
            this.Response = response;
            this.Interactions = interactions;
            this.NextAction = nextAction;
            this.Policy = policy;
            this.Player = player;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "createdAt", IsRequired = true, EmitDefaultValue = true)]
        public int CreatedAt { get; set; }

        /// <summary>
        /// The unix timestamp in seconds when the transactionIntent was created.
        /// </summary>
        /// <value>The unix timestamp in seconds when the transactionIntent was created.</value>
        [DataMember(Name = "updatedAt", IsRequired = true, EmitDefaultValue = true)]
        public int UpdatedAt { get; set; }

        /// <summary>
        /// The chain ID.
        /// </summary>
        /// <value>The chain ID.</value>
        /// <example>5</example>
        [DataMember(Name = "chainId", IsRequired = true, EmitDefaultValue = true)]
        public int ChainId { get; set; }

        /// <summary>
        /// Gets or Sets Details
        /// </summary>
        [DataMember(Name = "details", EmitDefaultValue = false)]
        public TransactionIntentDetails Details { get; set; }

        /// <summary>
        /// Gets or Sets UserOperationHash
        /// </summary>
        [DataMember(Name = "userOperationHash", EmitDefaultValue = false)]
        [Obsolete]
        public string UserOperationHash { get; set; }

        /// <summary>
        /// Gets or Sets UserOperation
        /// </summary>
        [DataMember(Name = "userOperation", EmitDefaultValue = true)]
        [Obsolete]
        public Object UserOperation { get; set; }

        /// <summary>
        /// Gets or Sets Response
        /// </summary>
        [DataMember(Name = "response", EmitDefaultValue = false)]
        public ResponseResponse Response { get; set; }

        /// <summary>
        /// Gets or Sets Interactions
        /// </summary>
        [DataMember(Name = "interactions", EmitDefaultValue = false)]
        public List<Interaction> Interactions { get; set; }

        /// <summary>
        /// Gets or Sets NextAction
        /// </summary>
        [DataMember(Name = "nextAction", EmitDefaultValue = false)]
        public NextActionResponse NextAction { get; set; }

        /// <summary>
        /// Gets or Sets Policy
        /// </summary>
        [DataMember(Name = "policy", EmitDefaultValue = false)]
        public TransactionIntentResponsePolicy Policy { get; set; }

        /// <summary>
        /// Gets or Sets Player
        /// </summary>
        [DataMember(Name = "player", EmitDefaultValue = false)]
        public TransactionIntentResponsePlayer Player { get; set; }

        /// <summary>
        /// Gets or Sets Account
        /// </summary>
        [DataMember(Name = "account", IsRequired = true, EmitDefaultValue = true)]
        public TransactionIntentResponseAccount Account { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TransactionIntentResponse {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Object: ").Append(Object).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  AbstractionType: ").Append(AbstractionType).Append("\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
            sb.Append("  UserOperationHash: ").Append(UserOperationHash).Append("\n");
            sb.Append("  UserOperation: ").Append(UserOperation).Append("\n");
            sb.Append("  Response: ").Append(Response).Append("\n");
            sb.Append("  Interactions: ").Append(Interactions).Append("\n");
            sb.Append("  NextAction: ").Append(NextAction).Append("\n");
            sb.Append("  Policy: ").Append(Policy).Append("\n");
            sb.Append("  Player: ").Append(Player).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
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
            return this.Equals(input as TransactionIntentResponse);
        }

        /// <summary>
        /// Returns true if TransactionIntentResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of TransactionIntentResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransactionIntentResponse input)
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
                    this.Object == input.Object ||
                    this.Object.Equals(input.Object)
                ) &&
                (
                    this.CreatedAt == input.CreatedAt ||
                    this.CreatedAt.Equals(input.CreatedAt)
                ) &&
                (
                    this.UpdatedAt == input.UpdatedAt ||
                    this.UpdatedAt.Equals(input.UpdatedAt)
                ) &&
                (
                    this.ChainId == input.ChainId ||
                    this.ChainId.Equals(input.ChainId)
                ) &&
                (
                    this.AbstractionType == input.AbstractionType ||
                    this.AbstractionType.Equals(input.AbstractionType)
                ) &&
                (
                    this.Details == input.Details ||
                    (this.Details != null &&
                    this.Details.Equals(input.Details))
                ) &&
                (
                    this.UserOperationHash == input.UserOperationHash ||
                    (this.UserOperationHash != null &&
                    this.UserOperationHash.Equals(input.UserOperationHash))
                ) &&
                (
                    this.UserOperation == input.UserOperation ||
                    (this.UserOperation != null &&
                    this.UserOperation.Equals(input.UserOperation))
                ) &&
                (
                    this.Response == input.Response ||
                    (this.Response != null &&
                    this.Response.Equals(input.Response))
                ) &&
                (
                    this.Interactions == input.Interactions ||
                    this.Interactions != null &&
                    input.Interactions != null &&
                    this.Interactions.SequenceEqual(input.Interactions)
                ) &&
                (
                    this.NextAction == input.NextAction ||
                    (this.NextAction != null &&
                    this.NextAction.Equals(input.NextAction))
                ) &&
                (
                    this.Policy == input.Policy ||
                    (this.Policy != null &&
                    this.Policy.Equals(input.Policy))
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
                hashCode = (hashCode * 59) + this.Object.GetHashCode();
                hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                hashCode = (hashCode * 59) + this.UpdatedAt.GetHashCode();
                hashCode = (hashCode * 59) + this.ChainId.GetHashCode();
                hashCode = (hashCode * 59) + this.AbstractionType.GetHashCode();
                if (this.Details != null)
                {
                    hashCode = (hashCode * 59) + this.Details.GetHashCode();
                }
                if (this.UserOperationHash != null)
                {
                    hashCode = (hashCode * 59) + this.UserOperationHash.GetHashCode();
                }
                if (this.UserOperation != null)
                {
                    hashCode = (hashCode * 59) + this.UserOperation.GetHashCode();
                }
                if (this.Response != null)
                {
                    hashCode = (hashCode * 59) + this.Response.GetHashCode();
                }
                if (this.Interactions != null)
                {
                    hashCode = (hashCode * 59) + this.Interactions.GetHashCode();
                }
                if (this.NextAction != null)
                {
                    hashCode = (hashCode * 59) + this.NextAction.GetHashCode();
                }
                if (this.Policy != null)
                {
                    hashCode = (hashCode * 59) + this.Policy.GetHashCode();
                }
                if (this.Player != null)
                {
                    hashCode = (hashCode * 59) + this.Player.GetHashCode();
                }
                if (this.Account != null)
                {
                    hashCode = (hashCode * 59) + this.Account.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
