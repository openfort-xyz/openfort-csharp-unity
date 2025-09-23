using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class RecoverEmbeddedWalletRequest
    {
        public string account;
        public RecoveryParams recoveryParams;

        public RecoverEmbeddedWalletRequest(
            string account,
            RecoveryParams recoveryParams
        )
        {
            this.account = account;
            this.recoveryParams = recoveryParams;
        }

        public static RecoverEmbeddedWalletRequest Create(
            string account,
            RecoveryParams recoveryParams
        )
        {
            return new RecoverEmbeddedWalletRequest(account, recoveryParams);
        }
    }
}