using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clients;
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
    public class MissingRecoveryPassword : Exception { public MissingRecoveryPassword(string message) : base(message) { } }
    public class NoSignerConfigured : Exception { public NoSignerConfigured(string message) : base(message) { } }
    public class NothingToSign : Exception { public NothingToSign(string message) : base(message) { } }
    public class OpenfortSDK
    {
        private ISigner _signer;
        private readonly string _publishableKey;
        private readonly string _openfortURL;
        private readonly string _shieldAPIKey;
        private readonly string _shieldURL;
        private readonly string _encryptionShare;
        private readonly OpenfortAuth _openfortAuth;
        private readonly IStorage _storage;
        private readonly SessionsApi _sessionApi;
        private readonly TransactionIntentsApi _transactionIntentsApi;

        public OpenfortSDK(string publishableKey, string shieldAPIKey = null, string encryptionShare = null, string openfortURL = "https://api.openfort.xyz", string shieldURL = "https://shield.openfort.xyz")
        {
            _publishableKey = publishableKey;
            _openfortURL = openfortURL;
            _shieldAPIKey = shieldAPIKey;
            _shieldURL = shieldURL;
            _encryptionShare = encryptionShare;
            _storage = new PlayerPreferencesStorage();
            _openfortAuth = new OpenfortAuth(publishableKey);
            var configuration = new Configuration(
                new Dictionary<string, string> { { "Authorization", "Bearer " + _publishableKey } },
                new Dictionary<string, string> { { "Authorization", _publishableKey } },
                new Dictionary<string, string> { { "Authorization", "Bearer" } });

            _sessionApi = new SessionsApi(configuration);
            _transactionIntentsApi = new TransactionIntentsApi(configuration);

        }

        public string PlayerID => _storage.Get(Keys.PlayerId);

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

        public async Task ConfigureEmbeddedSigner(int chainId, Shield.ShieldAuthOptions auth = null)
        {
            if (!CredentialsProvided())
            {
                throw new NotLoggedIn("Must be logged in to configure embedded signer");
            }

            var signer = new EmbeddedSigner(chainId, _publishableKey, _storage, _shieldAPIKey, _encryptionShare,_openfortURL, _shieldURL);
            try
            {
                await signer.EnsureEmbeddedAccount(auth: auth);
            }
            catch (Exception e)
            {
                switch (e)
                {
                    case RecoveryNotConfigured:
                        throw new EmbeddedNotConfigured("Recovery not configured: " + e.Message);
                    case Signer.MissingRecoveryPassword:
                        throw new MissingRecoveryPassword("Recovery is encrypted, must provide recovery password");
                    default:
                        throw;
                }
            }

            _signer = signer;
        }

        public async Task ConfigureEmbeddedSignerRecovery(int chainId, Shield.ShieldAuthOptions auth, string recoveryPassword)
        {
            if (!CredentialsProvided())
            {
                throw new NotLoggedIn("Must be logged in to configure embedded signer");
            }

            var signer = new EmbeddedSigner(chainId, _publishableKey, _storage, _shieldAPIKey, _encryptionShare, _openfortURL, _shieldURL);
            try
            {
                await signer.EnsureEmbeddedAccount(recoveryPassword, auth);
            }
            catch (Exception e)
            {
                if (e is RecoveryNotConfigured)
                {
                    throw new EmbeddedNotConfigured("Recovery not configured");
                }

                throw;
            }

            _signer = signer;
        }

        public async Task AuthenticateWithThirdPartyProvider(string provider, string token, TokenType tokenType)
        {
            var tokenTypeStr = tokenType switch
            {
                TokenType.IdToken => "idToken",
                TokenType.CustomToken => "accessToken",
                _ => throw new Exception("Invalid token type")
            };
            var playerId = await new Clients.Openfort(_publishableKey, baseURL: _openfortURL).VerifyThirdParty(token, provider, tokenTypeStr);
            _storage.Set(Keys.PlayerId, playerId);
            _storage.Set(Keys.ThirdPartyProvider, provider);
            _storage.Set(Keys.AuthToken, token);
            _storage.Set(Keys.ThirdPartyTokenType, tokenType.ToString());
        }

        public async Task<AuthResponse> LoginWithEmailPassword(string email, string password)
        {
            var response = await _openfortAuth.LoginEmailPassword(email, password);
            var authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            StoreCredentials(authentication);
            return response;
        }

        public async Task<AuthResponse> SignUpWithEmailPassword(string email, string password, string name = null)
        {
            var response = await _openfortAuth.SignupEmailPassword(email, password, name);
            var authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            StoreCredentials(authentication);
            return response;
        }

        public async Task<OAuthInitResponse> InitOAuth(OAuthProvider provider, OAuthInitRequestOptions options = default(OAuthInitRequestOptions))
        {
            return await _openfortAuth.InitOAuth(provider, options: options);
        }

        public async Task<AuthResponse> AuthenticateWithOAuth(OAuthProvider provider, string key, TokenType tokenType)
        {
            var response = await _openfortAuth.AuthenticateOAuth(provider, key, tokenType);
            var authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            StoreCredentials(authentication);
            return response;
        }

        public async Task<SIWEInitResponse> InitOAuth(string address)
        {
            return await _openfortAuth.InitSIWE(address);
        }

        public async Task<AuthResponse> AuthenticateWithSIWE(string signature, string message, string walletClientType, string connectorType)
        {
            var response = await _openfortAuth.AuthenticateSIWE(signature, message, walletClientType, connectorType);
            var authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            StoreCredentials(authentication);
            return response;
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
            var thirdPartyProvider = _storage.Get(Keys.ThirdPartyProvider);
            var tokenType = _storage.Get(Keys.ThirdPartyTokenType);
            var refreshToken = _storage.Get(Keys.RefreshToken);
            var playerId = _storage.Get(Keys.PlayerId);
            return !string.IsNullOrEmpty(token) && (!string.IsNullOrEmpty(refreshToken) || (!string.IsNullOrEmpty(thirdPartyProvider) && !string.IsNullOrEmpty(tokenType))) && !string.IsNullOrEmpty(playerId);
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
            if (CredentialsProvided() && !string.IsNullOrEmpty(_storage.Get(Keys.RefreshToken)))
            {
                try
                {
                    await _openfortAuth.Logout(_storage.Get(Keys.AuthToken), _storage.Get(Keys.RefreshToken));
                } catch (Exception e)
                {
                    Console.WriteLine(e);
                }
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
            var accessToken = _storage.Get(Keys.AuthToken);
            var refreshToken = _storage.Get(Keys.RefreshToken);

            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
            {
                return;
            }

            var auth = await _openfortAuth.ValidateAndRefreshToken(accessToken, refreshToken);
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
