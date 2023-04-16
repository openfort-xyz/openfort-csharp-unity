
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class PlayersResponse
    {

        public string url;
        public List<PlayerResponse> data;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public PlayersResponse()
        {
        }

        public PlayersResponse(string url, List<PlayerResponse> data)
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
