using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Openfort.OpenfortSDK.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortOrdering
    {
        [EnumMember(Value = "asc")]
        ASC,

        [EnumMember(Value = "desc")]
        DESC
    }

    public class ListWalletsRequest
    {
        public string Address { get; set; }
        public AccountType? AccountType { get; set; }
        public ChainType? ChainType { get; set; }
        public int? ChainId { get; set; }
        public SortOrdering? SortOrder { get; set; }
        public int? Limit { get; set; }
        public int? Skip { get; set; }
    }
}
