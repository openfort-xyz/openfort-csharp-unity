
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class Gas
    {

        public string url;
        public Dictionary<string, double> dailyGasUsage;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public Gas()
        {
        }

        public Gas(string url, Dictionary<string, double> dailyGasUsage)
        {

            this.url = url;
            this.dailyGasUsage = dailyGasUsage;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
