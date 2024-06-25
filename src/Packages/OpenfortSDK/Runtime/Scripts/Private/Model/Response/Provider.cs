using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Openfort.OpenfortSDK.Model
{
    public interface IRequestArguments
    {
        string method { get; set; }
        List<object> @params { get; set; }
    }

    public class JsonRpcRequestPayload : IRequestArguments
    {
        public string method { get; set; }
        public List<object> @params { get; set; }
        public string jsonrpc { get; set; }
        public object id { get; set; }

        public JsonRpcRequestPayload()
        {
            @params = new List<object>();
        }
    }

    public delegate void JsonRpcRequestCallback(JsonRpcError err, object result);

    public class JsonRpcResponsePayload
    {
        public List<object> result { get; set; }
        public JsonRpcError error { get; set; }
        public string jsonrpc { get; set; }
        public object id { get; set; }

        public JsonRpcResponsePayload()
        {
            result = new List<object>();
        }
    }

    public class JsonRpcError
    {
        public int code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }

    public interface Provider
    {
        Task<object> Request(IRequestArguments request);
        void SendAsync(JsonRpcRequestPayload request, JsonRpcRequestCallback callback);
        void SendAsync(JsonRpcRequestPayload[] requests, JsonRpcRequestCallback callback);
        void Send(string request, JsonRpcRequestCallback callbackOrParams, JsonRpcRequestCallback callback);
        void Send(JsonRpcRequestPayload request, JsonRpcRequestCallback callbackOrParams, JsonRpcRequestCallback callback);
        void Send(JsonRpcRequestPayload[] requests, JsonRpcRequestCallback callbackOrParams, JsonRpcRequestCallback callback);
        void On(string @event, Action<object[]> listener);
        void RemoveListener(string @event, Action<object[]> listener);
        bool IsOpenfort { get; }
    }
}
