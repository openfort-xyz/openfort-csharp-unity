
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class PlayerResponse
    {
        public string id;
        public DateTime created_at;
        public string name;
        public bool livemode;
        public string email;
        public string description;
        public string metadata;
        public string default_account;
        public List<TransactionIntentResponse> transaction_intents;
        public List<AccountResponse> accounts;


        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public PlayerResponse()
        {
        }

        public PlayerResponse(string id, DateTime created_at, string name, bool livemode, string email, string description, string metadata, string default_account, List<TransactionIntentResponse> transaction_intents, List<AccountResponse> accounts)
        {
            this.id = id;
            this.created_at = created_at;
            this.name = name;
            this.livemode = livemode;
            this.email = email;
            this.description = description;
            this.metadata = metadata;
            this.default_account = default_account;
            this.transaction_intents = transaction_intents;
            this.accounts = accounts;

        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
