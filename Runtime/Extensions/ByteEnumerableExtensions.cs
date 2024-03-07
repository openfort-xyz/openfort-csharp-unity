using Org.BouncyCastle.Math;
using System.Collections.Generic;
using System.Linq;

namespace Openfort.Extensions
{
	public static class ByteEnumerableExtensions
	{
        const string prefix = "0x";

        public static string ToHex(this IEnumerable<byte> obj) => ByteEnumerableExtensions.prefix + string.Concat(obj.Select(x => x.ToString("x2")));

        public static string ToHex(this BigInteger obj) => ByteEnumerableExtensions.prefix + obj.ToString(16);

        public static IEnumerable<byte> Concat(this BigInteger a, BigInteger b) => a.ToByteArray().Concat(b.ToByteArray());

        public static IEnumerable<byte> Append(this IEnumerable<byte> obj, byte a) => obj.Concat(new byte[] { a });

        public static string TrimHexPrefix(this string s) => s.StartsWith("0x") ? s.Substring(2) : s;
    }
}
