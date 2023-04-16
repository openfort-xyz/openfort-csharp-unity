
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class TransactionIntentRequest
    {
        public string player;
        public double chain_id;
        public string policy;
        public string project;
        public string account;
        public bool optimistic;
        public List<Interaction> interactions;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public TransactionIntentRequest()
        {
        }

        public TransactionIntentRequest(string player, double chain_id, string policy, string project, string account, bool optimistic, List<Interaction> interactions)
        {
            this.player = player;
            this.chain_id = chain_id;
            this.policy = policy;
            this.project = project;
            this.account = account;
            this.optimistic = optimistic;
            this.interactions = interactions;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
