using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Openfort.Client;
using UnityEngine;
using Openfort.Crypto;
using Openfort.Model;
using Openfort.Api;


internal struct Authentication
{
    public string Token;
    public string RefreshToken;
    public string PlayerId;
}

public struct OAuthInitResponse
{
    public string Url;
    public string Key;
}

public struct SIWEInitResponse
{
    public string Address;
    public string Nonce;
    public double ExpiresAt;
};

namespace Openfort
{
    internal class OpenfortAuth
    {
        private readonly string _publishableKey;
        private readonly AuthenticationApi _authenticationApi;
        private JwtKey _jwks;

        internal OpenfortAuth(string publishableKey)
        {
            var configuration = new Configuration(
                new Dictionary<string, string> { { "Authorization", "Bearer " + publishableKey } },
                new Dictionary<string, string> { { "Authorization", publishableKey } },
                new Dictionary<string, string> { { "Authorization", "Bearer" } });
            _publishableKey = publishableKey;
            _authenticationApi = new AuthenticationApi(configuration);
        }

        internal async Task<OAuthInitResponse> InitOAuth(OAuthProvider provider, OAuthInitRequestOptions options = default(OAuthInitRequestOptions))
        {
            var request = new OAuthInitRequest(provider: provider, options: options);
            var response = await _authenticationApi.InitOAuthAsync(request);
            return new OAuthInitResponse { Url = response.Url, Key = response.Key };
        }

        internal async Task<Authentication> AuthenticateOAuth(OAuthProvider provider, string key, TokenType tokenType)
        {
            var request = new AuthenticateOAuthRequest(provider: provider, token: key, tokenType: tokenType);
            var response = await _authenticationApi.AuthenticateOAuthAsync(request);
            var authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            return authentication;
        }

        internal async Task<SIWEInitResponse> InitSIWE(string address)
        {
            var request = new SIWERequest(address: address);
            var response = await _authenticationApi.InitSIWEAsync(request);
            return new SIWEInitResponse { Address = response.Address, Nonce = response.Nonce, ExpiresAt = response.ExpiresAt };
        }

        internal async Task<Authentication> AuthenticateSIWE(string signature, string message, string walletClientType, string connectorType)
        {
            var request = new SIWEAuthenticateRequest(signature: signature, message: message, walletClientType: walletClientType, connectorType: connectorType);
            var response = await _authenticationApi.AuthenticateSIWEAsync(request);
            var authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            return authentication;
        }

        internal async Task<Authentication> LoginEmailPassword(string email, string password)
        {
            var request = new LoginRequest(email, password);
            var response = await _authenticationApi.LoginEmailPasswordAsync(request);
            var authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            return authentication;
        }

        internal async Task<Authentication> SignupEmailPassword(string email, string password, string name)
        {
            var request = new SignupRequest(email, password, name);
            var response = await _authenticationApi.SignupEmailPasswordAsync(request);
            var authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            return authentication;
        }

        internal async Task<JwtKey> GetJwks()
        {
            var jwtks = await _authenticationApi.GetJwksAsync(_publishableKey);
            if (jwtks.Keys.Count == 0)
            {
                throw new Exception("No keys found");
            }

            return jwtks.Keys[0];
        }

        internal JwtKey Jwks()
        {
            return _jwks;
        }

        internal async Task<Authentication> ValidateAndRefreshToken(string accessToken, string refreshToken)
        {
            if (_jwks == null)
            {
                _jwks = await GetJwks();
            }
            Authentication authentication;
            try
            {
                var playerId = Jwt.Validate(accessToken, _jwks.X, _jwks.Y, _jwks.Crv);
                authentication = new Authentication { Token = accessToken, RefreshToken = refreshToken, PlayerId = playerId };
            }
            catch (TokenExpiredException)
            {
                var request = new RefreshTokenRequest { RefreshToken = refreshToken };
                var response = await _authenticationApi.RefreshAsync(request);
                authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            }
            catch (Exception e)
            {
                Debug.Log("Error validating token: " + e.Message);
                throw;
            }

            return authentication;
        }

        public async Task Logout(string accessToken, string refreshToken)
        {
            var configuration = new Configuration(
                new Dictionary<string, string> { { "Authorization", "Bearer " + _publishableKey }, { "player-token", accessToken } },
                new Dictionary<string, string> { { "Authorization", _publishableKey } },
                new Dictionary<string, string> { { "Authorization", "Bearer" } });
            var authenticationApiWithPlayerToken = new AuthenticationApi(configuration);
            await authenticationApiWithPlayerToken.LogoutAsync(new LogoutRequest(refreshToken: refreshToken));
        }
    }
}
