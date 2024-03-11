using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Openfort.Client;
using UnityEngine;
using Openfort.Crypto;
using Openfort.Model;
using Openfort.Api;


internal struct Authentication {
    public string Token;
    public string RefreshToken;
    public string PlayerId;
}

public struct InitAuthResponse {
    public string Url;
    public string Key;
}

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
            var apiClient = new ApiClient(configuration.BasePath);
            _publishableKey = publishableKey;
            _authenticationApi = new AuthenticationApi(publishableKey);
            GetJwks().ContinueWith(task => _jwks = task.Result);
        }

        internal async Task<InitAuthResponse> GetAuthenticationURL(OAuthProvider provider)
        {
            var request = new OAuthInitRequest(provider: provider);
            var response = await _authenticationApi.InitOAuthAsync(request);
            return new InitAuthResponse { Url = response.Url, Key = response.Key };
        }
        
        internal async Task<Authentication> GetTokenAfterSocialLogin(OAuthProvider provider, string key)
        {
            var request = new AuthenticateOAuthRequest(provider: provider, token: key);
            var response = await _authenticationApi.AuthenticateOAuthAsync(request);
            var authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            return authentication;
        }

        internal async Task<Authentication> Login(string username, string password)
        {
            var request = new LoginRequest(username, password);
            var response = await _authenticationApi.LoginEmailPasswordAsync(request);
            var authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            return authentication;
        }
        
        internal async Task<Authentication> SignUp(string email, string password)
        {
            var request = new SignupRequest(email, password);
            var response = await _authenticationApi.SignupEmailPasswordAsync(request);
            var authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            return authentication;
        }
        
        internal async Task<Authentication> Login(OAuthProvider provider, string token)
        {
            var request = new AuthenticateOAuthRequest(provider, token);
            var response = await _authenticationApi.AuthenticateOAuthAsync(request);
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
            Authentication authentication;
            try
            {
                var playerId = Jwt.Validate(accessToken, _jwks.X, _jwks.Y, _jwks.Crv);
                authentication = new Authentication { Token = accessToken, RefreshToken = refreshToken, PlayerId = playerId };
            } catch (TokenExpiredException) {
                var request = new RefreshTokenRequest { RefreshToken = refreshToken };
                var response = await _authenticationApi.RefreshAsync(request);
                authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            } catch (Exception e)
            {
                Debug.Log("Error validating token: " + e.Message);
                throw;
            }
            
            return authentication;
        }
    }
}
