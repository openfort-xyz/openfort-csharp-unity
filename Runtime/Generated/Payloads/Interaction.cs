
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;
using Newtonsoft.Json;

namespace OpenfortSdk
{
    [Serializable]
    public partial class Interaction
    {
        public string contract;
        public string function_name;
        public List<Object> function_args;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public Interaction()
        {
        }

        public Interaction(string contract, string function_name, List<Object> function_args)
        {

            this.contract = contract;
            this.function_name = function_name;
            this.function_args = function_args;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
