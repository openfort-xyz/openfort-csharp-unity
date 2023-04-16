
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class ApiKeyResponse
    {
        public DateTime created_at;
        public string token;
        public string name;
        public bool livemode;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public ApiKeyResponse()
        {
        }

        public ApiKeyResponse(DateTime created_at, string token, string name, bool livemode)
        {
            this.created_at = created_at;
            this.token = token;
            this.name = name;
            this.livemode = livemode;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
