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
    /// Enum of the supporting third party auth providers.
    /// </summary>
    /// <value>Enum of the supporting third party auth providers.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ThirdPartyOAuthProvider
    {
        /// <summary>
        /// Enum Accelbyte for value: accelbyte
        /// </summary>
        [EnumMember(Value = "accelbyte")]
        Accelbyte = 1,

        /// <summary>
        /// Enum Firebase for value: firebase
        /// </summary>
        [EnumMember(Value = "firebase")]
        Firebase = 2,

        /// <summary>
        /// Enum Lootlocker for value: lootlocker
        /// </summary>
        [EnumMember(Value = "lootlocker")]
        Lootlocker = 3,

        /// <summary>
        /// Enum Playfab for value: playfab
        /// </summary>
        [EnumMember(Value = "playfab")]
        Playfab = 4,

        /// <summary>
        /// Enum Supabase for value: supabase
        /// </summary>
        [EnumMember(Value = "supabase")]
        Supabase = 5,

        /// <summary>
        /// Enum Custom for value: custom
        /// </summary>
        [EnumMember(Value = "custom")]
        Custom = 6,

        /// <summary>
        /// Enum Oidc for value: oidc
        /// </summary>
        [EnumMember(Value = "oidc")]
        Oidc = 7

    }

}