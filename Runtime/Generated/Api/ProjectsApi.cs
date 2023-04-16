using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    public partial class ProjectsApi
    {
        ApiClient apiClient;

        public ProjectsApi(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>ProjectResponse</returns>
		public async UniTask<ProjectResponse> CreateProject(ProjectRequest projectRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<ProjectResponse>($"/v1/projects", projectRequest, headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>GetProjectResponse</returns>
		public async UniTask<GetProjectResponse> Get(Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<GetProjectResponse>($"/v1/projects/auth", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>ProjectResponse</returns>
		public async UniTask<ProjectResponse> GetProject(string id, Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<ProjectResponse>($"/v1/projects/{id}", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>ProjectsResponse</returns>
		public async UniTask<ProjectsResponse> GetProjects(string project = default(string), Dictionary<string, string> headers = null)
        {
            return await apiClient.Get<ProjectsResponse>($"/v1/projects", headers: headers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>ProjectResponse</returns>
		public async UniTask<ProjectResponse> UpdateProject(string id, ProjectRequest projectRequest, Dictionary<string, string> headers = null)
        {
            return await apiClient.Post<ProjectResponse>($"/v1/projects/{id}", projectRequest, headers: headers);
        }
    }
}
