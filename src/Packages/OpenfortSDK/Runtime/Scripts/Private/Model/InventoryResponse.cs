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
    /// InventoryResponse
    /// </summary>
    [DataContract(Name = "InventoryResponse")]
    public partial class InventoryResponse : IEquatable<InventoryResponse>
    {

        /// <summary>
        /// Gets or Sets Object
        /// </summary>
        [DataMember(Name = "object", IsRequired = true, EmitDefaultValue = true)]
        public EntityTypeINVENTORY Object { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected InventoryResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryResponse" /> class.
        /// </summary>
        /// <param name="_object">_object (required).</param>
        /// <param name="url">url (required).</param>
        /// <param name="data">data (required).</param>
        public InventoryResponse(EntityTypeINVENTORY _object = default(EntityTypeINVENTORY), string url = default(string), AssetInventory data = default(AssetInventory))
        {
            this.Object = _object;
            // to ensure "url" is required (not null)
            if (url == null)
            {
                throw new ArgumentNullException("url is a required property for InventoryResponse and cannot be null");
            }
            this.Url = url;
            // to ensure "data" is required (not null)
            if (data == null)
            {
                throw new ArgumentNullException("data is a required property for InventoryResponse and cannot be null");
            }
            this.Data = data;
        }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = true)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "data", IsRequired = true, EmitDefaultValue = true)]
        public AssetInventory Data { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class InventoryResponse {\n");
            sb.Append("  Object: ").Append(Object).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
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
            return this.Equals(input as InventoryResponse);
        }

        /// <summary>
        /// Returns true if InventoryResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of InventoryResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InventoryResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Object == input.Object ||
                    this.Object.Equals(input.Object)
                ) &&
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) &&
                (
                    this.Data == input.Data ||
                    (this.Data != null &&
                    this.Data.Equals(input.Data))
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
                hashCode = (hashCode * 59) + this.Object.GetHashCode();
                if (this.Url != null)
                {
                    hashCode = (hashCode * 59) + this.Url.GetHashCode();
                }
                if (this.Data != null)
                {
                    hashCode = (hashCode * 59) + this.Data.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
