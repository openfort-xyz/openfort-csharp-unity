
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class JsonFragment
    {
        public string name;
        public string type;
        public bool anonymous;
        public bool payable;
        public bool constant;
        public string stateMutability;
        public Object inputs;
        public Object outputs;
        public string gas;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public JsonFragment()
        {
        }

        public JsonFragment(string name, string type, bool anonymous, bool payable, bool constant, string stateMutability, Object inputs, Object outputs, string gas)
        {
            this.name = name;
            this.type = type;
            this.anonymous = anonymous;
            this.payable = payable;
            this.constant = constant;
            this.stateMutability = stateMutability;
            this.inputs = inputs;
            this.outputs = outputs;
            this.gas = gas;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
