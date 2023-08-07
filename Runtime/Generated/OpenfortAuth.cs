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
    public class OpenfortAuth
    {
        private readonly Configuration _configuration;
        private readonly ApiClient _apiClient;
        private string _key;

        public OpenfortAuth(string token, string basePath = default(string))
        {
            _configuration = new Configuration(
                new Dictionary<string, string> { { "Authorization", "Bearer " + token } },
                new Dictionary<string, string> { { "Authorization", token } },
                new Dictionary<string, string> { { "Authorization", "Bearer" } });
            _apiClient = new ApiClient(basePath ?? _configuration.BasePath);
        }

        private PlayersAuthenticationApi _playersAuthenticationApi;
        public PlayersAuthenticationApi PlayersAuthenticationApi
        {
            get
            {
                if (_playersAuthenticationApi == null)
                {
                    _playersAuthenticationApi = new PlayersAuthenticationApi(_apiClient, _apiClient, _configuration);
                }
                return _playersAuthenticationApi;
            }
        }

        public async Task<AuthResponse> Signup(string email, string password, string name, string description = default(string))
        {
            var request = new SignupRequest(email, password, name, description);
            var result = await PlayersAuthenticationApi.SignupAsync(request);
            return result;
        }

        public async Task<AuthResponse> Login(string email, string password)
        {
            var request = new LoginRequest(email, password);
            var result = await PlayersAuthenticationApi.LoginAsync(request);
            return result;
        }

        public async Task<string> GetGoogleSigninUrl()
        {
            var result = await PlayersAuthenticationApi.GetSigninUrlAsync();
            _key = result.Key;
            return result.Url;
        }

        public async Task<AuthResponse> GetTokenAfterGoogleSignin()
        {
            var result = await PlayersAuthenticationApi.GetTokenAsync(_key);
            return result;
        }

        public void Logout()
        {
            PlayerPrefs.DeleteKey("openfort-auth-token");
            PlayerPrefs.DeleteKey("openfort-auth-player");
        }

        private void SaveToken(AuthResponse response) {
            PlayerPrefs.SetString("openfort-auth-token", response.Token);
            PlayerPrefs.SetString("openfort-auth-player", response.PlayerId);
        }

        public string Token
        {
            get
            {
                return PlayerPrefs.GetString("openfort-auth-token");
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
