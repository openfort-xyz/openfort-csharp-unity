
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class AllowFunctionsResponse
    {

        public string url;
        public List<AllowFunctionResponse> data;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public AllowFunctionsResponse()
        {
        }

        public AllowFunctionsResponse(string url, List<AllowFunctionResponse> data)
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
