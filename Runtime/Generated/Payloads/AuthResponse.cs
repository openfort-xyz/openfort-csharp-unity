
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class AuthResponse
    {
        public double playerUuid;
        public string token;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public AuthResponse()
        {
        }

        public AuthResponse(double playerUuid, string token)
        {
            this.playerUuid = playerUuid;
            this.token = token;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
