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
            RecoveryParams recoveryParams = null,
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
            RecoveryParams recoveryParams = null,
            int? chainId = null,
            ChainType? chainType = null,
            AccountType? accountType = null
        )
        {
            return new ConfigureEmbeddedWalletRequest(recoveryParams, chainId, chainType, accountType);
        }
    }

    /// <summary>
    /// Passkey info for recovery
    /// </summary>
    [Serializable]
    public class PasskeyInfo
    {
        /// <summary>
        /// The passkey ID
        /// </summary>
        public string passkeyId;

        /// <summary>
        /// The passkey key (optional, used during creation)
        /// </summary>
        public byte[] passkeyKey;

        public PasskeyInfo(string passkeyId, byte[] passkeyKey = null)
        {
            this.passkeyId = passkeyId;
            this.passkeyKey = passkeyKey;
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

        public AutomaticRecoveryParams(string encryptionSession = null)
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

    [Serializable]
    public class PasskeyRecoveryParams : RecoveryParams
    {
        public PasskeyInfo passkeyInfo;

        public PasskeyRecoveryParams(PasskeyInfo passkeyInfo = null)
        {
            this.recoveryMethod = RecoveryMethod.PASSKEY;
            this.passkeyInfo = passkeyInfo;
        }
    }
}