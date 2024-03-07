using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Openfort.Extensions;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;
using UnityEngine;
using Nethereum.Web3.Accounts;
using Nethereum.Signer;

namespace Openfort.Crypto
{
    public class KeyPair
    {
        static readonly X9ECParameters curve = ECNamedCurveTable.GetByName("secp256k1");
        static readonly ECDomainParameters domainParams = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H, curve.GetSeed());

        private readonly ECPublicKeyParameters _public;
        private readonly ECPrivateKeyParameters _private;
        private readonly Account _account;


        public KeyPair(AsymmetricCipherKeyPair keyPair)
        {
            _public = keyPair.Public as ECPublicKeyParameters;
            _private = keyPair.Private as ECPrivateKeyParameters;
            _account = new Account(PrivateHex);
        }

        public ECPublicKeyParameters Public
        {
            get => _public;
        }

        public ECPrivateKeyParameters Private
        {
            get => _private;
        }

        public string PublicHex
        {
            get => Public.Q.GetEncoded(true).ToHex();
        }

        public string PrivateHex
        {
            get => Private.D.ToHex();
        }

        public string Address
        {
            get => _account?.Address;
        }

        public string Sign(byte[] msg)
        {
            var signer = new EthereumMessageSigner();
            var ethECKey = new EthECKey(Private.D.ToByteArray(), true);
            return signer.Sign(msg, ethECKey);
        }

        public string Sign(string msg)
        {
            return Sign(Hex.Decode(msg.TrimHexPrefix()));
        }

        public void SaveToPlayerPrefs()
        {
            PlayerPrefs.SetString("openfort", PrivateHex);
        }

        public void RemoveFromPlayerPrefs()
        {
            PlayerPrefs.DeleteKey("openfort");
        }

        public static KeyPair LoadFromPlayerPrefs()
        {
            var savedPrivateKey = PlayerPrefs.GetString("openfort");
            if (string.IsNullOrEmpty(savedPrivateKey))
            {
                return null;
            }

            BigInteger privateKeyValue;
            try
            {
                privateKeyValue = new BigInteger(savedPrivateKey.TrimHexPrefix(), 16);
            }
            catch
            {
                return null;
            }
            var privateKey = new ECPrivateKeyParameters(privateKeyValue, domainParams);

            var q = privateKey.Parameters.G.Multiply(privateKey.D);
            var publicKey = new ECPublicKeyParameters(privateKey.AlgorithmName, q, SecObjectIdentifiers.SecP256k1);
            var keyPair = new AsymmetricCipherKeyPair(publicKey, privateKey);

            return new KeyPair(keyPair);
        }

        public static KeyPair Generate()
        {
            var secureRandom = new SecureRandom();
            var keyParams = new ECKeyGenerationParameters(domainParams, secureRandom);

            var generator = new ECKeyPairGenerator("ECDSA");
            generator.Init(keyParams);
            return new KeyPair(generator.GenerateKeyPair());
        }
    }
}