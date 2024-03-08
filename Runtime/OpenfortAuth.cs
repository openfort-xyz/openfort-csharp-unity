using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Openfort.Api;
using Openfort.Client;
using Openfort.Crypto;
using Openfort.Model;


internal struct Authentication {
    public string Token;
    public string RefreshToken;
    public string PlayerId;
}

namespace Openfort
{
    internal class OpenfortAuth
    {
        private readonly string _publishableKey;
        private readonly AuthenticationApi _authenticationApi;

        internal OpenfortAuth(string publishableKey)
        {
            var configuration = new Configuration(
                new Dictionary<string, string> { { "Authorization", "Bearer " + publishableKey } },
                new Dictionary<string, string> { { "Authorization", publishableKey } },
                new Dictionary<string, string> { { "Authorization", "Bearer" } });
            var apiClient = new ApiClient(configuration.BasePath);
            _publishableKey = publishableKey;
            _authenticationApi = new AuthenticationApi(apiClient, apiClient, configuration);
        }

        internal async Task<Authentication> Login(string username, string password)
        {
            var request = new LoginRequest(username, password);
            var response = await _authenticationApi.LoginEmailPasswordAsync(request);
            var authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            return authentication;
        }
        
        internal async Task<Authentication> SignUp(string username, string password)
        {
            var request = new SignupRequest(username, password);
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


        internal async Task<Authentication> ValidateAndRefreshToken(string accessToken, string refreshToken)
        {
            var jwtks = await _authenticationApi.GetJwksAsync(_publishableKey);
            if (jwtks.Keys.Count == 0)
            {
                throw new Exception("No keys found");
            }
            
            var jwtk = jwtks.Keys[0];
            Authentication authentication;
            try
            {
                var playerId = Jwt.Validate(accessToken, jwtk.X, jwtk.Y, jwtk.Crv);
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
