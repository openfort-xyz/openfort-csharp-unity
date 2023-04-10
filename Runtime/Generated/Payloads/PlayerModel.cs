using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;


namespace OpenfortSdk
{
    [Serializable]
    public partial class PlayerModel
    {
        public string id;
        public DateTime created_at;
        public bool livemode;
        public string email;
        public string description;
        public string name;
        public Dictionary<string, object> metadata;
        public List<AccountModel> accounts;
        public string object_type;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public PlayerModel()
        {
        }

        public PlayerModel(string id, bool livemode, DateTime created_at, string email, string description, string name, Dictionary<string, object> metadata, List<AccountModel> accounts, string object_type)
        {
            this.id = id;
            this.livemode = livemode;
            this.email = email;
            this.description = description;
            this.name = name;
            this.metadata = metadata;
            this.accounts = accounts;
            this.object_type = object_type;
            this.created_at = created_at;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
