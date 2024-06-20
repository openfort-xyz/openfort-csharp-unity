using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class EthereumProviderRequest
    {
        /**
        * Options for the Ethereum provider request
        */
        public EthereumProviderOptions options;

        public EthereumProviderRequest(EthereumProviderOptions options = null)
        {
            this.options = options ?? new EthereumProviderOptions { announceProvider = true };
        }

        /**
        * Creates a new EthereumProviderRequest with the provided options
        */
        public static EthereumProviderRequest Create(EthereumProviderOptions options = null)
        {
            return new EthereumProviderRequest(options);
        }
    }

    [Serializable]
    public class EthereumProviderOptions
    {
        /**
        * Indicates whether to announce the provider
        */
        public bool announceProvider;

        /**
        * Policy for the Ethereum provider, can be null
        */
        public string policy;

        public EthereumProviderOptions(bool announceProvider = true, string policy = null)
        {
            this.announceProvider = announceProvider;
            this.policy = policy;
        }
    }
}
