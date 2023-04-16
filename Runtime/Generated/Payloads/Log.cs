
using System;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    [Serializable]
    public partial class Log
    {
        public string id;
        public string timestamp;
        public string project_id;
        public Object requestBody;
        public double status;
        public double responseTime;
        public Object responseData;

        /// <summary>
        /// Empty constructor is for use in generics with where: new()
        /// </summary>
        public Log()
        {
        }

        public Log(string id, string timestamp, string project_id, Object requestBody, double status, double responseTime, Object responseData)
        {
            this.id = id;
            this.timestamp = timestamp;
            this.project_id = project_id;

            this.requestBody = requestBody;
            this.status = status;
            this.responseTime = responseTime;
            this.responseData = responseData;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
