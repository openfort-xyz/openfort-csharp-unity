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
        SMART_ACCOUNT
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

    public class RecoveryMethodDetails
    {
        public string PasskeyId { get; set; }
        public string PasskeyEnv { get; set; }
    }

    public class EmbeddedAccount
    {
        public string User { get; set; }
        public string Id { get; set; }
        public ChainType ChainType { get; set; }
        public string Address { get; set; }
        public long? CreatedAt { get; set; }
        public string ImplementationType { get; set; }
        public string FactoryAddress { get; set; }
        public string Salt { get; set; }
        public AccountType AccountType { get; set; }
        public RecoveryMethod RecoveryMethod { get; set; }
        public RecoveryMethodDetails RecoveryMethodDetails { get; set; }
        public int? ChainId { get; set; }

    }
}
