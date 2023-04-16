
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class ContractRequest
    {
        public string name;
        public double chain_id;
        public string address;
        public ContractResponseAbi abi;
        public bool public_verification;
        public string project;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public ContractRequest()
        {
        }

        public ContractRequest(string name, double chain_id, string address, ContractResponseAbi abi, bool public_verification, string project)
        {
            this.name = name;
            this.chain_id = chain_id;
            this.address = address;
            this.abi = abi;
            this.public_verification = public_verification;
            this.project = project;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
