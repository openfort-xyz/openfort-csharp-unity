
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class SumGas
    {
        public string url;
        public double sumGas;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public SumGas()
        {
        }

        public SumGas(string url, double sumGas)
        {

            this.url = url;
            this.sumGas = sumGas;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
