using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    public partial class PlayersApi
    {
        ApiClient apiClient;

        public PlayersApi(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>PlayerResponse</returns>
		public async UniTask<PlayerResponse> CreatePlayer(PlayerRequest playerRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<PlayerResponse>($"/v1/players", playerRequest, headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AccountResponse</returns>
		public async UniTask<AccountResponse> CreatePlayerAccount(string player, AccountRequest accountRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<AccountResponse>($"/v1/players/{player}/accounts", accountRequest, headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>PlayerResponse</returns>
		public async UniTask<PlayerResponse> GetPlayer(string id, string project = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<PlayerResponse>($"/v1/players/{id}", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AccountResponse</returns>
		public async UniTask<AccountResponse> GetPlayerAccount(string id, string player, string project = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<AccountResponse>($"/v1/players/{player}/accounts/{id}", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AccountsResponse</returns>
		public async UniTask<AccountsResponse> GetPlayerAccounts(string player, string project = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<AccountsResponse>($"/v1/players/{player}/accounts", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>InventoryResponse</returns>
		public async UniTask<InventoryResponse> GetPlayerInventory(string id, string project = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<InventoryResponse>($"/v1/players/{id}/inventory", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>PlayersResponse</returns>
		public async UniTask<PlayersResponse> GetPlayers(string project = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<PlayersResponse>($"/v1/players", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AuthResponse</returns>
		public async UniTask<AuthResponse> Login(AuthRequest authRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<AuthResponse>($"/v1/players/login", authRequest, headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AuthResponse</returns>
		public async UniTask<AuthResponse> Signup(AuthRequest authRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<AuthResponse>($"/v1/players/signup", authRequest, headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>PlayerResponse</returns>
		public async UniTask<PlayerResponse> UpdatePlayer(string id, PlayerRequest playerRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<PlayerResponse>($"/v1/players/{id}", playerRequest, headers: headers);
        }
    }
}
