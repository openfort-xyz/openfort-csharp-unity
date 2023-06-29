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
    /// ContractRequest
    /// </summary>
    [DataContract(Name = "ContractRequest")]
    public partial class ContractRequest : IEquatable<ContractRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ContractRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractRequest" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="chainId">chainId (required).</param>
        /// <param name="address">address.</param>
        /// <param name="abi">abi.</param>
        /// <param name="publicVerification">publicVerification.</param>
        /// <param name="project">project.</param>
        public ContractRequest(string name = default(string), double chainId = default(double), string address = default(string), PrismaJsonValue abi = default(PrismaJsonValue), bool publicVerification = default(bool), string project = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for ContractRequest and cannot be null");
            }
            this.Name = name;
            this.ChainId = chainId;
            this.Address = address;
            this.Abi = abi;
            this.PublicVerification = publicVerification;
            this.Project = project;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets ChainId
        /// </summary>
        [DataMember(Name = "chain_id", IsRequired = true, EmitDefaultValue = true)]
        public double ChainId { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets Abi
        /// </summary>
        [DataMember(Name = "abi", EmitDefaultValue = true)]
        public PrismaJsonValue Abi { get; set; }

        /// <summary>
        /// Gets or Sets PublicVerification
        /// </summary>
        [DataMember(Name = "public_verification", EmitDefaultValue = true)]
        public bool PublicVerification { get; set; }

        /// <summary>
        /// Gets or Sets Project
        /// </summary>
        [DataMember(Name = "project", EmitDefaultValue = false)]
        public string Project { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ContractRequest {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Abi: ").Append(Abi).Append("\n");
            sb.Append("  PublicVerification: ").Append(PublicVerification).Append("\n");
            sb.Append("  Project: ").Append(Project).Append("\n");
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
            return this.Equals(input as ContractRequest);
        }

        /// <summary>
        /// Returns true if ContractRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of ContractRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ContractRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.ChainId == input.ChainId ||
                    this.ChainId.Equals(input.ChainId)
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.Abi == input.Abi ||
                    (this.Abi != null &&
                    this.Abi.Equals(input.Abi))
                ) && 
                (
                    this.PublicVerification == input.PublicVerification ||
                    this.PublicVerification.Equals(input.PublicVerification)
                ) && 
                (
                    this.Project == input.Project ||
                    (this.Project != null &&
                    this.Project.Equals(input.Project))
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ChainId.GetHashCode();
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
                }
                if (this.Abi != null)
                {
                    hashCode = (hashCode * 59) + this.Abi.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.PublicVerification.GetHashCode();
                if (this.Project != null)
                {
                    hashCode = (hashCode * 59) + this.Project.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
