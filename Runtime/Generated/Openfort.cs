using System;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using OpenfortSdk.Api;
using OpenfortSdk.Client;

namespace OpenfortSdk
{
    public class Openfort
    {
        private readonly Configuration _configuration;
        private readonly ApiClient _apiClient;

        public Openfort(string token)
        {
            _configuration = new Configuration(
                new Dictionary<string, string>{{"Authorization", "Bearer " + token}},
                new Dictionary<string, string>{{"Authorization", token}},
                new Dictionary<string, string>{{"Authorization", "Bearer"}});
            _apiClient = new ApiClient(_configuration.BasePath);
        }

        private ContractsApi _contractsApi;
        public ContractsApi ContractsApi
        {
            get
            {
                if (_contractsApi == null)
                {
                    _contractsApi = new ContractsApi(_apiClient, _apiClient, _configuration);
                }
                return _contractsApi;
            }
        }

        private DefaultApi _defaultApi;
        public DefaultApi DefaultApi
        {
            get
            {
                if (_defaultApi == null)
                {
                    _defaultApi = new DefaultApi(_apiClient, _apiClient, _configuration);
                }
                return _defaultApi;
            }
        }

        private LogsApi _logsApi;
        public LogsApi LogsApi
        {
            get
            {
                if (_logsApi == null)
                {
                    _logsApi = new LogsApi(_apiClient, _apiClient, _configuration);
                }
                return _logsApi;
            }
        }

        private PlayersApi _playersApi;
        public PlayersApi PlayersApi
        {
            get
            {
                if (_playersApi == null)
                {
                    _playersApi = new PlayersApi(_apiClient, _apiClient, _configuration);
                }
                return _playersApi;
            }
        }

        private PoliciesApi _policiesApi;
        public PoliciesApi PoliciesApi
        {
            get
            {
                if (_policiesApi == null)
                {
                    _policiesApi = new PoliciesApi(_apiClient, _apiClient, _configuration);
                }
                return _policiesApi;
            }
        }

        private ProjectsApi _projectsApi;
        public ProjectsApi ProjectsApi
        {
            get
            {
                if (_projectsApi == null)
                {
                    _projectsApi = new ProjectsApi(_apiClient, _apiClient, _configuration);
                }
                return _projectsApi;
            }
        }

        private TransactionIntentsApi _transactionIntentsApi;
        public TransactionIntentsApi TransactionIntentsApi
        {
            get
            {
                if (_transactionIntentsApi == null)
                {
                    _transactionIntentsApi = new TransactionIntentsApi(_apiClient, _apiClient, _configuration);
                }
                return _transactionIntentsApi;
            }
        }
    }
}
