
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class Fragment
    {
        public string type;
        public string name;
        public List<ParamType> inputs;
        public bool _isFragment;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public Fragment()
        {
        }

        public Fragment(string type, string name, List<ParamType> inputs, bool _isFragment)
        {
            this.type = type;
            this.name = name;
            this.inputs = inputs;
            this._isFragment = _isFragment;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
