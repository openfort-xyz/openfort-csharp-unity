
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class ContractResponseAbiAnyOfInner
    {
        public string type;
        public string name;
        public Object inputs;
        public bool _isFragment;
        public bool anonymous;
        public bool payable;
        public bool constant;
        public string stateMutability;
        public Object outputs;
        public string gas;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public ContractResponseAbiAnyOfInner()
        {
        }

        public ContractResponseAbiAnyOfInner(string type, string name, Object inputs, bool _isFragment, bool anonymous, bool payable, bool constant, string stateMutability, Object outputs, string gas)
        {
            this.type = type;
            this.name = name;
            this.inputs = inputs;
            this._isFragment = _isFragment;
            this.anonymous = anonymous;
            this.payable = payable;
            this.constant = constant;
            this.stateMutability = stateMutability;
            this.outputs = outputs;
            this.gas = gas;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
