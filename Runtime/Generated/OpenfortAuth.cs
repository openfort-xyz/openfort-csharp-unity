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

        private AuthenticationApi _authenticationApi;
        public AuthenticationApi AuthenticationApi
        {
            get
            {
                if (_authenticationApi == null)
                {
                    _authenticationApi = new AuthenticationApi(_apiClient, _apiClient, _configuration);
                }
                return _authenticationApi;
            }
        }

        private GoogleAuthenticationApi _googleAuthenticationApi;
        public GoogleAuthenticationApi GoogleAuthenticationApi
        {
            get
            {
                if (_googleAuthenticationApi == null)
                {
                    _googleAuthenticationApi = new GoogleAuthenticationApi(_apiClient, _apiClient, _configuration);
                }
                return _googleAuthenticationApi;
            }
        }

        private OAuthApi _oauthApi;
        public OAuthApi OAuthApi
        {
            get
            {
                if (_oauthApi == null)
                {
                    _oauthApi = new OAuthApi(_apiClient, _apiClient, _configuration);
                }
                return _oauthApi;
            }
        }

        public async Task<AuthResponse> Signup(string email, string password, string name, string description = default(string))
        {
            var request = new SignupRequest(email, password, name, description);
            var result = await AuthenticationApi.SignupAsync(request);
            this.SaveToken(result);
            return result;
        }

        public async Task<AuthResponse> Login(string email, string password)
        {
            var request = new LoginRequest(email, password);
            var result = await AuthenticationApi.LoginAsync(request);
            this.SaveToken(result);
            return result;
        }

        public async Task<AuthResponse> AuthWithToken(OAuthProvider provider, string token)
        {
            var request = new OAuthRequest(token);
            var response = await OAuthApi.AuthorizeWithOAuthTokenAsync(provider, request);
            var result = response.GetAuthResponse();
            this.SaveToken(result);
            return result;
        }

        public async Task<string> GetGoogleSigninUrl()
        {
            var result = await GoogleAuthenticationApi.GetSigninUrlAsync();
            _key = result.Key;
            return result.Url;
        }

        public async Task<AuthResponse> GetTokenAfterGoogleSignin()
        {
            var result = await GoogleAuthenticationApi.GetTokenAsync(_key);
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
