using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    public partial class AccountsApi
    {
        ApiClient apiClient;

        public AccountsApi(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>AccountResponse</returns>
		public async UniTask<AccountResponse> CreateAccount(AccountRequest accountRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<AccountResponse>($"/v1/accounts", accountRequest, headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AccountResponse</returns>
		public async UniTask<AccountResponse> GetAccount(string id, string project = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<AccountResponse>($"/v1/accounts/{id}", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>InventoryResponse</returns>
		public async UniTask<InventoryResponse> GetAccountInventory(string id, string project = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<InventoryResponse>($"/v1/accounts/{id}/inventory", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AccountsResponse</returns>
		public async UniTask<AccountsResponse> GetAccounts(string player, string project = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<AccountsResponse>($"/v1/accounts", headers: headers);
        }
    }
}
