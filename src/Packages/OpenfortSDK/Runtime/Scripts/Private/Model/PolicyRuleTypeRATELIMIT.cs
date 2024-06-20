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
    /// Defines PolicyRuleType.RATE_LIMIT
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PolicyRuleTypeRATELIMIT
    {
        /// <summary>
        /// Enum RateLimit for value: rate_limit
        /// </summary>
        [EnumMember(Value = "rate_limit")]
        RateLimit = 1

    }

}