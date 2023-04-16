
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class AllowFunctionUpdateRequest
    {
        public string type;
        public string function_name;
        public string policy;
        public string project;
        public string contract;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public AllowFunctionUpdateRequest()
        {
        }

        public AllowFunctionUpdateRequest(string type, string function_name, string policy, string project, string contract)
        {
            this.type = type;
            this.function_name = function_name;
            this.policy = policy;
            this.project = project;
            this.contract = contract;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
