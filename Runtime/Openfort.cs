using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Openfort.Api;
using Openfort.Client;
using Openfort.Model;
using Openfort.Recovery;
using Openfort.Signer;
using Openfort.Storage;

namespace Openfort
{
    public struct SessionKey
    {
        public string PublicKey;
        public bool IsRegistered;
    }

    public class NotLoggedIn : Exception { public NotLoggedIn(string message) : base(message) { } }
    public class MissingRecoveryMethod : Exception { public MissingRecoveryMethod(string message) : base(message) { } }
    public class EmbeddedNotConfigured : Exception { public EmbeddedNotConfigured(string message) : base(message) { } }
    public class NoSignerConfigured : Exception { public NoSignerConfigured(string message) : base(message) { } }
    public class NothingToSign : Exception { public NothingToSign(string message) : base(message) { } }
    public class OpenfortSDK
    {
        private ISigner _signer;
        private readonly string _publishableKey;
        private readonly OpenfortAuth _openfortAuth;
        private readonly IStorage _storage;
        private readonly SessionsApi _sessionApi;
        private readonly TransactionIntentsApi _transactionIntentsApi;


        public OpenfortSDK(string publishableKey)
        {
            _publishableKey = publishableKey;
            _openfortAuth = new OpenfortAuth(publishableKey);
            _storage = new PlayerPreferencesStorage();
            var configuration = new Configuration(
                new Dictionary<string, string> { { "Authorization", "Bearer " + _publishableKey } },
                new Dictionary<string, string> { { "Authorization", _publishableKey } },
                new Dictionary<string, string> { { "Authorization", "Bearer" } });

            _sessionApi = new SessionsApi(configuration);
            _transactionIntentsApi = new TransactionIntentsApi(configuration);
        }

        public SessionKey ConfigureSessionKey()
        {
            var signer = new SessionSigner(_storage, _publishableKey);
            _signer = signer;

            var key = signer.LoadKeys();
            if (key != null)
            {
                return new SessionKey
                {
                    PublicKey = key,
                    IsRegistered = true
                };
            }

            key = signer.GenerateKeys();
            return new SessionKey
            {
                PublicKey = key,
                IsRegistered = false
            };
        }

        public void ConfigureEmbeddedSigner(int chainId)
        {
            if (!CredentialsProvided())
            {
                throw new NotLoggedIn("Must be logged in to configure embedded signer");
            }

            var signer = new EmbeddedSigner(chainId, _publishableKey, _storage);
            _signer = signer;

            if (!signer.IsLoaded())
            {
                throw new MissingRecoveryMethod("This device has not been configured, in order to recover your account or create a new one you must provide recovery method");
            }
        }

        public async Task ConfigureEmbeddedRecovery(IRecovery recovery)
        {
            if (_signer == null)
            {
                throw new EmbeddedNotConfigured("No embedded signer configured");
            }

            if (_signer.GetSignerType() != Signer.Signer.Embedded)
            {
                throw new EmbeddedNotConfigured("Signer must be embedded signer");
            }

            var embeddedSigner = (EmbeddedSigner)_signer;
            embeddedSigner.SetRecovery(recovery);
            await ValidateAndRefreshToken();
            await embeddedSigner.EnsureEmbeddedAccount();
        }

        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var auth = await _openfortAuth.LoginEmailPassword(email, password);
            StoreCredentials(auth);
            return auth.Token;
        }

        public async Task<string> SignUpWithEmailPassword(string email, string password, string name = null)
        {
            var auth = await _openfortAuth.SignupEmailPassword(email, password, name);
            StoreCredentials(auth);
            return auth.Token;
        }

        public async Task<OAuthInitResponse> InitOAuth(OAuthProvider provider, OAuthInitRequestOptions options = default(OAuthInitRequestOptions))
        {
            return await _openfortAuth.InitOAuth(provider, options: options);
        }

        public async Task<string> AuthenticateWithOAuth(OAuthProvider provider, string key, TokenType tokenType)
        {
            var auth = await _openfortAuth.AuthenticateOAuth(provider, key, tokenType);
            StoreCredentials(auth);
            return auth.Token;
        }

        public async Task<SIWEInitResponse> InitOAuth(string address)
        {
            return await _openfortAuth.InitSIWE(address);
        }

        public async Task<string> AuthenticateWithSIWE(string signature, string message, string walletClientType, string connectorType)
        {
            var auth = await _openfortAuth.AuthenticateSIWE(signature, message, walletClientType, connectorType);
            StoreCredentials(auth);
            return auth.Token;
        }

        private void StoreCredentials(Authentication authentication)
        {
            _storage.Set(Keys.AuthToken, authentication.Token);
            _storage.Set(Keys.RefreshToken, authentication.RefreshToken);
            _storage.Set(Keys.PlayerId, authentication.PlayerId);
        }

        public string GetAccessToken()
        {
            return _storage.Get(Keys.AuthToken);
        }

        public bool IsLoaded()
        {
            return _openfortAuth.Jwks() != null;
        }

        private bool CredentialsProvided()
        {
            var token = _storage.Get(Keys.AuthToken);
            var refreshToken = _storage.Get(Keys.RefreshToken);
            var playerId = _storage.Get(Keys.PlayerId);
            return !string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(refreshToken) && !string.IsNullOrEmpty(playerId);
        }

        public bool IsAuthenticated()
        {
            if (!CredentialsProvided())
            {
                return false;
            }

            if (_signer != null && _signer.GetSignerType() == Signer.Signer.Embedded)
            {
                var embeddedSigner = (EmbeddedSigner)_signer;
                if (string.IsNullOrEmpty(embeddedSigner.GetDeviceId()))
                {
                    return false;
                }
            }

            return true;
        }


        public async Task Logout()
        {
            if (CredentialsProvided())
            {
                await _openfortAuth.Logout(_storage.Get(Keys.AuthToken), _storage.Get(Keys.RefreshToken));
            }
            _signer.Logout();
            _storage.Delete(Keys.AuthToken);
            _storage.Delete(Keys.RefreshToken);
            _storage.Delete(Keys.PlayerId);
        }

        public async Task<SessionResponse> SendSignatureSessionRequest(string sessionId, string signature)
        {
            var result = await _sessionApi.SignatureSessionAsync(sessionId, new SignatureRequest(signature));
            return result;
        }

        public async Task<TransactionIntentResponse> SendSignatureTransactionIntentRequest(string sessionId, string userOp = null, string signature = null)
        {
            if (signature == null)
            {
                if (userOp == null)
                {
                    throw new NothingToSign("No user operation or signature provided");
                }

                if (_signer == null)
                {
                    throw new NoSignerConfigured("In order to sign a transaction intent, a signer must be configured");
                }

                await ValidateAndRefreshToken();
                signature = await _signer.Sign(userOp);
            }

            var result = await _transactionIntentsApi.SignatureAsync(sessionId, new SignatureRequest(signature));
            return result;
        }

        private async Task ValidateAndRefreshToken()
        {
            if (!CredentialsProvided())
            {
                return;
            }

            var auth = await _openfortAuth.ValidateAndRefreshToken(accessToken: _storage.Get(Keys.AuthToken),
                refreshToken: _storage.Get(Keys.RefreshToken));
            if (auth.Token != _storage.Get(Keys.AuthToken))
            {
                StoreCredentials(auth);
                if (_signer.UseCredentials())
                {
                    _signer.UpdateAuthentication(auth);
                }
            }
        }
    }
}
