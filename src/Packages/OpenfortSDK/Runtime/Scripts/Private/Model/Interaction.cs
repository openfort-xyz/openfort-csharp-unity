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
    /// Interaction
    /// </summary>
    [DataContract(Name = "Interaction")]
    public partial class Interaction : IEquatable<Interaction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Interaction" /> class.
        /// </summary>
        /// <param name="to">The address of the recipient of native tokens. Use *only* to transfer native tokens. If you provide one of a &#x60;pla_...&#x60;,  or &#x60;acc_...&#x60; it will be converted to the corresponding address..</param>
        /// <param name="value">The value intended to be sent with the transaction. Should be a stringified number in WEI (i.e. factor 10^18). * @example \&quot;1000000000000000000\&quot;.</param>
        /// <param name="contract">The contract ID you want to interact with. Must have been added to Openfort first, starts with &#x60;con_&#x60;..</param>
        /// <param name="functionName">The function name of the contract. Accepts a a function signature as well (e.g. mint(address))..</param>
        /// <param name="functionArgs">The function arguments of the contract, in string format. If you provide one of a &#x60;pla_...&#x60;, &#x60;con_...&#x60; or &#x60;acc_...&#x60; it will be converted to the corresponding address..</param>
        /// <param name="dataSuffix">Data to append to the end of the calldata. Useful for [adding a \&quot;domain\&quot; tag](https://opensea.notion.site/opensea/Seaport-Order-Attributions-ec2d69bf455041a5baa490941aad307f).</param>
        /// <param name="data">The encoded calldata of the contract..</param>
        public Interaction(string to = default(string), string value = default(string), string contract = default(string), string functionName = default(string), List<Object> functionArgs = default(List<Object>), string dataSuffix = default(string), string data = default(string))
        {
            this.To = to;
            this.Value = value;
            this.Contract = contract;
            this.FunctionName = functionName;
            this.FunctionArgs = functionArgs;
            this.DataSuffix = dataSuffix;
            this.Data = data;
        }

        /// <summary>
        /// The address of the recipient of native tokens. Use *only* to transfer native tokens. If you provide one of a &#x60;pla_...&#x60;,  or &#x60;acc_...&#x60; it will be converted to the corresponding address.
        /// </summary>
        /// <value>The address of the recipient of native tokens. Use *only* to transfer native tokens. If you provide one of a &#x60;pla_...&#x60;,  or &#x60;acc_...&#x60; it will be converted to the corresponding address.</value>
        [DataMember(Name = "to", EmitDefaultValue = false)]
        public string To { get; set; }

        /// <summary>
        /// The value intended to be sent with the transaction. Should be a stringified number in WEI (i.e. factor 10^18). * @example \&quot;1000000000000000000\&quot;
        /// </summary>
        /// <value>The value intended to be sent with the transaction. Should be a stringified number in WEI (i.e. factor 10^18). * @example \&quot;1000000000000000000\&quot;</value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        /// <summary>
        /// The contract ID you want to interact with. Must have been added to Openfort first, starts with &#x60;con_&#x60;.
        /// </summary>
        /// <value>The contract ID you want to interact with. Must have been added to Openfort first, starts with &#x60;con_&#x60;.</value>
        /// <example>&quot;con_0cddb398-1dc6-4e6f-8726-9ec7cea85f35&quot;</example>
        [DataMember(Name = "contract", EmitDefaultValue = false)]
        public string Contract { get; set; }

        /// <summary>
        /// The function name of the contract. Accepts a a function signature as well (e.g. mint(address)).
        /// </summary>
        /// <value>The function name of the contract. Accepts a a function signature as well (e.g. mint(address)).</value>
        /// <example>&quot;mint&quot;</example>
        [DataMember(Name = "functionName", EmitDefaultValue = false)]
        public string FunctionName { get; set; }

        /// <summary>
        /// The function arguments of the contract, in string format. If you provide one of a &#x60;pla_...&#x60;, &#x60;con_...&#x60; or &#x60;acc_...&#x60; it will be converted to the corresponding address.
        /// </summary>
        /// <value>The function arguments of the contract, in string format. If you provide one of a &#x60;pla_...&#x60;, &#x60;con_...&#x60; or &#x60;acc_...&#x60; it will be converted to the corresponding address.</value>
        [DataMember(Name = "functionArgs", EmitDefaultValue = false)]
        public List<Object> FunctionArgs { get; set; }

        /// <summary>
        /// Data to append to the end of the calldata. Useful for [adding a \&quot;domain\&quot; tag](https://opensea.notion.site/opensea/Seaport-Order-Attributions-ec2d69bf455041a5baa490941aad307f)
        /// </summary>
        /// <value>Data to append to the end of the calldata. Useful for [adding a \&quot;domain\&quot; tag](https://opensea.notion.site/opensea/Seaport-Order-Attributions-ec2d69bf455041a5baa490941aad307f)</value>
        [DataMember(Name = "dataSuffix", EmitDefaultValue = false)]
        public string DataSuffix { get; set; }

        /// <summary>
        /// The encoded calldata of the contract.
        /// </summary>
        /// <value>The encoded calldata of the contract.</value>
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public string Data { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Interaction {\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Contract: ").Append(Contract).Append("\n");
            sb.Append("  FunctionName: ").Append(FunctionName).Append("\n");
            sb.Append("  FunctionArgs: ").Append(FunctionArgs).Append("\n");
            sb.Append("  DataSuffix: ").Append(DataSuffix).Append("\n");
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
            return this.Equals(input as Interaction);
        }

        /// <summary>
        /// Returns true if Interaction instances are equal
        /// </summary>
        /// <param name="input">Instance of Interaction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Interaction input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.To == input.To ||
                    (this.To != null &&
                    this.To.Equals(input.To))
                ) &&
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) &&
                (
                    this.Contract == input.Contract ||
                    (this.Contract != null &&
                    this.Contract.Equals(input.Contract))
                ) &&
                (
                    this.FunctionName == input.FunctionName ||
                    (this.FunctionName != null &&
                    this.FunctionName.Equals(input.FunctionName))
                ) &&
                (
                    this.FunctionArgs == input.FunctionArgs ||
                    this.FunctionArgs != null &&
                    input.FunctionArgs != null &&
                    this.FunctionArgs.SequenceEqual(input.FunctionArgs)
                ) &&
                (
                    this.DataSuffix == input.DataSuffix ||
                    (this.DataSuffix != null &&
                    this.DataSuffix.Equals(input.DataSuffix))
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
                if (this.To != null)
                {
                    hashCode = (hashCode * 59) + this.To.GetHashCode();
                }
                if (this.Value != null)
                {
                    hashCode = (hashCode * 59) + this.Value.GetHashCode();
                }
                if (this.Contract != null)
                {
                    hashCode = (hashCode * 59) + this.Contract.GetHashCode();
                }
                if (this.FunctionName != null)
                {
                    hashCode = (hashCode * 59) + this.FunctionName.GetHashCode();
                }
                if (this.FunctionArgs != null)
                {
                    hashCode = (hashCode * 59) + this.FunctionArgs.GetHashCode();
                }
                if (this.DataSuffix != null)
                {
                    hashCode = (hashCode * 59) + this.DataSuffix.GetHashCode();
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
