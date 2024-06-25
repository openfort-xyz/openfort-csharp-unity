using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class PoolOAuthRequest
    {
        /**
        * Key associated with the OAuth pooling request
        */
        public string key;

        public PoolOAuthRequest(string key)
        {
            this.key = key;
        }

        /**
        * Creates a new PoolOAuthRequest with the provided key
        */
        public static PoolOAuthRequest Create(string key)
        {
            return new PoolOAuthRequest(key);
        }
    }
}