
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class PolicyUpdateRequest
    {
        public string name;
        public double chain_id;
        public string strategy;
        public string project;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public PolicyUpdateRequest()
        {
        }

        public PolicyUpdateRequest(string name, double chain_id, string strategy, string project)
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
