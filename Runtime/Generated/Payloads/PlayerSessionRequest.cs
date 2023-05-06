
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class PlayerSessionRequest
    {
        public string publicKey;
        public string policy;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public PlayerSessionRequest()
        {
        }

        public PlayerSessionRequest(string public_key, string policy)
        {
            this.public_key = public_key;
            this.policy = policy;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
