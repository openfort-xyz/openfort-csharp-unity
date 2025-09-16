using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    internal class InitRequest
    {
        public string publishableKey;
        public string shieldPublishableKey;
        public bool shieldDebug;
        public string backendUrl;
        public string iframeUrl;
        public string shieldUrl;
    }
}
