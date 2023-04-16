
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class AllowFunctionResponse
    {
        public string id;
        public DateTime created_at;
        public string type;
        public string function_name;
        public ContractResponse contract;


        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public AllowFunctionResponse()
        {
        }

        public AllowFunctionResponse(string id, DateTime created_at, string type, string function_name, ContractResponse contract)
        {
            this.id = id;
            this.created_at = created_at;
            this.type = type;
            this.function_name = function_name;
            this.contract = contract;

        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
