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
    /// Enum of the supporting Basic Auth providers.
    /// </summary>
    /// <value>Enum of the supporting Basic Auth providers.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BasicAuthProvider
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
        Wallet = 2

    }

}
