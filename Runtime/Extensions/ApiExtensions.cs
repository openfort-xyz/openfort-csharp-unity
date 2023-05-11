using System;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using OpenfortSdk.Api;

namespace OpenfortSdk {
    public static class ApiExtensions : Object {
        public static async Task<AsymmetricCipherKeyPair> GenerateKeyPairAndCreateSessionAsync(this PlayersApi api, string playerUuid) {
            var keyPair = GenerateKeyPair();
            await api.CreateSessionAsync(playerUuid, FormatPublicKey(keyPair));
            return keyPair;
        }

        public static async Task<string> GeneratePrivateKeyAndCreateSessionAsync(this PlayersApi api, string playerUuid) {
            var keyPair = await api.GenerateKeyPairAndCreateSessionAsync(playerUuid);
            return FormatPrivateKey(keyPair);
        }

        public static AsymmetricCipherKeyPair GenerateKeyPairAndCreateSession(this PlayersApi api, string playerUuid) {
            var keyPair = GenerateKeyPair();
            api.CreateSession(playerUuid, FormatPublicKey(keyPair));
            return keyPair;
        }

        public static string GeneratePrivateKeyAndCreateSession(this PlayersApi api, string playerUuid) {
            var keyPair = api.GenerateKeyPairAndCreateSession(playerUuid);
            return FormatPrivateKey(keyPair);
        }

        static string ToHex(byte[] data) => String.Concat(data.Select(x => x.ToString("x2")));

        static AsymmetricCipherKeyPair GenerateKeyPair() {
            var curve = ECNamedCurveTable.GetByName("secp256k1");
            var domainParams = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H, curve.GetSeed());

            var secureRandom = new SecureRandom();
            var keyParams = new ECKeyGenerationParameters(domainParams, secureRandom);

            var generator = new ECKeyPairGenerator("ECDSA");
            generator.Init(keyParams);
            return generator.GenerateKeyPair();
        }

        static string FormatPrivateKey(AsymmetricCipherKeyPair keyPair) {
            var privateKey = keyPair.Private as ECPrivateKeyParameters;
            return ToHex(privateKey.D.ToByteArrayUnsigned());
        }

        static string FormatPublicKey(AsymmetricCipherKeyPair keyPair) {
            var publicKey = keyPair.Public as ECPublicKeyParameters;
            return ToHex(publicKey.Q.GetEncoded());
        }
    }
}