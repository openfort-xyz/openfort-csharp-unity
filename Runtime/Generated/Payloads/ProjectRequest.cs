
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class ProjectRequest
    {
        public string name;
        public bool livemode;
        public string project;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public ProjectRequest()
        {
        }

        public ProjectRequest(string name, bool livemode, string project)
        {
            this.name = name;
            this.livemode = livemode;
            this.project = project;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
