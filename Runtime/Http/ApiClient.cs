using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace OpenfortSdk
{
    /// <summary>
    /// Provides an interface to an http rest api
    ///
    /// Handles authentication, signing requests and base url
    /// </summary>
    public class ApiClient
    {
        /// <summary>
        /// Create a json api client for a REST api
        /// </summary>
        /// <param name="baseUrl">base url for requests, e.g. https://api.example.com</param>
        /// <param name="basicAuth">plaintext string to be base64 encoded as HTTP basic auth</param>
        public ApiClient(string baseUrl, string basicAuth = null)
        {
            this.baseUrl = baseUrl;
            this.BasicAuth = basicAuth;
        }

        /// <summary>
        /// accessToken authenticates us with a server using x-access-token
        /// </summary>
        public string accessToken;

        /// <summary>
        /// basicAuth authenticates us with a server using base64 encoded basic auth string
        /// </summary>
        public string BasicAuth
        {
            get => basicAuth;
            set => basicAuth = Base64Encode(value);
        }
        string basicAuth;


        /// <summary>
        /// headers set here are sent with every request
        /// </summary>
        /// <typeparam name="string">http header name, e.g. "Content-Type"</typeparam>
        /// <typeparam name="string">http header value, e.g. "application/json"</typeparam>
        /// <returns></returns>
        public Dictionary<string, string> headers = new Dictionary<string, string>();

        /// <summary>
        /// baseUrl defines the base url to use with each path
        /// </summary>
        public string baseUrl;

        /// <summary>
        /// Sends an HTTP GET request to the given path
        /// </summary>
        /// <param name="path">path to api resource, e.g. "/v1/tweets"</param>
        /// <param name="headers">dictionary of http headers</param>
        /// <param name="token">cancellation token</param>
        /// <typeparam name="T">A <see cref="System.Serializable" /> class to populate with data. </typeparam>
        /// <returns>T</returns>
        public async UniTask<T> Get<T>(string path, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await Request<T>(HttpMethod.Get, path, headers, token: token);
        }

        /// <summary>
        /// Sends an HTTP PUT request to the given path
        /// </summary>
        /// <param name="path">path to api resource, e.g. "/v1/tweets"</param>
        /// <param name="headers">dictionary of http headers</param>
        /// <param name="token">cancellation token</param>
        /// <typeparam name="T">A <see cref="System.Serializable" /> class to populate with data. </typeparam>
        /// <returns>T</returns>
        public async UniTask<T> Put<T>(string path, object body = null, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await Request<T>(HttpMethod.Put, path, headers, body, token: token);
        }

        /// <summary>
        /// Sends an HTTP POST request to the given path
        /// </summary>
        /// <param name="path">path to api resource, e.g. "/v1/tweets"</param>
        /// <param name="headers">dictionary of http headers</param>
        /// <param name="token">cancellation token</param>
        /// <typeparam name="T">A <see cref="System.Serializable" /> class to populate with data. </typeparam>
        /// <returns>T</returns>
        public async UniTask<T> Post<T>(string path, object body = null, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await Request<T>(HttpMethod.Post, path, headers, body, token: token);
        }

        /// <summary>
        /// Sends an HTTP DELETE request to the given path
        /// </summary>
        /// <param name="path">path to api resource, e.g. "/v1/tweets"</param>
        /// <param name="headers">dictionary of http headers</param>
        /// <param name="token">cancellation token</param>
        /// <typeparam name="T">A <see cref="System.Serializable" /> class to populate with data. </typeparam>
        /// <returns>T</returns>
        public async UniTask<T> Delete<T>(string path, object body = null, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await Request<T>(HttpMethod.Delete, path, headers, body, token: token);
        }

        /// <summary>
        /// Sends an HTTP PATCH request to the given path
        /// </summary>
        /// <param name="path">path to api resource, e.g. "/v1/tweets"</param>
        /// <param name="headers">dictionary of http headers</param>
        /// <param name="token">cancellation token</param>
        /// <typeparam name="T">A <see cref="System.Serializable" /> class to populate with data. </typeparam>
        /// <returns>T</returns>
        public async UniTask<T> Patch<T>(string path, object body = null, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await Request<T>(HttpMethod.Patch, path, headers, body, token: token);
        }

        public async UniTask<Dictionary<string, float>> GetDictionary(string path, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await RequestDictionary(HttpMethod.Get, path, headers, token: token);
        }

        public async UniTask<float> GetFloat(string path, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await RequestFloat(HttpMethod.Get, path, headers, token: token);
        }

        public async UniTask<int> GetInt(string path, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await RequestInt(HttpMethod.Get, path, headers, token: token);
        }

        public async UniTask<HttpResponse> Get(string path, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await Request(HttpMethod.Get, path, headers, token: token);
        }

        public async UniTask<HttpResponse> Post(string path, object body, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await Request(HttpMethod.Post, path, headers, body, token: token);
        }

        public async UniTask<HttpResponse> Put(string path, object body, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await Request(HttpMethod.Put, path, headers, body, token: token);
        }

        public async UniTask<HttpResponse> Delete(string path, object body = null, Dictionary<string, string> headers = null, CancellationToken token = default)
        {
            return await Request(HttpMethod.Delete, path, headers, body, token: token);
        }

        // this is a workaround for https://forum.unity.com/threads/jsonutility-fromjson-is-empty-for-simple-dictionary.605398/
        // FIXME: don't parse all dictionaries as floats
        async UniTask<Dictionary<string, float>> RequestDictionary(HttpMethod method, string path, Dictionary<string, string> headers = null, object body = null, CancellationToken token = default)
        {
            var response = await Request(method, path, headers, body, token);
            if (response.body.Trim() == "{}")
            {
                return new Dictionary<string, float>();
            }

            string[] values = response.body.Replace("{", string.Empty).Replace("}", string.Empty).Replace("\"", string.Empty).Split(':', ',');
            Dictionary<string, float> ret = new Dictionary<string, float>();
            for (int i = 0; i < values.Length; i += 2)
            {
                if (float.TryParse(values[i + 1], NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out float n))
                {
                    ret[values[i]] = n;
                }
                else
                {
                    Debug.LogError($"Couldn't parse {values[i + 1]} at position {i + 1} as int. response={response.body}");
                }
            }
            return ret;
        }

        async UniTask<float> RequestFloat(HttpMethod method, string path, Dictionary<string, string> headers = null, object body = null, CancellationToken token = default)
        {
            var response = await Request(method, path, headers, body, token);

            string newJson = "{ \"data\": " + response.body + "}";
            Wrapper<string> wrapper = JsonUtility.FromJson<Wrapper<string>>(newJson);
            if (float.TryParse(wrapper.data, NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out float n))
            {
                return n;
            }
            else
            {
                throw new Exception($"Couldn't parse {wrapper.data} as float. response={response.body}");
            }
        }

        async UniTask<int> RequestInt(HttpMethod method, string path, Dictionary<string, string> headers = null, object body = null, CancellationToken token = default)
        {
            var response = await Request(method, path, headers, body, token);

            string newJson = "{ \"data\": " + response.body + "}";
            Wrapper<string> wrapper = JsonUtility.FromJson<Wrapper<string>>(newJson);
            if (int.TryParse(wrapper.data, NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out int n))
            {
                return n;
            }
            else
            {
                throw new Exception($"Couldn't parse {wrapper.data} as int. response={response.body}");
            }
        }

        async UniTask<T> Request<T>(HttpMethod method, string path, Dictionary<string, string> headers = null, object body = null, CancellationToken token = default)
        {
            var response = await Request(method, path, headers, body, token);

            // this is a workaround for https://answers.unity.com/questions/1123326/jsonutility-array-not-supported.html
            if (response.body.TrimStart()[0] == '[')
            {
                string newJson = "{ \"data\": " + response.body + "}";
                Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
                return wrapper.data;
            }

            var obj = JsonUtility.FromJson<T>(response.body);
            if (obj == null)
            {
                throw new Exception($"{response.body}");
            }
            return obj;
        }

        async UniTask<HttpResponse> Request(HttpMethod method, string path, Dictionary<string, string> headers = null, object body = null, CancellationToken token = default)
        {
            if (headers == null) { headers = new Dictionary<string, string>(); }
            headers["Accept"] = "application/json";
            foreach (var entry in this.headers)
            {
                if (!headers.ContainsKey(entry.Key))
                {
                    headers[entry.Key] = entry.Value;
                }
            }

            if (!string.IsNullOrEmpty(accessToken))
            {
                headers["X-Access-Token"] = accessToken;
            }
            if (!string.IsNullOrEmpty(basicAuth))
            {
                headers["Authorization"] = $"Basic {basicAuth}";
            }

            var url = baseUrl + PrependPath(path);
            return await HttpClient.Request(method, url, headers, body, token);
        }

        string Base64Encode(string plainText)
        {
            if (plainText == null) { return null; }
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        string PrependPath(string path)
        {
            return path[0] == '/' ? path : $"/{path}";
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T data;
        }
    }
}
