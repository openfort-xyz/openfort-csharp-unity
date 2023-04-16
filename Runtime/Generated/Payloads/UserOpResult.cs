
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class UserOpResult
    {
        public string transactionHash;
        public bool success;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public UserOpResult()
        {
        }

        public UserOpResult(string transactionHash, bool success)
        {
            this.transactionHash = transactionHash;
            this.success = success;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
