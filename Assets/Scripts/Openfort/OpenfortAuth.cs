using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Openfort.Api;
using Openfort.Client;
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


        public async Task<AuthResponse> Signup(string email, string password, string name, string description = default(string))
        {
            var request = new SignupRequest(email, password, name, description);
            var result = await AuthenticationApi.SignupEmailPasswordAsync(request);
            this.SaveToken(result);
            return result;
        }

        public async Task<AuthResponse> Login(string email, string password)
        {
            var request = new LoginRequest(email, password);
            var result = await AuthenticationApi.LoginEmailPasswordAsync(request);
            SaveToken(result);
            return result;
        }

        public async Task<AuthResponse> AuthWithToken(OAuthProvider provider, string token)
        {
            var request = new AuthenticateOAuthRequest(provider, token);
            var response = await AuthenticationApi.AuthenticateOAuthAsync(request);
            SaveToken(response);
            return response;
        }

        public void Logout()
        {
            PlayerPrefs.DeleteKey("openfort-auth-token");
            PlayerPrefs.DeleteKey("openfort-auth-player");
        }

        private void SaveToken(AuthResponse response) {
            PlayerPrefs.SetString("openfort-auth-token", response.Token);
            PlayerPrefs.SetString("openfort-auth-player", response.Player.Id);
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
