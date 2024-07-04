using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class InitSiweResponse
    {
        /**
        * Address for the SIWE initialization response
        */
        public string address;

        /**
        * Nonce for the SIWE initialization response
        */
        public string nonce;

        /**
        * Expiration time for the SIWE initialization response
        */
        public long expiresAt;

        public InitSiweResponse(string address, string nonce, long expiresAt)
        {
            this.address = address;
            this.nonce = nonce;
            this.expiresAt = expiresAt;
        }

        /**
        * Creates a new InitSiweResponse with the provided address, nonce, and expiresAt
        */
        public static InitSiweResponse Create(string address, string nonce, long expiresAt)
        {
            return new InitSiweResponse(address, nonce, expiresAt);
        }
    }
}
