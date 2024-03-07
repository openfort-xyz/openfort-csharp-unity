using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.Diagnostics;
using Openfort.Api;
using Openfort.Client;
using Openfort.Crypto;
using Openfort.Model;

namespace Openfort
{
    public class OpenfortClient
    {
        private readonly Configuration _configuration;
        private readonly ApiClient _apiClient;
        private KeyPair _sessionKey;

        public OpenfortClient(string token)
        {
            _configuration = new Configuration(
                new Dictionary<string, string> { { "Authorization", "Bearer " + token } },
                new Dictionary<string, string> { { "Authorization", token } },
                new Dictionary<string, string> { { "Authorization", "Bearer" } });
            _apiClient = new ApiClient(_configuration.BasePath);
        }

        private SessionsApi _sessionApi;
        public SessionsApi SessionApi
        {
            get
            {
                if (_sessionApi == null)
                {
                    _sessionApi = new SessionsApi(_apiClient, _apiClient, _configuration);
                }
                return _sessionApi;
            }
        }

        private TransactionIntentsApi _transactionIntentsApi;
        public TransactionIntentsApi TransactionIntentsApi
        {
            get
            {
                if (_transactionIntentsApi == null)
                {
                    _transactionIntentsApi = new TransactionIntentsApi(_apiClient, _apiClient, _configuration);
                }
                return _transactionIntentsApi;
            }
        }

        public KeyPair SessionKey
        {
            get
            {
                if (_sessionKey == null)
                {
                    throw new Exception("Session key is not initialized");
                }
                return _sessionKey;
            }
        }

        public KeyPair CreateSessionKey()
        {
            _sessionKey = KeyPair.Generate();
            return _sessionKey;
        }

        public KeyPair LoadSessionKey()
        {
            _sessionKey = KeyPair.LoadFromPlayerPrefs();
            return _sessionKey;
        }

        public void SaveSessionKey()
        {
            SessionKey.SaveToPlayerPrefs();
        }

        public void RemoveSessionKey()
        {
            SessionKey.RemoveFromPlayerPrefs();
        }

        public string SignMessage(byte[] msg)
        {
            return SessionKey.Sign(msg);
        }

        public string SignMessage(string msg)
        {
            return SessionKey.Sign(msg);
        }

        public async Task<SessionResponse> SendSignatureSessionRequest(string sessionId, string signature)
        {
            var result = await SessionApi.SignatureSessionAsync(sessionId, new SignatureRequest(signature));
            return result;
        }

        public async Task<TransactionIntentResponse> SendSignatureTransactionIntentRequest(string sessionId, string signature)
        {
            var result = await TransactionIntentsApi.SignatureAsync(sessionId, new SignatureRequest(signature));
            return result;
        }
    }
}
