using System;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using System.Text;
using UnityEngine;
using System.IO;

namespace OpenfortSdk.Crypto
{
    public class KeyPair
    {
        private readonly ECPublicKeyParameters _public;
        private readonly ECPrivateKeyParameters _private;

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

        public string PublicBase64
        {
            get => Convert.ToBase64String(Public.Q.GetEncoded());
        }

        public string PrivateBase64
        {
            get {
                var bcKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(Private);
                var pkcs8Blob = bcKeyInfo.GetDerEncoded();
                return Convert.ToBase64String(pkcs8Blob);
            }
        }

        public string Sign(string msg)
        {
            byte[] msgBytes = Encoding.UTF8.GetBytes(msg);

            ISigner signer = SignerUtilities.GetSigner("SHA-256withECDSA");
            signer.Init(true, Private);
            signer.BlockUpdate(msgBytes, 0, msgBytes.Length);
            byte[] sigBytes = signer.GenerateSignature();

            return Convert.ToBase64String(sigBytes);
        }

        public bool VerifySignature(string signature, string msg)
        {
            byte[] msgBytes = Encoding.UTF8.GetBytes(msg);
            byte[] sigBytes = Convert.FromBase64String(signature);

            ISigner signer = SignerUtilities.GetSigner("SHA-256withECDSA");
            signer.Init(false, Public);
            signer.BlockUpdate(msgBytes, 0, msgBytes.Length);
            return signer.VerifySignature(sigBytes);
        }

        public void SaveToPlayerPrefs()
        {
            PlayerPrefs.SetString("openfort", PrivateBase64);
        }

        public static KeyPair GetFromPlayerPrefs()
        {
            var result = PlayerPrefs.GetString("openfort");
            if (string.IsNullOrEmpty(result))
            {
                return null;
            }
            var keyInfo = Convert.FromBase64String(result);
            var privateKey = PrivateKeyFactory.CreateKey(keyInfo) as ECPrivateKeyParameters;

            var q = privateKey.Parameters.G.Multiply(privateKey.D);
            var publicKey = new ECPublicKeyParameters(privateKey.AlgorithmName, q, SecObjectIdentifiers.SecP256k1);
            var keyPair = new AsymmetricCipherKeyPair(publicKey, privateKey);

            return new KeyPair(keyPair);
        }

        public static KeyPair Generate()
        {
            var curve = ECNamedCurveTable.GetByName("secp256k1");
            var domainParams = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H, curve.GetSeed());

            var secureRandom = new SecureRandom();
            var keyParams = new ECKeyGenerationParameters(domainParams, secureRandom);

            var generator = new ECKeyPairGenerator("ECDSA");
            generator.Init(keyParams);
            return new KeyPair(generator.GenerateKeyPair());
        }

        static string ToHex(byte[] data) => String.Concat(data.Select(x => x.ToString("x2")));
    }
}