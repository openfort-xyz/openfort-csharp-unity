using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    public partial class ContractsApi
    {
        ApiClient apiClient;

        public ContractsApi(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>ContractResponse</returns>
		public async UniTask<ContractResponse> CreateContract(ContractRequest contractRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<ContractResponse>($"/v1/contracts", contractRequest, headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>ContractResponse</returns>
		public async UniTask<ContractResponse> GetContract(string id, string project = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<ContractResponse>($"/v1/contracts/{id}", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>ContractsResponse</returns>
		public async UniTask<ContractsResponse> GetContracts(string project = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<ContractsResponse>($"/v1/contracts", headers: headers);
        }
    }
}
