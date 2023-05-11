using System;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using OpenfortSdk.Api;
using OpenfortSdk.Client;

namespace OpenfortSdk
{
    public class OpenfortClient
    {
        private readonly Configuration _configuration;
        private readonly OpenfortSdk.Client.ApiClient _apiClient;
        private readonly PlayersApi _playersApi;

        public PlayersApi PlayersApi { get => _playersApi; }

        public OpenfortClient(string token)
        {
            _configuration = new Configuration(
                new Dictionary<string, string>{{"Authorization", "Bearer " + token}},
                new Dictionary<string, string>{{"Authorization", token}},
                new Dictionary<string, string>{{"Authorization", "Bearer"}});
            _apiClient = new OpenfortSdk.Client.ApiClient(_configuration.BasePath);
            _playersApi = new PlayersApi(_apiClient, _apiClient, _configuration);
        }
    }
}
