using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Openfort.OpenfortSDK.Model
{
    /// <summary>
    /// Session information
    /// </summary>
    [Preserve]
    [DataContract(Name = "Session")]
    public partial class Session : IEquatable<Session>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Session" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public Session() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Session" /> class.
        /// </summary>
        public Session(
            string token,
            string userId,
            string id = null,
            string expiresAt = null,
            string createdAt = null,
            string updatedAt = null)
        {
            this.Token = token;
            this.UserId = userId;
            this.Id = id;
            this.ExpiresAt = expiresAt;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Session identifier
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Session token for authentication
        /// </summary>
        [DataMember(Name = "token", IsRequired = true, EmitDefaultValue = true)]
        public string Token { get; set; }

        /// <summary>
        /// User ID associated with this session
        /// </summary>
        [DataMember(Name = "userId", IsRequired = true, EmitDefaultValue = true)]
        public string UserId { get; set; }

        /// <summary>
        /// ISO timestamp when the session expires
        /// </summary>
        [DataMember(Name = "expiresAt", EmitDefaultValue = false)]
        public string ExpiresAt { get; set; }

        /// <summary>
        /// ISO timestamp when the session was created
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// ISO timestamp when the session was last updated
        /// </summary>
        [DataMember(Name = "updatedAt", EmitDefaultValue = false)]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Session {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Token: ").Append(Token).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  ExpiresAt: ").Append(ExpiresAt).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        public override bool Equals(object input)
        {
            return this.Equals(input as Session);
        }

        /// <summary>
        /// Returns true if Session instances are equal
        /// </summary>
        public bool Equals(Session input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (this.Id == input.Id || (this.Id != null && this.Id.Equals(input.Id))) &&
                (this.Token == input.Token || (this.Token != null && this.Token.Equals(input.Token))) &&
                (this.UserId == input.UserId || (this.UserId != null && this.UserId.Equals(input.UserId))) &&
                (this.ExpiresAt == input.ExpiresAt || (this.ExpiresAt != null && this.ExpiresAt.Equals(input.ExpiresAt))) &&
                (this.CreatedAt == input.CreatedAt || (this.CreatedAt != null && this.CreatedAt.Equals(input.CreatedAt))) &&
                (this.UpdatedAt == input.UpdatedAt || (this.UpdatedAt != null && this.UpdatedAt.Equals(input.UpdatedAt)));
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 41;
                if (this.Id != null) hashCode = (hashCode * 59) + this.Id.GetHashCode();
                if (this.Token != null) hashCode = (hashCode * 59) + this.Token.GetHashCode();
                if (this.UserId != null) hashCode = (hashCode * 59) + this.UserId.GetHashCode();
                if (this.ExpiresAt != null) hashCode = (hashCode * 59) + this.ExpiresAt.GetHashCode();
                if (this.CreatedAt != null) hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                if (this.UpdatedAt != null) hashCode = (hashCode * 59) + this.UpdatedAt.GetHashCode();
                return hashCode;
            }
        }
    }
}
