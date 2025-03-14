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
    /// SIWEAuthenticateRequest
    /// </summary>
    [DataContract(Name = "SIWEAuthenticateRequest")]
    public partial class SIWEAuthenticateRequest : IEquatable<SIWEAuthenticateRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SIWEAuthenticateRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SIWEAuthenticateRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SIWEAuthenticateRequest" /> class.
        /// </summary>
        /// <param name="signature">Signature of the EIP-712 message with the user&#39;s wallet. (required).</param>
        /// <param name="message">The EIP-712 message to sign. (required).</param>
        /// <param name="walletClientType">The wallet client of the user (required).</param>
        /// <param name="connectorType">The connector type of the user (required).</param>
        public SIWEAuthenticateRequest(string signature = default(string), string message = default(string), string walletClientType = default(string), string connectorType = default(string))
        {
            // to ensure "signature" is required (not null)
            if (signature == null)
            {
                throw new ArgumentNullException("signature is a required property for SIWEAuthenticateRequest and cannot be null");
            }
            this.Signature = signature;
            // to ensure "message" is required (not null)
            if (message == null)
            {
                throw new ArgumentNullException("message is a required property for SIWEAuthenticateRequest and cannot be null");
            }
            this.Message = message;
            // to ensure "walletClientType" is required (not null)
            if (walletClientType == null)
            {
                throw new ArgumentNullException("walletClientType is a required property for SIWEAuthenticateRequest and cannot be null");
            }
            this.WalletClientType = walletClientType;
            // to ensure "connectorType" is required (not null)
            if (connectorType == null)
            {
                throw new ArgumentNullException("connectorType is a required property for SIWEAuthenticateRequest and cannot be null");
            }
            this.ConnectorType = connectorType;
        }

        /// <summary>
        /// Signature of the EIP-712 message with the user&#39;s wallet.
        /// </summary>
        /// <value>Signature of the EIP-712 message with the user&#39;s wallet.</value>
        /// <example>&quot;0x1773ca2e6514a795bc9549ffbdf73909b2cd0ba8eafe52a1751c3ee8d644458701debd502ee5b5a8fca24606eee42a2cc756a04958c7c189913184d46c48783e1b&quot;</example>
        [DataMember(Name = "signature", IsRequired = true, EmitDefaultValue = true)]
        public string Signature { get; set; }

        /// <summary>
        /// The EIP-712 message to sign.
        /// </summary>
        /// <value>The EIP-712 message to sign.</value>
        /// <example>&quot;demo.openfort.xyz wants you to sign in with your Ethereum account:&quot;</example>
        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = true)]
        public string Message { get; set; }

        /// <summary>
        /// The wallet client of the user
        /// </summary>
        /// <value>The wallet client of the user</value>
        /// <example>&quot;metamask&quot;</example>
        [DataMember(Name = "walletClientType", IsRequired = true, EmitDefaultValue = true)]
        public string WalletClientType { get; set; }

        /// <summary>
        /// The connector type of the user
        /// </summary>
        /// <value>The connector type of the user</value>
        /// <example>&quot;injected&quot;</example>
        [DataMember(Name = "connectorType", IsRequired = true, EmitDefaultValue = true)]
        public string ConnectorType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SIWEAuthenticateRequest {\n");
            sb.Append("  Signature: ").Append(Signature).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  WalletClientType: ").Append(WalletClientType).Append("\n");
            sb.Append("  ConnectorType: ").Append(ConnectorType).Append("\n");
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
            return this.Equals(input as SIWEAuthenticateRequest);
        }

        /// <summary>
        /// Returns true if SIWEAuthenticateRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of SIWEAuthenticateRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SIWEAuthenticateRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Signature == input.Signature ||
                    (this.Signature != null &&
                    this.Signature.Equals(input.Signature))
                ) &&
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) &&
                (
                    this.WalletClientType == input.WalletClientType ||
                    (this.WalletClientType != null &&
                    this.WalletClientType.Equals(input.WalletClientType))
                ) &&
                (
                    this.ConnectorType == input.ConnectorType ||
                    (this.ConnectorType != null &&
                    this.ConnectorType.Equals(input.ConnectorType))
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
                if (this.Signature != null)
                {
                    hashCode = (hashCode * 59) + this.Signature.GetHashCode();
                }
                if (this.Message != null)
                {
                    hashCode = (hashCode * 59) + this.Message.GetHashCode();
                }
                if (this.WalletClientType != null)
                {
                    hashCode = (hashCode * 59) + this.WalletClientType.GetHashCode();
                }
                if (this.ConnectorType != null)
                {
                    hashCode = (hashCode * 59) + this.ConnectorType.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
