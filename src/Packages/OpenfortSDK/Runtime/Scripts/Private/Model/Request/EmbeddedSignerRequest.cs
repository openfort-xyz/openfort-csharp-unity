using System;
using System.Runtime.Serialization;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class EmbeddedSignerRequest
    {
        /**
        * Chain ID
        */
        public int chainId;

        /**
        * Shield Authentication details
        */
        public ShieldAuthentication shieldAuthentication;

        /**
        * Recovery password
        */
        public string recoveryPassword;

        public EmbeddedSignerRequest(
            int chainId,
            ShieldAuthentication shieldAuthentication,
            string recoveryPassword = null
        )
        {
            this.chainId = chainId;
            this.shieldAuthentication = shieldAuthentication;
            this.recoveryPassword = recoveryPassword;
        }

        /**
        * Creates a new EmbeddedSignerRequest with the provided properties
        */
        public static EmbeddedSignerRequest Create(
            int chainId,
            ShieldAuthentication shieldAuthentication,
            string recoveryPassword = null
        )
        {
            return new EmbeddedSignerRequest(chainId, shieldAuthentication, recoveryPassword);
        }
    }

    [Serializable]
    public class ShieldAuthentication
    {
        /**
        * Authentication type
        */
        public AuthType auth;

        /**
        * Token
        */
        public string token;

        /**
        * Authentication provider
        */
        public string authProvider;

        /**
        * Token type
        */
        public string tokenType;

        public ShieldAuthentication(
            AuthType auth,
            string token,
            string authProvider = null,
            string tokenType = null
        )
        {
            this.auth = auth;
            this.token = token;
            this.authProvider = authProvider;
            this.tokenType = tokenType;
        }
    }

    public enum AuthType
    {
        /// <summary>
        /// Enum Openfort for value: openfort
        /// </summary>
        [EnumMember(Value = "openfort")]
        Openfort = 0,

        /// <summary>
        /// Enum Custom for value: custom
        /// </summary>
        [EnumMember(Value = "custom")]
        Custom = 1
    }
}
