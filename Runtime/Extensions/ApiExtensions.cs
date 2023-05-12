using System;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using OpenfortSdk.Api;
using OpenfortSdk.Crypto;

namespace OpenfortSdk
{
    public static class ApiExtensions : Object
    {
        public static async Task<KeyPair> GenerateKeyPairAndCreateSessionAsync(this PlayersApi api, string playerUuid)
        {
            var keyPair = KeyPairGenerator.GenerateKeyPair();
            await api.CreateSessionAsync(playerUuid, keyPair.PublicHex);
            return keyPair;
        }

        public static async Task<string> GeneratePrivateKeyAndCreateSessionAsync(this PlayersApi api, string playerUuid)
        {
            var keyPair = await api.GenerateKeyPairAndCreateSessionAsync(playerUuid);
            return keyPair.PrivateHex;
        }

        public static KeyPair GenerateKeyPairAndCreateSession(this PlayersApi api, string playerUuid)
        {
            var keyPair = KeyPairGenerator.GenerateKeyPair();
            api.CreateSession(playerUuid, keyPair.PublicHex);
            return keyPair;
        }

        public static string GeneratePrivateKeyAndCreateSession(this PlayersApi api, string playerUuid)
        {
            var keyPair = api.GenerateKeyPairAndCreateSession(playerUuid);
            return keyPair.PrivateHex;
        }

    }
}