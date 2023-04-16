
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class PlayerRequest
    {
        public string name;
        public string description;
        public string project;
        public string default_account;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public PlayerRequest()
        {
        }

        public PlayerRequest(string name, string description, string project, string default_account)
        {
            this.name = name;
            this.description = description;
            this.project = project;
            this.default_account = default_account;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
