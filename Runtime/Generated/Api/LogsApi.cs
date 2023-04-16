using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    public partial class LogsApi
    {
        ApiClient apiClient;

        public LogsApi(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>ProjectLogs</returns>
		public async UniTask<ProjectLogs> GetProjectLogs(Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<ProjectLogs>($"/v1/logs", headers: headers);
        }
    }
}
