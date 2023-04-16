
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class AccountsResponse
    {

        public string url;
        public List<AccountResponse> data;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public AccountsResponse()
        {
        }

        public AccountsResponse(string url, List<AccountResponse> data)
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
