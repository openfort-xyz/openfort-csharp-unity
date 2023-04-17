
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class PolicyResponse
    {
        public string id;
        public DateTime created_at;
        public string name;
        public int chain_id;
        public string strategy;
        public List<AllowFunctionResponse> allow_functions;


        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public PolicyResponse()
        {
        }

        public PolicyResponse(string id, DateTime created_at, string name, int chain_id, string strategy, List<AllowFunctionResponse> allow_functions)
        {
            this.id = id;
            this.created_at = created_at;
            this.name = name;
            this.chain_id = chain_id;
            this.strategy = strategy;
            this.allow_functions = allow_functions;

        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
