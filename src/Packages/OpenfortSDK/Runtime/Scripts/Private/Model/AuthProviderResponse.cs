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
    /// Defines AuthProviderResponse
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AuthProviderResponse
    {
        /// <summary>
        /// Enum Email for value: email
        /// </summary>
        [EnumMember(Value = "email")]
        Email = 1,

        /// <summary>
        /// Enum Wallet for value: wallet
        /// </summary>
        [EnumMember(Value = "wallet")]
        Wallet = 2,

        /// <summary>
        /// Enum Google for value: google
        /// </summary>
        [EnumMember(Value = "google")]
        Google = 3,

        /// <summary>
        /// Enum Twitter for value: twitter
        /// </summary>
        [EnumMember(Value = "twitter")]
        Twitter = 4,

        /// <summary>
        /// Enum Discord for value: discord
        /// </summary>
        [EnumMember(Value = "discord")]
        Discord = 5,

        /// <summary>
        /// Enum EpicGames for value: epic_games
        /// </summary>
        [EnumMember(Value = "epic_games")]
        EpicGames = 6,

        /// <summary>
        /// Enum Facebook for value: facebook
        /// </summary>
        [EnumMember(Value = "facebook")]
        Facebook = 7,

        /// <summary>
        /// Enum Telegram for value: telegram
        /// </summary>
        [EnumMember(Value = "telegram")]
        Telegram = 8,

        /// <summary>
        /// Enum Accelbyte for value: accelbyte
        /// </summary>
        [EnumMember(Value = "accelbyte")]
        Accelbyte = 9,

        /// <summary>
        /// Enum Firebase for value: firebase
        /// </summary>
        [EnumMember(Value = "firebase")]
        Firebase = 10,

        /// <summary>
        /// Enum Lootlocker for value: lootlocker
        /// </summary>
        [EnumMember(Value = "lootlocker")]
        Lootlocker = 11,

        /// <summary>
        /// Enum Playfab for value: playfab
        /// </summary>
        [EnumMember(Value = "playfab")]
        Playfab = 12,

        /// <summary>
        /// Enum Supabase for value: supabase
        /// </summary>
        [EnumMember(Value = "supabase")]
        Supabase = 13,

        /// <summary>
        /// Enum Custom for value: custom
        /// </summary>
        [EnumMember(Value = "custom")]
        Custom = 14,

        /// <summary>
        /// Enum Oidc for value: oidc
        /// </summary>
        [EnumMember(Value = "oidc")]
        Oidc = 15,

        /// <summary>
        /// Enum TelegramMiniApp for value: telegramMiniApp
        /// </summary>
        [EnumMember(Value = "telegramMiniApp")]
        TelegramMiniApp = 16

    }

}
