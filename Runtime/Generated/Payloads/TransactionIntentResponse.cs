
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;
using Newtonsoft.Json;

namespace OpenfortSdk
{
    [Serializable]
    public partial class TransactionIntentResponse
    {
        public string id;
        public DateTime created_at;
        public DateTime updated_at;
        public int chain_id;
        public string user_operation_hash;
        public UserOpResult user_operation;
        public string policy;
        public string player;
        public string account;
        public List<Interaction> transactions;
        public ResponseResponse response;


        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public TransactionIntentResponse()
        {
        }

        public TransactionIntentResponse(string id, DateTime created_at, DateTime updated_at, int chain_id, string user_operation_hash, UserOpResult user_operation, string policy, string player, string account, List<Interaction> transactions, ResponseResponse response)
        {
            this.id = id;
            this.created_at = created_at;
            this.updated_at = updated_at;
            this.chain_id = chain_id;
            this.user_operation_hash = user_operation_hash;
            this.user_operation = user_operation;
            this.policy = policy;
            this.player = player;
            this.account = account;
            this.transactions = transactions;
            this.response = response;

        }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
