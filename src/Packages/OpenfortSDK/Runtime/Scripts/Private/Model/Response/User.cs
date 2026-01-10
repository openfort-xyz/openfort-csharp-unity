using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Openfort.OpenfortSDK.Model
{
    /// <summary>
    /// User profile information
    /// </summary>
    [Preserve]
    [DataContract(Name = "User")]
    public partial class User : IEquatable<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public User() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        public User(
            string id,
            string email = null,
            string name = null,
            string image = null,
            bool? emailVerified = null,
            string createdAt = null,
            string updatedAt = null,
            bool? isAnonymous = null,
            string phoneNumber = null,
            bool? phoneNumberVerified = null)
        {
            this.Id = id;
            this.Email = email;
            this.Name = name;
            this.Image = image;
            this.EmailVerified = emailVerified;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.IsAnonymous = isAnonymous;
            this.PhoneNumber = phoneNumber;
            this.PhoneNumberVerified = phoneNumberVerified;
        }

        /// <summary>
        /// Unique user identifier
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// User's email address
        /// </summary>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        /// <summary>
        /// User's display name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// URL to user's profile image
        /// </summary>
        [DataMember(Name = "image", EmitDefaultValue = false)]
        public string Image { get; set; }

        /// <summary>
        /// Whether the user's email has been verified
        /// </summary>
        [DataMember(Name = "emailVerified", EmitDefaultValue = false)]
        public bool? EmailVerified { get; set; }

        /// <summary>
        /// ISO timestamp when the user was created
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// ISO timestamp when the user was last updated
        /// </summary>
        [DataMember(Name = "updatedAt", EmitDefaultValue = false)]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Whether the user is anonymous
        /// </summary>
        [DataMember(Name = "isAnonymous", EmitDefaultValue = false)]
        public bool? IsAnonymous { get; set; }

        /// <summary>
        /// User's phone number
        /// </summary>
        [DataMember(Name = "phoneNumber", EmitDefaultValue = false)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Whether the user's phone number has been verified
        /// </summary>
        [DataMember(Name = "phoneNumberVerified", EmitDefaultValue = false)]
        public bool? PhoneNumberVerified { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class User {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
            sb.Append("  EmailVerified: ").Append(EmailVerified).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  IsAnonymous: ").Append(IsAnonymous).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  PhoneNumberVerified: ").Append(PhoneNumberVerified).Append("\n");
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
            return this.Equals(input as User);
        }

        /// <summary>
        /// Returns true if User instances are equal
        /// </summary>
        public bool Equals(User input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (this.Id == input.Id || (this.Id != null && this.Id.Equals(input.Id))) &&
                (this.Email == input.Email || (this.Email != null && this.Email.Equals(input.Email))) &&
                (this.Name == input.Name || (this.Name != null && this.Name.Equals(input.Name))) &&
                (this.Image == input.Image || (this.Image != null && this.Image.Equals(input.Image))) &&
                (this.EmailVerified == input.EmailVerified || (this.EmailVerified != null && this.EmailVerified.Equals(input.EmailVerified))) &&
                (this.CreatedAt == input.CreatedAt || (this.CreatedAt != null && this.CreatedAt.Equals(input.CreatedAt))) &&
                (this.UpdatedAt == input.UpdatedAt || (this.UpdatedAt != null && this.UpdatedAt.Equals(input.UpdatedAt))) &&
                (this.IsAnonymous == input.IsAnonymous || (this.IsAnonymous != null && this.IsAnonymous.Equals(input.IsAnonymous))) &&
                (this.PhoneNumber == input.PhoneNumber || (this.PhoneNumber != null && this.PhoneNumber.Equals(input.PhoneNumber))) &&
                (this.PhoneNumberVerified == input.PhoneNumberVerified || (this.PhoneNumberVerified != null && this.PhoneNumberVerified.Equals(input.PhoneNumberVerified)));
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
                if (this.Email != null) hashCode = (hashCode * 59) + this.Email.GetHashCode();
                if (this.Name != null) hashCode = (hashCode * 59) + this.Name.GetHashCode();
                if (this.Image != null) hashCode = (hashCode * 59) + this.Image.GetHashCode();
                if (this.EmailVerified != null) hashCode = (hashCode * 59) + this.EmailVerified.GetHashCode();
                if (this.CreatedAt != null) hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                if (this.UpdatedAt != null) hashCode = (hashCode * 59) + this.UpdatedAt.GetHashCode();
                if (this.IsAnonymous != null) hashCode = (hashCode * 59) + this.IsAnonymous.GetHashCode();
                if (this.PhoneNumber != null) hashCode = (hashCode * 59) + this.PhoneNumber.GetHashCode();
                if (this.PhoneNumberVerified != null) hashCode = (hashCode * 59) + this.PhoneNumberVerified.GetHashCode();
                return hashCode;
            }
        }
    }
}
