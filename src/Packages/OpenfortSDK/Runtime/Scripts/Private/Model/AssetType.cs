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
    /// Defines AssetType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssetType
    {
        /// <summary>
        /// Enum ETH for value: ETH
        /// </summary>
        [EnumMember(Value = "ETH")]
        ETH = 1,

        /// <summary>
        /// Enum ERC20 for value: ERC20
        /// </summary>
        [EnumMember(Value = "ERC20")]
        ERC20 = 2,

        /// <summary>
        /// Enum ERC721 for value: ERC721
        /// </summary>
        [EnumMember(Value = "ERC721")]
        ERC721 = 3,

        /// <summary>
        /// Enum ERC1155 for value: ERC1155
        /// </summary>
        [EnumMember(Value = "ERC1155")]
        ERC1155 = 4

    }

}
