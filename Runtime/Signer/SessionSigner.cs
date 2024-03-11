using System.Collections.Generic;
using System.Threading.Tasks;
using Openfort.Api;
using Openfort.Client;
using Openfort.Crypto;
using Openfort.Model;
using Openfort.Storage;

namespace Openfort.Signer
{
    internal class SessionSigner : ISigner
    {
        private KeyPair _keyPair;
        private readonly IStorage _storage;
        private readonly SessionsApi _sessionApi;
        
        public SessionSigner(IStorage storage, string publishableKey)
        {
            _storage = storage;
            var configuration = new Configuration(
                new Dictionary<string, string> {{ "Authorization", "Bearer " + publishableKey }},
                new Dictionary<string, string> { { "Authorization", publishableKey } },
                new Dictionary<string, string> { { "Authorization", "Bearer" } }
            );
            _sessionApi = new SessionsApi(configuration);
        }
        
        public Task<string> Sign(string message)
        {
            var signature = _keyPair.Sign(message);
            return Task.FromResult(signature);
        }
        
        public void Logout()
        {
            _storage.Delete(Keys.SessionKey);
            _keyPair = null;
        }
        
        public string LoadKeys()
        {
            if (_keyPair != null)
            {
                return _keyPair.PublicHex;
            }
            
            var sessionKey = _storage.Get(Keys.SessionKey);
            if (string.IsNullOrEmpty(sessionKey))
            {
                return null;
            }
            
            _keyPair = KeyPair.Load(sessionKey);
            return _keyPair.PublicHex;
        }
        
        public string GenerateKeys()
        {
            _keyPair = KeyPair.Generate();
            _storage.Set(Keys.SessionKey, _keyPair.PrivateHex);
            return _keyPair.PublicHex;
        }
        
        public Signer GetSignerType()
        {
            return Signer.Session;
        }

        public bool UseCredentials()
        {
            return false;
        }

        public void UpdateAuthentication(Authentication auth) {}
    }
}