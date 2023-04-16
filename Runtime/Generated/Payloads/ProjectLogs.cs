
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class ProjectLogs
    {
        public string url;
        public List<Log> data;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public ProjectLogs()
        {
        }

        public ProjectLogs(string url, List<Log> data)
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
