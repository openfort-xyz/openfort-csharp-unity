using System;
using UnityEngine.Scripting;

namespace Openfort.OpenfortSDK.Model
{
    [Preserve]
    [Serializable]
    public class InitAuthResponse
    {
        /**
        * URL for the authentication response
        */
        public string url;

        /**
        * Key associated with the authentication response
        */
        public string key;

        public InitAuthResponse(string url, string key)
        {
            this.url = url;
            this.key = key;
        }

        /**
        * Creates a new InitAuthResponse with the provided url and key
        */
        public static InitAuthResponse Create(string url, string key)
        {
            return new InitAuthResponse(url, key);
        }
    }
}