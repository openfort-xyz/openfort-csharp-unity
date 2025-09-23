using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class ConfigureEmbeddedWalletRequest
    {
        public int? chainId;
        public RecoveryParams recoveryParams;
        public ChainType? chainType;
        public AccountType? accountType;

        public ConfigureEmbeddedWalletRequest(
            RecoveryParams recoveryParams,
            int? chainId = null,
            ChainType? chainType = null,
            AccountType? accountType = null
        )
        {
            this.recoveryParams = recoveryParams;
            this.chainId = chainId;
            this.chainType = chainType;
            this.accountType = accountType;
        }

        public static ConfigureEmbeddedWalletRequest Create(
            RecoveryParams recoveryParams,
            int? chainId = null,
            ChainType? chainType = null,
            AccountType? accountType = null
        )
        {
            return new ConfigureEmbeddedWalletRequest(recoveryParams, chainId, chainType, accountType);
        }
    }

    [Serializable]
    public abstract class RecoveryParams
    {
        public RecoveryMethod recoveryMethod;
    }

    [Serializable]
    public class AutomaticRecoveryParams : RecoveryParams
    {
        public string encryptionSession;

        public AutomaticRecoveryParams(string encryptionSession)
        {
            this.recoveryMethod = RecoveryMethod.AUTOMATIC;
            this.encryptionSession = encryptionSession;
        }
    }

    [Serializable]
    public class PasswordRecoveryParams : RecoveryParams
    {
        public string password;

        public PasswordRecoveryParams(string password)
        {
            this.recoveryMethod = RecoveryMethod.PASSWORD;
            this.password = password;
        }
    }
}