using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;


namespace OpenfortSdk
{
    [Serializable]
    public partial class GetPlayersData200Response
    {

        public string object_type;
        public string url;
        public List<PlayerModel> data;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public GetPlayersData200Response()
        {
        }

        public GetPlayersData200Response(string object_type, string url, List<PlayerModel> data)
        {
            this.object_type = object_type;
            this.url = url;
            this.data = data;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
