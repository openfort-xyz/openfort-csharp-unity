
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class AccountResponse
    {
        public string id;
        public DateTime created_at;
        public string address;
        public bool deployed;

        public double chain_id;
        public List<TransactionIntentResponse> transaction_intents;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public AccountResponse()
        {
        }

        public AccountResponse(string id, DateTime created_at, string address, bool deployed, double chain_id, List<TransactionIntentResponse> transaction_intents)
        {
            this.id = id;
            this.created_at = created_at;
            this.address = address;
            this.deployed = deployed;

            this.chain_id = chain_id;
            this.transaction_intents = transaction_intents;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
