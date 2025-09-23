using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class CreateEmbeddedWalletRequest
    {
        public AccountType accountType;
        public ChainType chainType;
        public int? chainId;
        public RecoveryParams recoveryParams;

        public CreateEmbeddedWalletRequest(
            AccountType accountType,
            ChainType chainType,
            RecoveryParams recoveryParams,
            int? chainId = null
        )
        {
            this.accountType = accountType;
            this.chainType = chainType;
            this.recoveryParams = recoveryParams;
            this.chainId = chainId;
        }

        public static CreateEmbeddedWalletRequest Create(
            AccountType accountType,
            ChainType chainType,
            RecoveryParams recoveryParams,
            int? chainId = null
        )
        {
            return new CreateEmbeddedWalletRequest(accountType, chainType, recoveryParams, chainId);
        }
    }
}