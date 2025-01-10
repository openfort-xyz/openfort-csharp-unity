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
    /// ChildProjectListResponse
    /// </summary>
    [DataContract(Name = "ChildProjectListResponse")]
    public partial class ChildProjectListResponse : IEquatable<ChildProjectListResponse>
    {

        /// <summary>
        /// Gets or Sets Object
        /// </summary>
        [DataMember(Name = "object", IsRequired = true, EmitDefaultValue = true)]
        public ResponseTypeLIST Object { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChildProjectListResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ChildProjectListResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChildProjectListResponse" /> class.
        /// </summary>
        /// <param name="_object">_object (required).</param>
        /// <param name="url">url (required).</param>
        /// <param name="data">data (required).</param>
        /// <param name="start">start (required).</param>
        /// <param name="end">end (required).</param>
        /// <param name="total">total (required).</param>
        public ChildProjectListResponse(ResponseTypeLIST _object = default(ResponseTypeLIST), string url = default(string), List<ChildProjectResponse> data = default(List<ChildProjectResponse>), int start = default(int), int end = default(int), int total = default(int))
        {
            this.Object = _object;
            // to ensure "url" is required (not null)
            if (url == null)
            {
                throw new ArgumentNullException("url is a required property for ChildProjectListResponse and cannot be null");
            }
            this.Url = url;
            // to ensure "data" is required (not null)
            if (data == null)
            {
                throw new ArgumentNullException("data is a required property for ChildProjectListResponse and cannot be null");
            }
            this.Data = data;
            this.Start = start;
            this.End = end;
            this.Total = total;
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
        public List<ChildProjectResponse> Data { get; set; }

        /// <summary>
        /// Gets or Sets Start
        /// </summary>
        [DataMember(Name = "start", IsRequired = true, EmitDefaultValue = true)]
        public int Start { get; set; }

        /// <summary>
        /// Gets or Sets End
        /// </summary>
        [DataMember(Name = "end", IsRequired = true, EmitDefaultValue = true)]
        public int End { get; set; }

        /// <summary>
        /// Gets or Sets Total
        /// </summary>
        [DataMember(Name = "total", IsRequired = true, EmitDefaultValue = true)]
        public int Total { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ChildProjectListResponse {\n");
            sb.Append("  Object: ").Append(Object).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Start: ").Append(Start).Append("\n");
            sb.Append("  End: ").Append(End).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
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
            return this.Equals(input as ChildProjectListResponse);
        }

        /// <summary>
        /// Returns true if ChildProjectListResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of ChildProjectListResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChildProjectListResponse input)
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
                    this.Data != null &&
                    input.Data != null &&
                    this.Data.SequenceEqual(input.Data)
                ) &&
                (
                    this.Start == input.Start ||
                    this.Start.Equals(input.Start)
                ) &&
                (
                    this.End == input.End ||
                    this.End.Equals(input.End)
                ) &&
                (
                    this.Total == input.Total ||
                    this.Total.Equals(input.Total)
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
                hashCode = (hashCode * 59) + this.Start.GetHashCode();
                hashCode = (hashCode * 59) + this.End.GetHashCode();
                hashCode = (hashCode * 59) + this.Total.GetHashCode();
                return hashCode;
            }
        }

    }

}
