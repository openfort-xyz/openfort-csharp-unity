using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace OpenfortSdk
{
    public static class Openfort
    {


        public static PlayersApi PlayersApi;
        public static AccountsApi AccountsApi;
        public static AllowFunctionsApi AllowFunctionsApi;
        public static ContractsApi ContractsApi;
        public static LogsApi LogsApi;
        public static PoliciesApi PoliciesApi;
        public static ProjectsApi ProjectsApi;
        public static TransactionIntentsApi TransactionIntentsApi;

        static ApiClient apiClient;
        static string baseUrl = "http://api.openfort.xyz";

        public static string PublishedKey
        {
            get => apiClient.headers.ContainsKey("Authorization") ? apiClient.headers["Authorization"] : null;
            set => apiClient.headers["Authorization"] = "Bearer " + value;
        }

        public static string SecretKey
        {
            get => apiClient.headers.ContainsKey("Authorization") ? apiClient.headers["Authorization"] : null;
            set => apiClient.headers["Authorization"] = "Bearer " + value;
        }



        static Openfort()
        {
            apiClient = new ApiClient(baseUrl);
            AccountsApi = new AccountsApi(apiClient);
            AllowFunctionsApi = new AllowFunctionsApi(apiClient);
            ContractsApi = new ContractsApi(apiClient);
            PlayersApi = new PlayersApi(apiClient);
            LogsApi = new LogsApi(apiClient);
            PoliciesApi = new PoliciesApi(apiClient);
            ProjectsApi = new ProjectsApi(apiClient);
            TransactionIntentsApi = new TransactionIntentsApi(apiClient);

        }

        // Don't log in build unless users opt in
        [Conditional("UNITY_EDITOR"), Conditional("OPENFORT_LOGGING")]
        static void Log(LogLevel level, string msg)
        {
            if (Config.LogLevel == LogLevel.None || Config.LogLevel < level) { return; }
            switch (Config.LogLevel)
            {
                case LogLevel.Warning:
                    Debug.LogWarning($"Openfort | {Time.frameCount} | {msg}");
                    break;
                case LogLevel.Error:
                    Debug.LogError($"Openfort | {Time.frameCount} | {msg}");
                    break;
                default:
                    Debug.Log($"Openfort | {Time.frameCount} | {msg}");
                    break;
            }
        }
    }
}