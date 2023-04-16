using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    public partial class PoliciesApi
    {
        ApiClient apiClient;

        public PoliciesApi(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>PolicyResponse</returns>
		public async UniTask<PolicyResponse> CreatePolicy(PolicyRequest policyRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<PolicyResponse>($"/v1/policies", policyRequest, headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AllowFunctionResponse</returns>
		public async UniTask<AllowFunctionResponse> CreatePolicyAllowFunction(string policy, AllowFunctionRequest allowFunctionRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<AllowFunctionResponse>($"/v1/policies/{policy}/allow_functions", allowFunctionRequest, headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>PoliciesResponse</returns>
		public async UniTask<PoliciesResponse> GetPolicies(string project = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<PoliciesResponse>($"/v1/policies", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>PolicyResponse</returns>
		public async UniTask<PolicyResponse> GetPolicy(string id, string project = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<PolicyResponse>($"/v1/policies/{id}", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AllowFunctionsResponse</returns>
		public async UniTask<AllowFunctionsResponse> GetPolicyAllowFunctions(string policy, string project = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<AllowFunctionsResponse>($"/v1/policies/{policy}/allow_functions", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Gas</returns>
		public async UniTask<Gas> GetPolicyDailyGasUsage(string policy, string from = default(string), string to = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<Gas>($"/v1/policies/{policy}/daily-gas-usage", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>SumGas</returns>
		public async UniTask<SumGas> GetPolicyTotalGasUsage(string policy, string from = default(string), string to = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<SumGas>($"/v1/policies/{policy}/gas-usage", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>PolicyResponse</returns>
		public async UniTask<PolicyResponse> UpdatePolicy(string id, PolicyUpdateRequest policyUpdateRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<PolicyResponse>($"/v1/policies/{id}", policyUpdateRequest, headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>AllowFunctionResponse</returns>
		public async UniTask<AllowFunctionResponse> UpdatePolicyAllowFunction(string policy, string id, AllowFunctionUpdateRequest allowFunctionUpdateRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<AllowFunctionResponse>($"/v1/policies/{policy}/allow_functions/{id}", allowFunctionUpdateRequest, headers: headers);
        }
    }
}
