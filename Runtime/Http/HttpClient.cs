using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

namespace OpenfortSdk
{
    public class HttpClient
    {
        public static async UniTask<HttpResponse> Get(string url, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await Request(HttpMethod.Get, url, headers, token: token);
        }

        public static async UniTask<HttpResponse> Put(string url, object body, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await Request(HttpMethod.Put, url, headers, body, token: token);
        }

        public static async UniTask<HttpResponse> Post(string url, object body, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await Request(HttpMethod.Post, url, headers, body, token: token);
        }

        public static async UniTask<HttpResponse> Delete(string url, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await Request(HttpMethod.Delete, url, headers, token: token);
        }
        public static async UniTask<HttpResponse> Request(HttpMethod method, string url, Dictionary<string, string> headers = null, object body = null, CancellationToken token = default)
        {
            HttpResponse response = new HttpResponse();
            // TODO: don't automatically replace empty arrays w null just to get items to work
            var requestJson = body == null ? string.Empty : JsonUtility.ToJson(body);

            WWWForm form;

            UnityWebRequest uwr;

            switch (method)
            {
                case HttpMethod.Get:
                    uwr = UnityWebRequest.Get(url);
                    break;
                case HttpMethod.Delete:
                    uwr = UnityWebRequest.Delete(url);
                    break;
                case HttpMethod.Post:
                    form = CreateFormFromJson(requestJson);
                    // form.DebugLogContents();
                    uwr = form != null ? UnityWebRequest.Post(url, form) : UnityWebRequest.Post(url, new WWWForm());
                    break;
                case HttpMethod.Put:
                    form = CreateFormFromJson(requestJson);

                    if (form != null)
                    {
                        uwr = UnityWebRequest.Put(url, form.data);

                    }
                    else
                    {
                        uwr = UnityWebRequest.Put(url, new byte[] { });
                    }
                    break;
                default:
                    throw new ArgumentException("Unsupported HttpMethod");
            }

            // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
            if (method == HttpMethod.Post)
            {
                uwr.method = "POST";
            }
            else if (method == HttpMethod.Patch)
            {
                uwr.method = "PATCH";
            }
            uwr.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            uwr.SetRequestHeader("Accept", "application/json");

            if (headers != null)
            {
                foreach (var entry in headers)
                {
                    uwr.SetRequestHeader(entry.Key, entry.Value);
                }
            }

            try
            {
                var op = await uwr.SendWebRequest().WithCancellation(token);

                token.ThrowIfCancellationRequested();

                response.status = (ushort)op.responseCode;
                response.body = op.downloadHandler?.text;
                response.headers = op.GetResponseHeaders();
            }
            catch (OperationCanceledException)
            {
                UnityEngine.Debug.LogWarning($"Http Request canceled. method={method} url={url}");
            }

            return response;
        }
        public static WWWForm CreateFormFromJson(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            var form = new WWWForm();
            Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            // var dictionary = JsonUtility.FromJson<Dictionary<string, object>>(json);
            // Debug.Log dictionary 

            ProcessDictionary(dictionary, "", form);

            return form;
        }

        private static void ProcessDictionary(Dictionary<string, object> dictionary, string prefix, WWWForm form)
        {
            foreach (var keyValuePair in dictionary)
            {
                string newPrefix = string.IsNullOrEmpty(prefix) ? keyValuePair.Key : $"{prefix}[{keyValuePair.Key}]";
                Debug.Log(keyValuePair.Key + " " + keyValuePair.Value);
                if (keyValuePair.Value is List<object> list)
                {
                    ProcessList(list, newPrefix, form);
                }
                else if (keyValuePair.Value is Dictionary<string, object> nestedDictionary)
                {
                    ProcessDictionary(nestedDictionary, newPrefix, form);
                }
                else
                {
                    form.AddField(newPrefix, keyValuePair.Value.ToString());
                }
            }
        }

        private static void ProcessList(List<object> list, string prefix, WWWForm form)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string newPrefix = $"{prefix}[{i}]";

                if (list[i] is List<object> nestedList)
                {
                    ProcessList(nestedList, newPrefix, form);
                }
                else if (list[i] is Dictionary<string, object> dictionary)
                {
                    ProcessDictionary(dictionary, newPrefix, form);
                }
                else
                {
                    form.AddField(newPrefix, list[i].ToString());
                }
            }
        }
    }
}
