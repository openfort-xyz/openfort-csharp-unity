using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;


namespace OpenfortSdk
{
    [Serializable]
    public partial class AccountModel
    {
        public string id;
        public DateTime created_at;
        public bool deployed;
        public int chain_id;
        public string address;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public AccountModel()
        {
        }

        public AccountModel(string id, DateTime created_at, bool deployed, int chain_id, string address)
        {
            this.id = id;
            this.created_at = created_at;
            this.deployed = deployed;
            this.chain_id = chain_id;
            this.address = address;

        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
