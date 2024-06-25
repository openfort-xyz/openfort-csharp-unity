using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Openfort.OpenfortSDK.Helpers
{
    public static class JsonExtensions
    {
        /// <summary>
        /// Return null if the deserialization fails.
        /// </summary>
        public static T OptDeserializeObject<T>(this string json) where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception e)
            {
                Debug.Log($"Failed to deserialize: {e.Message}");
                try
                {
                    Debug.Log($"Trying to deserialize with JsonUtility");
                    return JsonUtility.FromJson<T>(json);
                }
                catch (Exception ex)
                {
                    Debug.Log($"Failed to deserialize with JsonUtility {json}: {ex.Message}");
                }

                return null;
            }
        }

        public static string ToJson<T>(this T[] array)
        {
            // Need a wrapper to serialize arrays
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            string wrapped = JsonConvert.SerializeObject(wrapper);
            // Remove the wrapper
            return wrapped.ReplaceFirst("{\"Items\":", "").ReplaceLast("}", "");
        }

        private static string ReplaceFirst(this string source, string search, string replace)
        {
            int pos = source.IndexOf(search);
            if (pos < 0)
            {
                return source;
            }
            return source.Substring(0, pos) + replace + source.Substring(pos + search.Length);
        }

        private static string ReplaceLast(this string source, string search, string replace)
        {
            int place = source.LastIndexOf(search);
            if (place == -1)
            {
                return source;
            }
            return source.Remove(place, search.Length).Insert(place, replace);
        }

        public static string ToJson(this System.Collections.Generic.IDictionary<string, object> dictionary)
        {
            return JsonConvert.SerializeObject(dictionary);
        }

        [Serializable]
        private class Wrapper<T>
        {
            [JsonProperty("Items")]
            public T[] Items;
        }
    }
    public static class JsonHelpers
    {
        public static string RemoveKeysFromJson(string json, params string[] keysToRemove)
        {
            var jsonObject = JObject.Parse(json);
            foreach (var key in keysToRemove)
            {
                jsonObject.Remove(key);
            }
            return jsonObject.ToString(Formatting.None);
        }
    }
}
