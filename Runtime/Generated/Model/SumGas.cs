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
    /// SumGas
    /// </summary>
    [DataContract(Name = "SumGas")]
    public partial class SumGas : IEquatable<SumGas>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SumGas" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SumGas() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SumGas" /> class.
        /// </summary>
        /// <param name="_object">_object (required).</param>
        /// <param name="url">url (required).</param>
        /// <param name="sumGas">sumGas (required).</param>
        public SumGas(string _object = default(string), string url = default(string), double sumGas = default(double))
        {
            // to ensure "_object" is required (not null)
            if (_object == null)
            {
                throw new ArgumentNullException("_object is a required property for SumGas and cannot be null");
            }
            this.Object = _object;
            // to ensure "url" is required (not null)
            if (url == null)
            {
                throw new ArgumentNullException("url is a required property for SumGas and cannot be null");
            }
            this.Url = url;
            this._SumGas = sumGas;
        }

        /// <summary>
        /// Gets or Sets Object
        /// </summary>
        [DataMember(Name = "object", IsRequired = true, EmitDefaultValue = true)]
        public string Object { get; set; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = true)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets _SumGas
        /// </summary>
        [DataMember(Name = "sumGas", IsRequired = true, EmitDefaultValue = true)]
        public double _SumGas { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SumGas {\n");
            sb.Append("  Object: ").Append(Object).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  _SumGas: ").Append(_SumGas).Append("\n");
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
            return this.Equals(input as SumGas);
        }

        /// <summary>
        /// Returns true if SumGas instances are equal
        /// </summary>
        /// <param name="input">Instance of SumGas to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SumGas input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Object == input.Object ||
                    (this.Object != null &&
                    this.Object.Equals(input.Object))
                ) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this._SumGas == input._SumGas ||
                    this._SumGas.Equals(input._SumGas)
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
                if (this.Object != null)
                {
                    hashCode = (hashCode * 59) + this.Object.GetHashCode();
                }
                if (this.Url != null)
                {
                    hashCode = (hashCode * 59) + this.Url.GetHashCode();
                }
                hashCode = (hashCode * 59) + this._SumGas.GetHashCode();
                return hashCode;
            }
        }

    }

}
