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
using System.Reflection;

namespace Openfort.Model
{
    /// <summary>
    /// PolicyResponseTransactionIntents
    /// </summary>
    [JsonConverter(typeof(PolicyResponseTransactionIntentsJsonConverter))]
    [DataContract(Name = "PolicyResponse_transaction_intents")]
    public partial class PolicyResponseTransactionIntents : AbstractOpenAPISchema, IEquatable<PolicyResponseTransactionIntents>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyResponseTransactionIntents" /> class
        /// with the <see cref="List{TransactionIntentResponse}" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of List&lt;TransactionIntentResponse&gt;.</param>
        public PolicyResponseTransactionIntents(List<TransactionIntentResponse> actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyResponseTransactionIntents" /> class
        /// with the <see cref="List{String}" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of List&lt;string&gt;.</param>
        public PolicyResponseTransactionIntents(List<string> actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
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
                if (value.GetType() == typeof(List<TransactionIntentResponse>))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(List<string>))
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: List<TransactionIntentResponse>, List<string>");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `List&lt;TransactionIntentResponse&gt;`. If the actual instance is not `List&lt;TransactionIntentResponse&gt;`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of List&lt;TransactionIntentResponse&gt;</returns>
        public List<TransactionIntentResponse> GetList()
        {
            return (List<TransactionIntentResponse>)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PolicyResponseTransactionIntents {\n");
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
            return JsonConvert.SerializeObject(this.ActualInstance, PolicyResponseTransactionIntents.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of PolicyResponseTransactionIntents
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of PolicyResponseTransactionIntents</returns>
        public static PolicyResponseTransactionIntents FromJson(string jsonString)
        {
            PolicyResponseTransactionIntents newPolicyResponseTransactionIntents = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newPolicyResponseTransactionIntents;
            }

            try
            {
                newPolicyResponseTransactionIntents = new PolicyResponseTransactionIntents(JsonConvert.DeserializeObject<List<TransactionIntentResponse>>(jsonString, PolicyResponseTransactionIntents.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newPolicyResponseTransactionIntents;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into List<TransactionIntentResponse>: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newPolicyResponseTransactionIntents = new PolicyResponseTransactionIntents(JsonConvert.DeserializeObject<List<string>>(jsonString, PolicyResponseTransactionIntents.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newPolicyResponseTransactionIntents;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into List<string>: {1}", jsonString, exception.ToString()));
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
            return this.Equals(input as PolicyResponseTransactionIntents);
        }

        /// <summary>
        /// Returns true if PolicyResponseTransactionIntents instances are equal
        /// </summary>
        /// <param name="input">Instance of PolicyResponseTransactionIntents to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PolicyResponseTransactionIntents input)
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
    /// Custom JSON converter for PolicyResponseTransactionIntents
    /// </summary>
    public class PolicyResponseTransactionIntentsJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(PolicyResponseTransactionIntents).GetMethod("ToJson").Invoke(value, null)));
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
            if(reader.TokenType != JsonToken.Null)
            {
                return PolicyResponseTransactionIntents.FromJson(JObject.Load(reader).ToString(Formatting.None));
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
