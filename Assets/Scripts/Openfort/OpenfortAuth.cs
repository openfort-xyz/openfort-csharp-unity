using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JWT;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Openfort.Api;
using Openfort.Client;
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

        public OpenfortAuth(string publishableKey, string basePath = default(string))
        {
            _configuration = new Configuration(
                new Dictionary<string, string> { { "Authorization", "Bearer " + publishableKey } },
                new Dictionary<string, string> { { "Authorization", publishableKey } },
                new Dictionary<string, string> { { "Authorization", "Bearer" } });
            _apiClient = new ApiClient(basePath ?? _configuration.BasePath);
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
        
        public async Task<Authentication> ValidateAndRefreshToken(string accessToken, string refreshToken)
        {
            var jwtks = await AuthenticationApi.GetJwksAsync(_publishableKey);
            if (jwtks.Keys.Count == 0)
            {
                throw new System.Exception("No keys found");
            }
            
            var jwtk = jwtks.Keys[0];
            
            var publicKey = new Jose.Jwk( jwtk.Crv, jwtk.X, jwtk.Y, null);
            var payload = Jose.JWT.Decode(accessToken, publicKey);
            var payloadData = JObject.Parse(payload);
            var exp = payloadData.Value<long>("exp");
            var expDate = DateTimeOffset.FromUnixTimeSeconds(exp).DateTime;
            Authentication authentication; 
            if (expDate < DateTime.Now)
            {
                var response = await AuthenticationApi.RefreshAsync(new RefreshTokenRequest());
                authentication = new Authentication { Token = response.Token, RefreshToken = response.RefreshToken, PlayerId = response.Player.Id };
            }
            else
            {
                authentication = new Authentication { Token = accessToken, RefreshToken = refreshToken, PlayerId = payloadData.Value<string>("sub") };
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
