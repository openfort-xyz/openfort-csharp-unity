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
    /// Web3ConnectionResponse
    /// </summary>
    [DataContract(Name = "Web3ConnectionResponse")]
    public partial class Web3ConnectionResponse : IEquatable<Web3ConnectionResponse>
    {

        /// <summary>
        /// Gets or Sets Object
        /// </summary>
        [DataMember(Name = "object", IsRequired = true, EmitDefaultValue = true)]
        public EntityTypeWEB3CONNECTION Object { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Web3ConnectionResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Web3ConnectionResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Web3ConnectionResponse" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="_object">_object (required).</param>
        /// <param name="createdAt">createdAt (required).</param>
        /// <param name="disconnected">disconnected (required).</param>
        /// <param name="player">player (required).</param>
        public Web3ConnectionResponse(string id = default(string), EntityTypeWEB3CONNECTION _object = default(EntityTypeWEB3CONNECTION), int createdAt = default(int), bool disconnected = default(bool), Web3ConnectionResponsePlayer player = default(Web3ConnectionResponsePlayer))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for Web3ConnectionResponse and cannot be null");
            }
            this.Id = id;
            this.Object = _object;
            this.CreatedAt = createdAt;
            this.Disconnected = disconnected;
            // to ensure "player" is required (not null)
            if (player == null)
            {
                throw new ArgumentNullException("player is a required property for Web3ConnectionResponse and cannot be null");
            }
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
        /// Gets or Sets Disconnected
        /// </summary>
        [DataMember(Name = "disconnected", IsRequired = true, EmitDefaultValue = true)]
        public bool Disconnected { get; set; }

        /// <summary>
        /// Gets or Sets Player
        /// </summary>
        [DataMember(Name = "player", IsRequired = true, EmitDefaultValue = true)]
        public Web3ConnectionResponsePlayer Player { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Web3ConnectionResponse {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Object: ").Append(Object).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Disconnected: ").Append(Disconnected).Append("\n");
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
            return this.Equals(input as Web3ConnectionResponse);
        }

        /// <summary>
        /// Returns true if Web3ConnectionResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of Web3ConnectionResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Web3ConnectionResponse input)
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
                    this.Disconnected == input.Disconnected ||
                    this.Disconnected.Equals(input.Disconnected)
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
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Object.GetHashCode();
                hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                hashCode = (hashCode * 59) + this.Disconnected.GetHashCode();
                if (this.Player != null)
                {
                    hashCode = (hashCode * 59) + this.Player.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
