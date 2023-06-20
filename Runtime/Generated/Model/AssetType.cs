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
    /// Defines AssetType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssetType
    {
        /// <summary>
        /// Enum _1 for value: 1
        /// </summary>
        [EnumMember(Value = "1")]
        _1 = 1,

        /// <summary>
        /// Enum _2 for value: 2
        /// </summary>
        [EnumMember(Value = "2")]
        _2 = 2,

        /// <summary>
        /// Enum _3 for value: 3
        /// </summary>
        [EnumMember(Value = "3")]
        _3 = 3,

        /// <summary>
        /// Enum _4 for value: 4
        /// </summary>
        [EnumMember(Value = "4")]
        _4 = 4

    }

}