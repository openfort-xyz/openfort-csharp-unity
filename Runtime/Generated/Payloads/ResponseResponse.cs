
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class ResponseResponse
    {
        public DateTime created_at;
        public double? block_number;
        public string transaction_hash;
        public double gas_used;
        public double status;
        public List<string> logs;
        public string to;
        public string error;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public ResponseResponse()
        {
        }

        public ResponseResponse(DateTime created_at, double? block_number, string transaction_hash, double gas_used, double status, List<string> logs, string to, string error)
        {
            this.created_at = created_at;
            this.block_number = block_number;
            this.transaction_hash = transaction_hash;
            this.gas_used = gas_used;
            this.status = status;
            this.logs = logs;
            this.to = to;
            this.error = error;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
