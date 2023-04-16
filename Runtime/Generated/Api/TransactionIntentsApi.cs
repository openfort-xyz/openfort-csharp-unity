using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    public partial class TransactionIntentsApi
    {
        ApiClient apiClient;

        public TransactionIntentsApi(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>TransactionIntentResponse</returns>
		public async UniTask<TransactionIntentResponse> CreateTransactionIntent(TransactionIntentRequest transactionIntentRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<TransactionIntentResponse>($"/v1/transaction_intents", transactionIntentRequest, headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>TransactionIntentsResponse</returns>
		public async UniTask<TransactionIntentsResponse> GetTransactionIntents(string project = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<TransactionIntentsResponse>($"/v1/transaction_intents", headers: headers);
        }
    }
}
