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
    /// OAuthInitRequestOptions
    /// </summary>
    [DataContract(Name = "OAuthInitRequest_options")]
    public partial class OAuthInitRequestOptions : IEquatable<OAuthInitRequestOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthInitRequestOptions" /> class.
        /// </summary>
        /// <param name="skipBrowserRedirect">If set to true does not immediately redirect the current browser context to visit the OAuth authorization page for the provider..</param>
        /// <param name="queryParams">An object of query params.</param>
        /// <param name="scopes">A space-separated list of scopes granted to the OAuth application..</param>
        /// <param name="redirectTo">A URL to send the user to after they are confirmed..</param>
        public OAuthInitRequestOptions(bool skipBrowserRedirect = default(bool), Dictionary<string, string> queryParams = default(Dictionary<string, string>), string scopes = default(string), string redirectTo = default(string))
        {
            this.SkipBrowserRedirect = skipBrowserRedirect;
            this.QueryParams = queryParams;
            this.Scopes = scopes;
            this.RedirectTo = redirectTo;
        }

        /// <summary>
        /// If set to true does not immediately redirect the current browser context to visit the OAuth authorization page for the provider.
        /// </summary>
        /// <value>If set to true does not immediately redirect the current browser context to visit the OAuth authorization page for the provider.</value>
        [DataMember(Name = "skipBrowserRedirect", EmitDefaultValue = true)]
        public bool SkipBrowserRedirect { get; set; }

        /// <summary>
        /// An object of query params
        /// </summary>
        /// <value>An object of query params</value>
        [DataMember(Name = "queryParams", EmitDefaultValue = false)]
        public Dictionary<string, string> QueryParams { get; set; }

        /// <summary>
        /// A space-separated list of scopes granted to the OAuth application.
        /// </summary>
        /// <value>A space-separated list of scopes granted to the OAuth application.</value>
        [DataMember(Name = "scopes", EmitDefaultValue = false)]
        public string Scopes { get; set; }

        /// <summary>
        /// A URL to send the user to after they are confirmed.
        /// </summary>
        /// <value>A URL to send the user to after they are confirmed.</value>
        [DataMember(Name = "redirectTo", EmitDefaultValue = false)]
        public string RedirectTo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OAuthInitRequestOptions {\n");
            sb.Append("  SkipBrowserRedirect: ").Append(SkipBrowserRedirect).Append("\n");
            sb.Append("  QueryParams: ").Append(QueryParams).Append("\n");
            sb.Append("  Scopes: ").Append(Scopes).Append("\n");
            sb.Append("  RedirectTo: ").Append(RedirectTo).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as OAuthInitRequestOptions);
        }

        /// <summary>
        /// Returns true if OAuthInitRequestOptions instances are equal
        /// </summary>
        /// <param name="input">Instance of OAuthInitRequestOptions to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OAuthInitRequestOptions input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.SkipBrowserRedirect == input.SkipBrowserRedirect ||
                    this.SkipBrowserRedirect.Equals(input.SkipBrowserRedirect)
                ) &&
                (
                    this.QueryParams == input.QueryParams ||
                    this.QueryParams != null &&
                    input.QueryParams != null &&
                    this.QueryParams.SequenceEqual(input.QueryParams)
                ) &&
                (
                    this.Scopes == input.Scopes ||
                    (this.Scopes != null &&
                    this.Scopes.Equals(input.Scopes))
                ) &&
                (
                    this.RedirectTo == input.RedirectTo ||
                    (this.RedirectTo != null &&
                    this.RedirectTo.Equals(input.RedirectTo))
                );
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
                hashCode = (hashCode * 59) + this.SkipBrowserRedirect.GetHashCode();
                if (this.QueryParams != null)
                {
                    hashCode = (hashCode * 59) + this.QueryParams.GetHashCode();
                }
                if (this.Scopes != null)
                {
                    hashCode = (hashCode * 59) + this.Scopes.GetHashCode();
                }
                if (this.RedirectTo != null)
                {
                    hashCode = (hashCode * 59) + this.RedirectTo.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}