using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Openfort.OpenfortSDK.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChainType
    {
        [EnumMember(Value = "EVM")]
        EVM,

        [EnumMember(Value = "SVM")]
        SVM
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccountType
    {
        [EnumMember(Value = "Externally Owned Account")]
        EOA,

        [EnumMember(Value = "Smart Account")]
        SMART_ACCOUNT,

        [EnumMember(Value = "Delegated Account")]
        DELEGATED_ACCOUNT
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RecoveryMethod
    {
        [EnumMember(Value = "password")]
        PASSWORD,

        [EnumMember(Value = "automatic")]
        AUTOMATIC,

        [EnumMember(Value = "passkey")]
        PASSKEY
    }

    public class PasskeyEnv
    {
        public string Name { get; set; }
        public string Os { get; set; }
        public string OsVersion { get; set; }
        public string Device { get; set; }
    }

    public class RecoveryMethodDetails
    {
        public string PasskeyId { get; set; }
        public PasskeyEnv PasskeyEnv { get; set; }
    }

    public class EmbeddedAccount
    {
        public string Id { get; set; }
        public ChainType ChainType { get; set; }
        public string Address { get; set; }
        public long? CreatedAt { get; set; }
        public string ImplementationType { get; set; }
        public string FactoryAddress { get; set; }
        public string ImplementationAddress { get; set; }
        public string Salt { get; set; }
        public AccountType AccountType { get; set; }
        public RecoveryMethod? RecoveryMethod { get; set; }
        public RecoveryMethodDetails RecoveryMethodDetails { get; set; }
        public int? ChainId { get; set; }
        [System.Obsolete("Use Address instead")]
        public string OwnerAddress { get; set; }
        [System.Obsolete("Use ImplementationType instead")]
        public string Type { get; set; }
    }
}
