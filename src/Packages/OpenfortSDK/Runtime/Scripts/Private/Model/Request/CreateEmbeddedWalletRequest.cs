namespace Openfort.OpenfortSDK.Model
{
    public abstract class RecoveryParams
    {
        public RecoveryMethod RecoveryMethod { get; set; }
    }

    public class AutomaticRecoveryParams : RecoveryParams
    {
        public string EncryptionSession { get; set; }
    }

    public class PasswordRecoveryParams : RecoveryParams
    {
        public string Password { get; set; }
    }

    public class PasskeyRecoveryParams : RecoveryParams
    {
        public PasskeyInfo PasskeyInfo { get; set; }
    }

    public class PasskeyInfo
    {
        public string PasskeyId { get; set; }
        public string PasskeyEnv { get; set; }
        public byte[] PasskeyKey { get; set; }
    }

    public class CreateEmbeddedWalletRequest
    {
        public AccountType AccountType { get; set; }
        public ChainType ChainType { get; set; }
        public int? ChainId { get; set; }
        public RecoveryParams RecoveryParams { get; set; }
    }
}
