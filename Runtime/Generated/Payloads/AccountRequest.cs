
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class AccountRequest
    {
        public string name;
        public string project;
        public double chain_id;
        public string player;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public AccountRequest()
        {
        }

        public AccountRequest(string name, string project, double chain_id, string player)
        {
            this.name = name;
            this.project = project;
            this.chain_id = chain_id;
            this.player = player;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
