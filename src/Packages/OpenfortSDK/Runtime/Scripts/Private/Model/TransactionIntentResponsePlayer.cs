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
    /// The player ID (starts with pla_).
    /// </summary>
    [JsonConverter(typeof(TransactionIntentResponsePlayerJsonConverter))]
    [DataContract(Name = "TransactionIntentResponse_player")]
    public partial class TransactionIntentResponsePlayer : AbstractOpenAPISchema, IEquatable<TransactionIntentResponsePlayer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionIntentResponsePlayer" /> class
        /// with the <see cref="Player" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of Player.</param>
        public TransactionIntentResponsePlayer(Player actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionIntentResponsePlayer" /> class
        /// with the <see cref="EntityIdResponse" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of EntityIdResponse.</param>
        public TransactionIntentResponsePlayer(EntityIdResponse actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "anyOf";
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
                if (value.GetType() == typeof(EntityIdResponse))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(Player))
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: EntityIdResponse, Player");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `Player`. If the actual instance is not `Player`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of Player</returns>
        public Player GetPlayer()
        {
            return (Player)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `EntityIdResponse`. If the actual instance is not `EntityIdResponse`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of EntityIdResponse</returns>
        public EntityIdResponse GetEntityIdResponse()
        {
            return (EntityIdResponse)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransactionIntentResponsePlayer {\n");
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
            return JsonConvert.SerializeObject(this.ActualInstance, TransactionIntentResponsePlayer.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of TransactionIntentResponsePlayer
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of TransactionIntentResponsePlayer</returns>
        public static TransactionIntentResponsePlayer FromJson(string jsonString)
        {
            TransactionIntentResponsePlayer newTransactionIntentResponsePlayer = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newTransactionIntentResponsePlayer;
            }

            try
            {
                newTransactionIntentResponsePlayer = new TransactionIntentResponsePlayer(JsonConvert.DeserializeObject<EntityIdResponse>(jsonString, TransactionIntentResponsePlayer.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newTransactionIntentResponsePlayer;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into EntityIdResponse: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newTransactionIntentResponsePlayer = new TransactionIntentResponsePlayer(JsonConvert.DeserializeObject<Player>(jsonString, TransactionIntentResponsePlayer.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newTransactionIntentResponsePlayer;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into Player: {1}", jsonString, exception.ToString()));
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
            return this.Equals(input as TransactionIntentResponsePlayer);
        }

        /// <summary>
        /// Returns true if TransactionIntentResponsePlayer instances are equal
        /// </summary>
        /// <param name="input">Instance of TransactionIntentResponsePlayer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransactionIntentResponsePlayer input)
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
    /// Custom JSON converter for TransactionIntentResponsePlayer
    /// </summary>
    public class TransactionIntentResponsePlayerJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(TransactionIntentResponsePlayer).GetMethod("ToJson").Invoke(value, null)));
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
                return TransactionIntentResponsePlayer.FromJson(JObject.Load(reader).ToString(Formatting.None));
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