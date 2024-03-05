using System.Threading.Tasks;
using Openfort.Crypto;

namespace Openfort.Signer
{
    public class SessionSigner : ISigner
    {
        private readonly KeyPair _keyPair;
        
        public SessionSigner()
        {
            _keyPair = KeyPair.LoadFromPlayerPrefs();
            if (_keyPair != null) return;
            _keyPair = KeyPair.Generate();
            _keyPair.SaveToPlayerPrefs();
        }
        
        public Task<string> Sign(string message)
        {
            return Task.FromResult(_keyPair.Sign(message));
        }
    }
}