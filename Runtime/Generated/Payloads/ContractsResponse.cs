
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class ContractsResponse
    {

        public string url;
        public List<ContractResponse> data;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public ContractsResponse()
        {
        }

        public ContractsResponse(string url, List<ContractResponse> data)
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
