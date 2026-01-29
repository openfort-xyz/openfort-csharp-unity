using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Openfort.OpenfortSDK.Model
{
    /// <summary>
    /// OAuth provider enumeration
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OAuthProvider
    {
        [EnumMember(Value = "google")]
        GOOGLE,

        [EnumMember(Value = "twitter")]
        TWITTER,

        [EnumMember(Value = "apple")]
        APPLE,

        [EnumMember(Value = "facebook")]
        FACEBOOK,

        [EnumMember(Value = "discord")]
        DISCORD,

        [EnumMember(Value = "epic_games")]
        EPIC_GAMES,

        [EnumMember(Value = "line")]
        LINE
    }

    /// <summary>
    /// Options for initializing OAuth
    /// </summary>
    [Serializable]
    public class InitializeOAuthOptions
    {
        /// <summary>
        /// A space-separated list of scopes granted to the OAuth application
        /// </summary>
        public string scopes;

        /// <summary>
        /// If set to true does not immediately redirect the current browser context
        /// </summary>
        public bool? skipBrowserRedirect;
    }

    /// <summary>
    /// Request for initializing OAuth authentication
    /// </summary>
    [Serializable]
    public class InitOAuthRequest
    {
        /// <summary>
        /// The OAuth provider to use
        /// </summary>
        public string provider;

        /// <summary>
        /// The URL to redirect to after authentication
        /// </summary>
        public string redirectTo;

        /// <summary>
        /// Optional OAuth options
        /// </summary>
        public InitializeOAuthOptions options;

        public InitOAuthRequest(OAuthProvider provider, string redirectTo, InitializeOAuthOptions options = null)
        {
            this.provider = provider.ToString().ToLower();
            if (provider == OAuthProvider.EPIC_GAMES)
            {
                this.provider = "epic_games";
            }
            this.redirectTo = redirectTo;
            this.options = options;
        }
    }

    /// <summary>
    /// Request for unlinking OAuth provider
    /// </summary>
    [Serializable]
    public class UnlinkOAuthRequest
    {
        /// <summary>
        /// The OAuth provider to unlink
        /// </summary>
        public string provider;

        public UnlinkOAuthRequest(OAuthProvider provider)
        {
            this.provider = provider.ToString().ToLower();
            if (provider == OAuthProvider.EPIC_GAMES)
            {
                this.provider = "epic_games";
            }
        }
    }
}
