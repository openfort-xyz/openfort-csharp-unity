
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class TransactionIntentsResponse
    {

        public string url;
        public List<TransactionIntentResponse> data;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public TransactionIntentsResponse()
        {
        }

        public TransactionIntentsResponse(string url, List<TransactionIntentResponse> data)
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
