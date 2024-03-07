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
    /// AuthPlayerResponse
    /// </summary>
    [DataContract(Name = "AuthPlayerResponse")]
    public partial class AuthPlayerResponse : IEquatable<AuthPlayerResponse>
    {

        /// <summary>
        /// Gets or Sets Object
        /// </summary>
        [DataMember(Name = "object", IsRequired = true, EmitDefaultValue = true)]
        public EntityTypePLAYER Object { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthPlayerResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AuthPlayerResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthPlayerResponse" /> class.
        /// </summary>
        /// <param name="player">player.</param>
        /// <param name="id">id (required).</param>
        /// <param name="_object">_object (required).</param>
        /// <param name="createdAt">createdAt (required).</param>
        /// <param name="linkedAccounts">linkedAccounts (required).</param>
        public AuthPlayerResponse(AuthPlayerResponsePlayer player = default(AuthPlayerResponsePlayer), string id = default(string), EntityTypePLAYER _object = default(EntityTypePLAYER), int createdAt = default(int), List<LinkedAccountResponse> linkedAccounts = default(List<LinkedAccountResponse>))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for AuthPlayerResponse and cannot be null");
            }
            this.Id = id;
            this.Object = _object;
            this.CreatedAt = createdAt;
            // to ensure "linkedAccounts" is required (not null)
            if (linkedAccounts == null)
            {
                throw new ArgumentNullException("linkedAccounts is a required property for AuthPlayerResponse and cannot be null");
            }
            this.LinkedAccounts = linkedAccounts;
            this.Player = player;
        }

        /// <summary>
        /// Gets or Sets Player
        /// </summary>
        [DataMember(Name = "player", EmitDefaultValue = false)]
        public AuthPlayerResponsePlayer Player { get; set; }

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
        /// Gets or Sets LinkedAccounts
        /// </summary>
        [DataMember(Name = "linkedAccounts", IsRequired = true, EmitDefaultValue = true)]
        public List<LinkedAccountResponse> LinkedAccounts { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AuthPlayerResponse {\n");
            sb.Append("  Player: ").Append(Player).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Object: ").Append(Object).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  LinkedAccounts: ").Append(LinkedAccounts).Append("\n");
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
            return this.Equals(input as AuthPlayerResponse);
        }

        /// <summary>
        /// Returns true if AuthPlayerResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthPlayerResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthPlayerResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Player == input.Player ||
                    (this.Player != null &&
                    this.Player.Equals(input.Player))
                ) && 
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
                    this.LinkedAccounts == input.LinkedAccounts ||
                    this.LinkedAccounts != null &&
                    input.LinkedAccounts != null &&
                    this.LinkedAccounts.SequenceEqual(input.LinkedAccounts)
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
                if (this.Player != null)
                {
                    hashCode = (hashCode * 59) + this.Player.GetHashCode();
                }
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Object.GetHashCode();
                hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                if (this.LinkedAccounts != null)
                {
                    hashCode = (hashCode * 59) + this.LinkedAccounts.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}