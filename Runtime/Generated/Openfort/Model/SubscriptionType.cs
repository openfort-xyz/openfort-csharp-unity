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
    /// Defines SubscriptionType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SubscriptionType
    {
        /// <summary>
        /// Enum Email for value: Email
        /// </summary>
        [EnumMember(Value = "Email")]
        Email = 1,

        /// <summary>
        /// Enum Webhook for value: Webhook
        /// </summary>
        [EnumMember(Value = "Webhook")]
        Webhook = 2

    }

}
