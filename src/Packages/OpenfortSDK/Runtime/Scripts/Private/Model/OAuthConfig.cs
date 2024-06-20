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
    /// OAuthConfig
    /// </summary>
    [JsonConverter(typeof(OAuthConfigJsonConverter))]
    [DataContract(Name = "OAuthConfig")]
    public partial class OAuthConfig : AbstractOpenAPISchema, IEquatable<OAuthConfig>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthConfig" /> class
        /// with the <see cref="SupabaseAuthConfig" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of SupabaseAuthConfig.</param>
        public OAuthConfig(SupabaseAuthConfig actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthConfig" /> class
        /// with the <see cref="OIDCAuthConfig" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of OIDCAuthConfig.</param>
        public OAuthConfig(OIDCAuthConfig actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthConfig" /> class
        /// with the <see cref="AccelbyteOAuthConfig" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of AccelbyteOAuthConfig.</param>
        public OAuthConfig(AccelbyteOAuthConfig actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthConfig" /> class
        /// with the <see cref="GoogleOAuthConfig" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of GoogleOAuthConfig.</param>
        public OAuthConfig(GoogleOAuthConfig actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthConfig" /> class
        /// with the <see cref="TwitterOAuthConfig" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of TwitterOAuthConfig.</param>
        public OAuthConfig(TwitterOAuthConfig actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthConfig" /> class
        /// with the <see cref="FacebookOAuthConfig" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of FacebookOAuthConfig.</param>
        public OAuthConfig(FacebookOAuthConfig actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthConfig" /> class
        /// with the <see cref="PlayFabOAuthConfig" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of PlayFabOAuthConfig.</param>
        public OAuthConfig(PlayFabOAuthConfig actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthConfig" /> class
        /// with the <see cref="FirebaseOAuthConfig" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of FirebaseOAuthConfig.</param>
        public OAuthConfig(FirebaseOAuthConfig actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthConfig" /> class
        /// with the <see cref="CustomAuthConfig" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of CustomAuthConfig.</param>
        public OAuthConfig(CustomAuthConfig actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType = "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthConfig" /> class
        /// with the <see cref="LootLockerOAuthConfig" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of LootLockerOAuthConfig.</param>
        public OAuthConfig(LootLockerOAuthConfig actualInstance)
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
                if (value.GetType() == typeof(AccelbyteOAuthConfig))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(CustomAuthConfig))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(FacebookOAuthConfig))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(FirebaseOAuthConfig))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(GoogleOAuthConfig))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(LootLockerOAuthConfig))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(OIDCAuthConfig))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(PlayFabOAuthConfig))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(SupabaseAuthConfig))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(TwitterOAuthConfig))
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: AccelbyteOAuthConfig, CustomAuthConfig, FacebookOAuthConfig, FirebaseOAuthConfig, GoogleOAuthConfig, LootLockerOAuthConfig, OIDCAuthConfig, PlayFabOAuthConfig, SupabaseAuthConfig, TwitterOAuthConfig");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `SupabaseAuthConfig`. If the actual instance is not `SupabaseAuthConfig`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of SupabaseAuthConfig</returns>
        public SupabaseAuthConfig GetSupabaseAuthConfig()
        {
            return (SupabaseAuthConfig)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `OIDCAuthConfig`. If the actual instance is not `OIDCAuthConfig`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of OIDCAuthConfig</returns>
        public OIDCAuthConfig GetOIDCAuthConfig()
        {
            return (OIDCAuthConfig)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `AccelbyteOAuthConfig`. If the actual instance is not `AccelbyteOAuthConfig`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of AccelbyteOAuthConfig</returns>
        public AccelbyteOAuthConfig GetAccelbyteOAuthConfig()
        {
            return (AccelbyteOAuthConfig)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `GoogleOAuthConfig`. If the actual instance is not `GoogleOAuthConfig`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of GoogleOAuthConfig</returns>
        public GoogleOAuthConfig GetGoogleOAuthConfig()
        {
            return (GoogleOAuthConfig)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `TwitterOAuthConfig`. If the actual instance is not `TwitterOAuthConfig`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of TwitterOAuthConfig</returns>
        public TwitterOAuthConfig GetTwitterOAuthConfig()
        {
            return (TwitterOAuthConfig)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `FacebookOAuthConfig`. If the actual instance is not `FacebookOAuthConfig`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of FacebookOAuthConfig</returns>
        public FacebookOAuthConfig GetFacebookOAuthConfig()
        {
            return (FacebookOAuthConfig)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `PlayFabOAuthConfig`. If the actual instance is not `PlayFabOAuthConfig`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of PlayFabOAuthConfig</returns>
        public PlayFabOAuthConfig GetPlayFabOAuthConfig()
        {
            return (PlayFabOAuthConfig)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `FirebaseOAuthConfig`. If the actual instance is not `FirebaseOAuthConfig`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of FirebaseOAuthConfig</returns>
        public FirebaseOAuthConfig GetFirebaseOAuthConfig()
        {
            return (FirebaseOAuthConfig)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `CustomAuthConfig`. If the actual instance is not `CustomAuthConfig`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of CustomAuthConfig</returns>
        public CustomAuthConfig GetCustomAuthConfig()
        {
            return (CustomAuthConfig)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `LootLockerOAuthConfig`. If the actual instance is not `LootLockerOAuthConfig`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of LootLockerOAuthConfig</returns>
        public LootLockerOAuthConfig GetLootLockerOAuthConfig()
        {
            return (LootLockerOAuthConfig)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OAuthConfig {\n");
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
            return JsonConvert.SerializeObject(this.ActualInstance, OAuthConfig.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of OAuthConfig
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of OAuthConfig</returns>
        public static OAuthConfig FromJson(string jsonString)
        {
            OAuthConfig newOAuthConfig = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newOAuthConfig;
            }

            try
            {
                newOAuthConfig = new OAuthConfig(JsonConvert.DeserializeObject<AccelbyteOAuthConfig>(jsonString, OAuthConfig.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newOAuthConfig;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into AccelbyteOAuthConfig: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newOAuthConfig = new OAuthConfig(JsonConvert.DeserializeObject<CustomAuthConfig>(jsonString, OAuthConfig.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newOAuthConfig;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into CustomAuthConfig: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newOAuthConfig = new OAuthConfig(JsonConvert.DeserializeObject<FacebookOAuthConfig>(jsonString, OAuthConfig.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newOAuthConfig;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into FacebookOAuthConfig: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newOAuthConfig = new OAuthConfig(JsonConvert.DeserializeObject<FirebaseOAuthConfig>(jsonString, OAuthConfig.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newOAuthConfig;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into FirebaseOAuthConfig: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newOAuthConfig = new OAuthConfig(JsonConvert.DeserializeObject<GoogleOAuthConfig>(jsonString, OAuthConfig.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newOAuthConfig;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into GoogleOAuthConfig: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newOAuthConfig = new OAuthConfig(JsonConvert.DeserializeObject<LootLockerOAuthConfig>(jsonString, OAuthConfig.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newOAuthConfig;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into LootLockerOAuthConfig: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newOAuthConfig = new OAuthConfig(JsonConvert.DeserializeObject<OIDCAuthConfig>(jsonString, OAuthConfig.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newOAuthConfig;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into OIDCAuthConfig: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newOAuthConfig = new OAuthConfig(JsonConvert.DeserializeObject<PlayFabOAuthConfig>(jsonString, OAuthConfig.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newOAuthConfig;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into PlayFabOAuthConfig: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newOAuthConfig = new OAuthConfig(JsonConvert.DeserializeObject<SupabaseAuthConfig>(jsonString, OAuthConfig.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newOAuthConfig;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into SupabaseAuthConfig: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newOAuthConfig = new OAuthConfig(JsonConvert.DeserializeObject<TwitterOAuthConfig>(jsonString, OAuthConfig.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newOAuthConfig;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into TwitterOAuthConfig: {1}", jsonString, exception.ToString()));
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
            return this.Equals(input as OAuthConfig);
        }

        /// <summary>
        /// Returns true if OAuthConfig instances are equal
        /// </summary>
        /// <param name="input">Instance of OAuthConfig to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OAuthConfig input)
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
    /// Custom JSON converter for OAuthConfig
    /// </summary>
    public class OAuthConfigJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(OAuthConfig).GetMethod("ToJson").Invoke(value, null)));
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
                return OAuthConfig.FromJson(JObject.Load(reader).ToString(Formatting.None));
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