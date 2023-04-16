
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class AssetInventory
    {
        public AssetType asset_type;
        public string address;
        public double token_id;
        public double amount;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public AssetInventory()
        {
        }

        public AssetInventory(AssetType asset_type, string address, double token_id, double amount)
        {
            this.asset_type = asset_type;
            this.address = address;
            this.token_id = token_id;
            this.amount = amount;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
