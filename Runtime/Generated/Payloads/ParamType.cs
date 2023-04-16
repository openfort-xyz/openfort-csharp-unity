
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class ParamType
    {
        public string name;
        public string type;
        public string baseType;
        public bool indexed;
        public List<ParamType> components;
        public double arrayLength;
        public ParamType arrayChildren;
        public bool _isParamType;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public ParamType()
        {
        }

        public ParamType(string name, string type, string baseType, bool indexed, List<ParamType> components, double arrayLength, ParamType arrayChildren, bool _isParamType)
        {
            this.name = name;
            this.type = type;
            this.baseType = baseType;
            this.indexed = indexed;
            this.components = components;
            this.arrayLength = arrayLength;
            this.arrayChildren = arrayChildren;
            this._isParamType = _isParamType;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
