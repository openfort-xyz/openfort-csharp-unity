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
    /// Defines EmailTypeRequest
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EmailTypeRequest
    {
        /// <summary>
        /// Enum EmailVerification for value: emailVerification
        /// </summary>
        [EnumMember(Value = "emailVerification")]
        EmailVerification = 1,

        /// <summary>
        /// Enum PasswordReset for value: passwordReset
        /// </summary>
        [EnumMember(Value = "passwordReset")]
        PasswordReset = 2

    }

}
