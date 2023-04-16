
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class AssetType
    {

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public AssetType()
        {
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
