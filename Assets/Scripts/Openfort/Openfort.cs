using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Openfort.Api;
using Openfort.Client;
using Openfort.Crypto;
using Openfort.Model;
using Openfort.Signer;

namespace Openfort
{
    public class OpenfortClient
    {
        private KeyPair _sessionKey;
        [CanBeNull] private readonly ISigner _signer;
        private readonly SessionsApi _sessionApi;
        private readonly TransactionIntentsApi _transactionIntentsApi;

        public OpenfortClient(string token, ISigner signer)
        {
            _signer = signer;
            var configuration = new Configuration(
                new Dictionary<string, string> { { "Authorization", "Bearer " + token } },
                new Dictionary<string, string> { { "Authorization", token } },
                new Dictionary<string, string> { { "Authorization", "Bearer" } });
            
            _sessionApi = new SessionsApi(configuration);
            _transactionIntentsApi = new TransactionIntentsApi(configuration);
        }

        public OpenfortClient(string token)
        {
            var configuration = new Configuration(
                new Dictionary<string, string> { { "Authorization", "Bearer " + token } },
                new Dictionary<string, string> { { "Authorization", token } },
                new Dictionary<string, string> { { "Authorization", "Bearer" } });
            _sessionApi = new SessionsApi(configuration);
            _transactionIntentsApi = new TransactionIntentsApi(configuration);
        }

        public async Task<SessionResponse> SendSignatureSessionRequest(string sessionId, string signature)
        {
            var result = await _sessionApi.SignatureSessionAsync(sessionId, new SignatureRequest(signature));
            return result;
        }

        public async Task<TransactionIntentResponse> SendSignatureTransactionIntentRequest(string sessionId, [CanBeNull] string userOp,[CanBeNull] string signature)
        {
            if (signature == null && userOp != null)
            {
                if (_signer == null)
                {
                    throw new Exception("Signer is not set");
                }

                signature = await _signer.Sign(userOp);
            }
            
            var result = await _transactionIntentsApi.SignatureAsync(sessionId, new SignatureRequest(signature));
            return result;
        }
    }
}
