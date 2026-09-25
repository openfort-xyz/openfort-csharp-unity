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
        * Fee sponsorship ID (pol_...) used to sponsor gas, can be null
        */
        public string feeSponsorship;

        public EthereumProviderOptions(bool announceProvider = true, string feeSponsorship = null)
        {
            this.announceProvider = announceProvider;
            this.feeSponsorship = feeSponsorship;
        }
    }
}
