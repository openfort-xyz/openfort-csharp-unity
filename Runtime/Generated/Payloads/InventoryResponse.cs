
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class InventoryResponse
    {

        public List<AssetInventory> nft_assets;
        public AssetInventory native_asset;
        public List<AssetInventory> token_assets;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public InventoryResponse()
        {
        }

        public InventoryResponse(List<AssetInventory> nft_assets, AssetInventory native_asset, List<AssetInventory> token_assets)
        {

            this.nft_assets = nft_assets;
            this.native_asset = native_asset;
            this.token_assets = token_assets;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
