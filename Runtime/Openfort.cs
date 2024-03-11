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
            var signer = new SessionSigner(_storage);
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
            if (!IsAuthenticated())
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

        public async Task<string> LoginWithEmailPassword(string username, string password)
        {
            var auth = await _openfortAuth.Login(username, password);
            StoreCredentials(auth);
            return auth.Token;
        }

        public async Task<string> LoginWithOAuth(OAuthProvider provider, string token)
        {
            var auth = await _openfortAuth.Login(provider, token);
            StoreCredentials(auth);
            return auth.Token;
        }

        public async Task<string> SignUpWithEmailPassword(string username, string password)
        {
            var auth = await _openfortAuth.SignUp(username, password);
            StoreCredentials(auth);
            return auth.Token;
        }

        public async Task<InitAuthResponse> InitOAuth(OAuthProvider provider)
        {
            return await _openfortAuth.GetAuthenticationURL(provider);
        }

        public async Task<string> AuthenticateOAuth(OAuthProvider provider, string key)
        {
            var auth = await _openfortAuth.GetTokenAfterSocialLogin(provider, key);
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

        public bool IsAuthenticated()
        {
            var token = _storage.Get(Keys.AuthToken);
            var refreshToken = _storage.Get(Keys.RefreshToken);
            var playerId = _storage.Get(Keys.PlayerId);
            return !string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(refreshToken) && !string.IsNullOrEmpty(playerId);
        }


        public void Logout()
        {
            _storage.Delete(Keys.AuthToken);
            _storage.Delete(Keys.RefreshToken);
            _storage.Delete(Keys.PlayerId);
            _signer.Logout();
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
            if (!IsAuthenticated())
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
