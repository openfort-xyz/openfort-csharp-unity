
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class GetProjectResponse
    {
        public double id;
        public string name;
        public string logo_url;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public GetProjectResponse()
        {
        }

        public GetProjectResponse(double id, string name, string logo_url)
        {
            this.id = id;
            this.name = name;
            this.logo_url = logo_url;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
