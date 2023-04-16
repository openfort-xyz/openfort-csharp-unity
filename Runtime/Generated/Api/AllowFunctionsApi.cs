using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    public partial class AllowFunctionsApi
    {
        ApiClient apiClient;

        public AllowFunctionsApi(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>AllowFunctionResponse</returns>
		public async UniTask<AllowFunctionResponse> CreateAllowFunction(AllowFunctionRequest allowFunctionRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<AllowFunctionResponse>($"/v1/allow_functions", allowFunctionRequest, headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AllowFunctionsResponse</returns>
		public async UniTask<AllowFunctionsResponse> GetAllowFunctions(string project = default(string), string policy = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<AllowFunctionsResponse>($"/v1/allow_functions", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AllowFunctionResponse</returns>
		public async UniTask<AllowFunctionResponse> UpdateAllowFunction(string id, AllowFunctionRequest allowFunctionRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<AllowFunctionResponse>($"/v1/allow_functions/{id}", allowFunctionRequest, headers: headers);
        }
    }
}
