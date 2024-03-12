using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Math;
using UnityEngine;

namespace Openfort.Crypto
{
    public class TokenExpiredException : Exception
    {
        public TokenExpiredException(string message) : base(message)
        {

        }
    }

    public class TokenInvalidException : Exception
    {
        public TokenInvalidException(string message) : base(message)
        {

        }
    }
    public static class Jwt
    {
        public static string Validate(string token, string x, string y, string curve)
        {
            var parts = token.Split('.');
            if (parts.Length != 3)
            {
                Debug.Log("Invalid token, len is: " + parts.Length);
                throw new TokenInvalidException("Invalid format");
            }

            var signature = parts[2];

            var headerJson = Encoding.UTF8.GetString(Base64UrlDecode(parts[0]));
            var payloadJson = Encoding.UTF8.GetString(Base64UrlDecode(parts[1]));

            var headerData = JsonConvert.DeserializeObject<Dictionary<string, string>>(headerJson);
            var payloadData = JsonConvert.DeserializeObject<Dictionary<string, string>>(payloadJson);

            var headerAlg = headerData["alg"];
            var headerTyp = headerData["typ"];

            if (headerAlg != "ES256" || headerTyp != "JWT")
            {
                throw new Exception("Invalid token");
            }

            var subject = payloadData["sub"];
            var issuer = payloadData["iss"];
            if (issuer != "openfort.xyz")
            {
                throw new TokenInvalidException("Invalid issuer");
            }

            var expiring = long.Parse(payloadData["exp"]);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var expirationTime = epoch.AddSeconds(expiring);

            if (DateTime.UtcNow >= expirationTime)
            {
                throw new TokenExpiredException("Token expired at: " + expirationTime);
            }


            var headerAndPayload = parts[0] + "." + parts[1];
            if (!VerifySignature(headerAndPayload, signature, x, y, curve))
            {
                throw new TokenInvalidException("Invalid signature");
            }



            return subject;
        }

        private static bool VerifySignature(string data, string signature, string x, string y, string curve)
        {
            try
            {
                var xBytes = Base64UrlDecode(x);
                var yBytes = Base64UrlDecode(y);
                var ecParams = NistNamedCurves.GetByName(curve);
                var domainParameters = new ECDomainParameters(ecParams.Curve, ecParams.G, ecParams.N, ecParams.H, ecParams.GetSeed());
                var point = ecParams.Curve.CreatePoint(new BigInteger(1, xBytes), new BigInteger(1, yBytes));

                var publicKeyParameters = new ECPublicKeyParameters(point, domainParameters);

                var signer = SignerUtilities.GetSigner("SHA-256withECDSA");

                signer.Init(false, publicKeyParameters);

                var dataBytes = Encoding.UTF8.GetBytes(data);
                signer.BlockUpdate(dataBytes, 0, dataBytes.Length);

                var decodedSignature = Base64UrlDecode(signature);
                var derSignature = new DerSequence(new DerInteger(new BigInteger(1, decodedSignature.Take(32).ToArray())), new DerInteger(new BigInteger(1, decodedSignature.Skip(32).ToArray()))).GetDerEncoded();
                var result = signer.VerifySignature(derSignature);
                return result;
            }
            catch (Exception ex)
            {
                Debug.Log("Error in signature verification: " + ex.Message);
                return false;
            }
        }


        private static byte[] Base64UrlDecode(string input)
        {
            var output = input;
            output = output.Replace('-', '+').Replace('_', '/');
            switch (output.Length % 4)
            {
                case 0: break;
                case 2: output += "=="; break;
                case 3: output += "="; break;
                default: throw new FormatException("Illegal base64url string!");
            }
            return Convert.FromBase64String(output);
        }
    }


}