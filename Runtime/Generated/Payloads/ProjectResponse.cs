
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class ProjectResponse
    {
        public string id;
        public DateTime created_at;
        public string name;
        public bool livemode;
        public string logo_url;
        public List<ApiKeyResponse> apikeys;


        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public ProjectResponse()
        {
        }

        public ProjectResponse(string id, DateTime created_at, string name, bool livemode, string logo_url, List<ApiKeyResponse> apikeys)
        {
            this.id = id;
            this.created_at = created_at;
            this.name = name;
            this.livemode = livemode;
            this.logo_url = logo_url;
            this.apikeys = apikeys;

        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
