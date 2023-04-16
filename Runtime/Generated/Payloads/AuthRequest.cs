
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class AuthRequest
    {
        public string email;
        public string password;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public AuthRequest()
        {
        }

        public AuthRequest(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
