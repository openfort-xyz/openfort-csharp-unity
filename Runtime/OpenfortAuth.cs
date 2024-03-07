using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Openfort.Api;
using Openfort.Client;
using Openfort.Crypto;
using Openfort.Model;

public struct Authentication {
    public string Token;
    public string RefreshToken;
    public string PlayerId;
}

namespace Openfort
{
    public class OpenfortAuth
    {
        private readonly Configuration _configuration;
        private readonly ApiClient _apiClient;
        private string _key;
        private readonly string _publishableKey;
        public readonly AuthenticationApi AuthenticationApi;

        public OpenfortAuth(string publishableKey)
        {
            _configuration = new Configuration(
                new Dictionary<string, string> { { "Authorization", "Bearer " + publishableKey } },
                new Dictionary<string, string> { { "Authorization", publishableKey } },
                new Dictionary<string, string> { { "Authorization", "Bearer" } });
            _apiClient = new ApiClient(_configuration.BasePath);
            _publishableKey = publishableKey;
            AuthenticationApi = new AuthenticationApi(_apiClient, _apiClient, _configuration);
        }

        public async Task<Authentication> AuthWithToken(OAuthProvider provider, string token)
        {
            var request = new AuthenticateOAuthRequest(provider, token);
            var response = await AuthenticationApi.AuthenticateOAuthAsync(request);
            var authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            SaveToken(authentication);
            return authentication;
        }


        public async Task<Authentication> ValidateAndRefreshToken()
        {
            return await ValidateAndRefreshToken(Token, RefreshToken);
        }
        
        public async Task<Authentication> ValidateAndRefreshToken(string accessToken, string refreshToken)
        {
            var jwtks = await AuthenticationApi.GetJwksAsync(_publishableKey);
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
            } catch (TokenExpiredException e) {
                var request = new RefreshTokenRequest { RefreshToken = refreshToken };
                var response = await AuthenticationApi.RefreshAsync(request);
                authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            } catch (Exception e)
            {
                Debug.Log("Error validating token: " + e.Message);
                throw;
            }
            
            SaveToken(authentication);
            return authentication;
        }
        
        

        public void Logout()
        {
            PlayerPrefs.DeleteKey("openfort-auth-token");
            PlayerPrefs.DeleteKey("openfort-auth-player");
        }

        private void SaveToken(Authentication authentication) {
            PlayerPrefs.SetString("openfort-auth-token", authentication.Token);
            PlayerPrefs.SetString("openfort-auth-refresh-token", authentication.RefreshToken);
            PlayerPrefs.SetString("openfort-auth-player", authentication.PlayerId);
        }

        public string Token
        {
            get
            {
                return PlayerPrefs.GetString("openfort-auth-token");
            }
        }
        
        public string RefreshToken
        {
            get
            {
                return PlayerPrefs.GetString("openfort-auth-refresh-token");
            }
        }
    
        public string PlayerId
        {
            get
            {
                return PlayerPrefs.GetString("openfort-auth-player");
            }
        }
    }
}
