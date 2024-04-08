using UnityEngine.Networking;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;

namespace Clients
{
    public class Shield
    {
        private readonly string _baseURL;
        private readonly string _apiKey;
        private readonly string _encryptionShare;

        public Shield(string apiKey, string baseURL = "https://shield.openfort.xyz", string encryptionShare = null)
        {
            _baseURL = baseURL;
            _apiKey = apiKey;
            _encryptionShare = encryptionShare;
        }

        public async Task<Share> GetSecret(ShieldAuthOptions auth)
        {
            var request = UnityWebRequest.Get($"{_baseURL}/shares");
            foreach (var header in GetAuthHeaders(auth))
            {
                request.SetRequestHeader(header.Key, header.Value);
            }

            var op = request.SendWebRequest();
            var tsc = new TaskCompletionSource<UnityWebRequest.Result>();
            op.completed += _ => tsc.TrySetResult(request.result);

            await tsc.Task;

            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
            {
                if (request.responseCode == 404)
                {
                    throw new NoSecretFoundException("No secret found for the given auth options");
                }
                throw new Exception($"Unexpected response: {request.responseCode}: {request.error}");
            }

            return JsonConvert.DeserializeObject<Share>(request.downloadHandler.text);
        }

        public async Task<Share> StoreSecret(Share share, ShieldAuthOptions auth)
        {
            var json = JsonConvert.SerializeObject(share);
            var request = new UnityWebRequest($"{_baseURL}/shares", "POST");
            Debug.Log(json);
            var bodyRaw = new UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            foreach (var header in GetAuthHeaders(auth))
            {
                request.SetRequestHeader(header.Key, header.Value);
            }

            var op = request.SendWebRequest();
            var tsc = new TaskCompletionSource<UnityWebRequest.Result>();
            op.completed += _ => tsc.TrySetResult(request.result);

            await tsc.Task;

            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
            {
                if (request.responseCode == 409)
                {
                    throw new SecretAlreadyExistsException("Secret already exists for the given auth options");
                }
                throw new Exception($"Unexpected response: {request.responseCode}: {request.error}");
            }
            
            return share;
        }

        private Dictionary<string, string> GetAuthHeaders(ShieldAuthOptions options)
        {
            var headers = new Dictionary<string, string>
            {
                ["x-api-key"] = _apiKey,
                ["x-auth-provider"] = options.authProvider.ToFormattedString(),
                ["Access-Control-Allow-Origin"] = _baseURL
            };

            if (!string.IsNullOrEmpty(_encryptionShare))
            {
                headers["x-encryption-part"] = _encryptionShare;
            }

            if (options is OpenfortAuthOptions openfortOptions)
            {
                headers["Authorization"] = $"Bearer {openfortOptions.openfortOAuthToken}";
                if (openfortOptions.openfortOAuthProvider != OpenfortOAuthProvider.None)
                {
                    headers["x-openfort-provider"] = openfortOptions.openfortOAuthProvider.ToFormattedString();    
                }
                if (openfortOptions.openfortOAuthTokenType != OpenfortOAuthTokenType.None)
                {
                    headers["x-openfort-token-type"] = openfortOptions.openfortOAuthTokenType.ToFormattedString();    
                }
                // Additional headers if needed
            } else if (options is CustomAuthOptions customOptions)
            {
                headers["Authorization"] = $"Bearer {customOptions.customToken}";
            }

            return headers;
        }

        // Custom exceptions
        public class NoSecretFoundException : Exception
        {
            public NoSecretFoundException(string message) : base(message) {}
        }

        public class SecretAlreadyExistsException : Exception
        {
            public SecretAlreadyExistsException(string message) : base(message) {}
        }
        
        [Serializable]
        public class Share
        {
            public string secret;
            public string entropy;
            public string salt;
            public int iterations;
            public int length;
            public string digest;
            [JsonProperty("encryption_part")]
            public string encryptionPart;
        }

        [Serializable]
        public class EncryptionParameters
        {
            public string salt;
            public int iterations;
            public int length;
            public string digest;
        }

        public enum ShieldAuthProvider
        {
            Openfort,
            Custom
        }

        [Serializable]
        public class ShieldAuthOptions
        {
            public ShieldAuthProvider authProvider;
        }

        [Serializable]
        public class OpenfortAuthOptions : ShieldAuthOptions
        {
            public OpenfortOAuthProvider openfortOAuthProvider;
            public string openfortOAuthToken;
            public OpenfortOAuthTokenType openfortOAuthTokenType;
        }

        [Serializable]
        public class CustomAuthOptions : ShieldAuthOptions
        {
            public string customToken;
        }

        public enum OpenfortOAuthProvider
        {
            None,
            Accelbyte,
            Firebase,
            Google,
            Lootlocker,
            Playfab,
            Custom,
            Oidc,
            Supabase
        }

        public enum OpenfortOAuthTokenType
        {
            None,
            IdToken,
            CustomToken
        }




    }
    public static class EnumExtensions
    {
        public static string ToFormattedString(this Shield.OpenfortOAuthProvider provider)
        {
            switch (provider)
            {
                case Shield.OpenfortOAuthProvider.None: return "none";
                case Shield.OpenfortOAuthProvider.Accelbyte: return "accelbyte";
                case Shield.OpenfortOAuthProvider.Firebase: return "firebase";
                case Shield.OpenfortOAuthProvider.Google: return "google";
                case Shield.OpenfortOAuthProvider.Lootlocker: return "lootlocker";
                case Shield.OpenfortOAuthProvider.Playfab: return "playfab";
                case Shield.OpenfortOAuthProvider.Custom: return "custom";
                case Shield.OpenfortOAuthProvider.Oidc: return "oidc";
                case Shield.OpenfortOAuthProvider.Supabase: return "supabase";
                default: throw new ArgumentOutOfRangeException(nameof(provider), provider, null);
            }
        }

        public static string ToFormattedString(this Shield.OpenfortOAuthTokenType tokenType)
        {
            switch (tokenType)
            {
                case Shield.OpenfortOAuthTokenType.None: return "none";
                case Shield.OpenfortOAuthTokenType.IdToken: return "idToken";
                case Shield.OpenfortOAuthTokenType.CustomToken: return "customToken";
                default: throw new ArgumentOutOfRangeException(nameof(tokenType), tokenType, null);
            }
        }

        public static string ToFormattedString(this Shield.ShieldAuthProvider provider)
        {
            switch (provider)
            {
                case Shield.ShieldAuthProvider.Openfort: return "openfort";
                case Shield.ShieldAuthProvider.Custom: return "custom";
                default: throw new ArgumentOutOfRangeException(nameof(provider), provider, null);
            }
        }
    }

}