using System;
using Openfort.OpenfortSDK.Model;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    internal class InitRequest
    {
        public string publishableKey;
        public string shieldPublishableKey;
        public string shieldEncryptionKey;
        public bool shieldDebug;
        public string backendUrl;
        public string iframeUrl;
        public string shieldUrl;
    }
}
