using System;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System.Text;

namespace OpenfortSdk.Crypto
{
    public class KeyPair
    {
        private readonly AsymmetricCipherKeyPair _keyPair;

        public KeyPair(AsymmetricCipherKeyPair keyPair)
        {
            _keyPair = keyPair;
        }

        public ECPublicKeyParameters Public
        {
            get => _keyPair.Public as ECPublicKeyParameters;
        }

        public ECPrivateKeyParameters Private
        {
            get => _keyPair.Private as ECPrivateKeyParameters;
        }

        public string PublicHex
        {
            get => ToHex(Public.Q.GetEncoded());
        }

        public string PrivateHex
        {
            get => ToHex(Private.D.ToByteArrayUnsigned());
        }

        public string PublicBase64
        {
            get => Convert.ToBase64String(Public.Q.GetEncoded());
        }

        public string PrivateBase64
        {
            get => Convert.ToBase64String(Private.D.ToByteArrayUnsigned());
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

        static string ToHex(byte[] data) => String.Concat(data.Select(x => x.ToString("x2")));
    }
}