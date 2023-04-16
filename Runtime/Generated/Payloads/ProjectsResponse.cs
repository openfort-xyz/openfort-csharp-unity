
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class ProjectsResponse
    {

        public string url;
        public List<ProjectResponse> data;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public ProjectsResponse()
        {
        }

        public ProjectsResponse(string url, List<ProjectResponse> data)
        {

            this.url = url;
            this.data = data;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
