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
    /// Enum of the supporting OAuth providers.
    /// </summary>
    /// <value>Enum of the supporting OAuth providers.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AuthProvider
    {
        /// <summary>
        /// Enum Email for value: email
        /// </summary>
        [EnumMember(Value = "email")]
        Email = 1,

        /// <summary>
        /// Enum Accelbyte for value: accelbyte
        /// </summary>
        [EnumMember(Value = "accelbyte")]
        Accelbyte = 2,

        /// <summary>
        /// Enum Firebase for value: firebase
        /// </summary>
        [EnumMember(Value = "firebase")]
        Firebase = 3,

        /// <summary>
        /// Enum Google for value: google
        /// </summary>
        [EnumMember(Value = "google")]
        Google = 4,

        /// <summary>
        /// Enum Lootlocker for value: lootlocker
        /// </summary>
        [EnumMember(Value = "lootlocker")]
        Lootlocker = 5,

        /// <summary>
        /// Enum Playfab for value: playfab
        /// </summary>
        [EnumMember(Value = "playfab")]
        Playfab = 6,

        /// <summary>
        /// Enum Wallet for value: wallet
        /// </summary>
        [EnumMember(Value = "wallet")]
        Wallet = 7

    }

}
