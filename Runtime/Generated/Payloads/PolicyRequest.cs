
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class PolicyRequest
    {
        public string name;
        public int chain_id;
        public string strategy;
        public string project;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public PolicyRequest()
        {
        }

        public PolicyRequest(string name, int chain_id, string strategy, string project)
        {
            this.name = name;
            this.chain_id = chain_id;
            this.strategy = strategy;
            this.project = project;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
