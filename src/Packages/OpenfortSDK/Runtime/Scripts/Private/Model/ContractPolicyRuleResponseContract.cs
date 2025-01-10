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
using System.Reflection;

namespace Openfort.OpenfortSDK.Model
{
    /// <summary>
    /// ContractPolicyRuleResponseContract
    /// </summary>
    [JsonConverter(typeof(ContractPolicyRuleResponseContractJsonConverter))]
    [DataContract(Name = "ContractPolicyRuleResponse_contract")]
    public partial class ContractPolicyRuleResponseContract : AbstractOpenAPISchema, IEquatable<ContractPolicyRuleResponseContract>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractPolicyRuleResponseContract" /> class
        /// with the <see cref="ContractResponse" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of ContractResponse.</param>
        public ContractPolicyRuleResponseContract(ContractResponse actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "anyOf";
            if (actualInstance == null)
            {
                throw new ArgumentException("Invalid instance found. Must not be null.");
            }
            this.ActualInstance = actualInstance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractPolicyRuleResponseContract" /> class
        /// with the <see cref="PickContractResponseId" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of PickContractResponseId.</param>
        public ContractPolicyRuleResponseContract(PickContractResponseId actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "anyOf";
            if (actualInstance == null)
            {
                throw new ArgumentException("Invalid instance found. Must not be null.");
            }
            this.ActualInstance = actualInstance;
        }


        private Object _actualInstance;

        /// <summary>
        /// Gets or Sets ActualInstance
        /// </summary>
        public override Object ActualInstance
        {
            get
            {
                return _actualInstance;
            }
            set
            {
                if (value.GetType() == typeof(ContractResponse))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(PickContractResponseId))
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: ContractResponse, PickContractResponseId");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `ContractResponse`. If the actual instance is not `ContractResponse`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of ContractResponse</returns>
        public ContractResponse GetContractResponse()
        {
            return (ContractResponse)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `PickContractResponseId`. If the actual instance is not `PickContractResponseId`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of PickContractResponseId</returns>
        public PickContractResponseId GetPickContractResponseId()
        {
            return (PickContractResponseId)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ContractPolicyRuleResponseContract {\n");
            sb.Append("  ActualInstance: ").Append(this.ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this.ActualInstance, ContractPolicyRuleResponseContract.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of ContractPolicyRuleResponseContract
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of ContractPolicyRuleResponseContract</returns>
        public static ContractPolicyRuleResponseContract FromJson(string jsonString)
        {
            ContractPolicyRuleResponseContract newContractPolicyRuleResponseContract = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newContractPolicyRuleResponseContract;
            }

            try
            {
                newContractPolicyRuleResponseContract = new ContractPolicyRuleResponseContract(JsonConvert.DeserializeObject<ContractResponse>(jsonString, ContractPolicyRuleResponseContract.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newContractPolicyRuleResponseContract;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into ContractResponse: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newContractPolicyRuleResponseContract = new ContractPolicyRuleResponseContract(JsonConvert.DeserializeObject<PickContractResponseId>(jsonString, ContractPolicyRuleResponseContract.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newContractPolicyRuleResponseContract;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into PickContractResponseId: {1}", jsonString, exception.ToString()));
            }

            // no match found, throw an exception
            throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ContractPolicyRuleResponseContract);
        }

        /// <summary>
        /// Returns true if ContractPolicyRuleResponseContract instances are equal
        /// </summary>
        /// <param name="input">Instance of ContractPolicyRuleResponseContract to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ContractPolicyRuleResponseContract input)
        {
            if (input == null)
                return false;

            return this.ActualInstance.Equals(input.ActualInstance);
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
                if (this.ActualInstance != null)
                    hashCode = hashCode * 59 + this.ActualInstance.GetHashCode();
                return hashCode;
            }
        }

    }

    /// <summary>
    /// Custom JSON converter for ContractPolicyRuleResponseContract
    /// </summary>
    public class ContractPolicyRuleResponseContractJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(ContractPolicyRuleResponseContract).GetMethod("ToJson").Invoke(value, null)));
        }

        /// <summary>
        /// To convert a JSON string into an object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="objectType">Object type</param>
        /// <param name="existingValue">Existing value</param>
        /// <param name="serializer">JSON Serializer</param>
        /// <returns>The object converted from the JSON string</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.Null)
            {
                return ContractPolicyRuleResponseContract.FromJson(JObject.Load(reader).ToString(Formatting.None));
            }
            return null;
        }

        /// <summary>
        /// Check if the object can be converted
        /// </summary>
        /// <param name="objectType">Object type</param>
        /// <returns>True if the object can be converted</returns>
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }

}
