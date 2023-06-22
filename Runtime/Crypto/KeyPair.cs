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
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;
using UnityEngine;

namespace Openfort.Crypto
{
    public class KeyPair
    {
        static readonly X9ECParameters curve = ECNamedCurveTable.GetByName("secp256k1");
        static readonly ECDomainParameters domainParams = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H, curve.GetSeed());

        private readonly ECPublicKeyParameters _public;
        private readonly ECPrivateKeyParameters _private;
        private ECDsaSigner _signer;

        public KeyPair(AsymmetricCipherKeyPair keyPair)
        {
            _public = keyPair.Public as ECPublicKeyParameters;
            _private = keyPair.Private as ECPrivateKeyParameters;
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
            get => Public.Q.GetEncoded().ToHex();
        }

        public string PrivateHex
        {
            get => Private.D.ToHex();
        }

        private ECDsaSigner Signer
        {
            get
            {
                if (_signer == null)
                {
                    _signer = new ECDsaSigner(new HMacDsaKCalculator(new Sha256Digest()));
                    _signer.Init(true, Private);
                }
                return _signer;
            }
        }

        private byte[] HashMessage(byte[] msg)
        {
            // "\x19Ethereum Signed Message:\n"
            byte[] prefixBytes = {25, 69, 116, 104, 101, 114, 101, 117, 109, 32, 83, 105, 103, 110, 101, 100, 32, 77, 101, 115, 115, 97, 103, 101, 58, 10};
            byte[] lengthBytes = Encoding.UTF8.GetBytes(msg.Length.ToString());
            byte[] txBytes = prefixBytes.Concat(lengthBytes).Concat(msg).ToArray();


            var digest = new KeccakDigest(256);
            digest.BlockUpdate(txBytes, 0, txBytes.Length);
            var calculatedHash = new byte[32];
            digest.DoFinal(calculatedHash, 0);
            
            return calculatedHash;
        }

        private string FormatSignature(BigInteger[] signature) {
            var r = signature[0];
            var s = signature[1];
            var otherS = curve.Curve.Order.Subtract(s);

            if (s.CompareTo(otherS) == 1)
            {
                s = otherS;
            }

            return string.Format("0x{0}{1}1b", r.ToString(16), s.ToString(16));
        }

        public string Sign(byte[] msg)
        {
            var calculatedHash = HashMessage(msg);
            var signature = Signer.GenerateSignature(calculatedHash);
            return FormatSignature(signature);
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