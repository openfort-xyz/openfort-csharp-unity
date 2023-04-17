
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class ContractResponse
    {
        public string id;
        public DateTime created_at;
        public string name;
        public int chain_id;
        public string address;
        public ContractResponseAbi abi;
        public bool public_verification;


        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public ContractResponse()
        {
        }

        public ContractResponse(string id, DateTime created_at, string name, int chain_id, string address, ContractResponseAbi abi, bool public_verification)
        {
            this.id = id;
            this.created_at = created_at;
            this.name = name;
            this.chain_id = chain_id;
            this.address = address;
            this.abi = abi;
            this.public_verification = public_verification;

        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
