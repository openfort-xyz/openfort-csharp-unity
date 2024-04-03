using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Openfort.Crypto;
using UnityEngine.Networking;

namespace Clients
{
    public class Openfort
    {
        private readonly string _baseURL;
        private readonly string _publishableKey;
        private string _accessToken;
        private readonly string _thirdPartyProvider;
        private readonly string _thirdPartyTokenType;

        public Openfort(string publishableKey, string accessToken = null, string thirdPartyProvider = null, string thirdPartyTokenType = null, string baseURL = "https://api.openfort.xyz")
        {
            _publishableKey = publishableKey;
            _accessToken = accessToken;
            _thirdPartyProvider = thirdPartyProvider;
            _thirdPartyTokenType = thirdPartyTokenType;
            _baseURL = baseURL;
        }

        public string AccessToken
        {
            set => _accessToken = value;
        }

        public async Task<Account[]> GetAccounts(string playerID)
        {
            var request = UnityWebRequest.Get($"{_baseURL}/v1/accounts?player={playerID}");
            SetRequestHeaders(request);
            
            var op = request.SendWebRequest();
            var tsc = new TaskCompletionSource<UnityWebRequest.Result>();
            op.completed += _ => tsc.TrySetResult(request.result);
            await tsc.Task;
            
            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
            {
                throw new Exception($"Unexpected response: {request.responseCode}: {request.error}");
            }
            
            return JsonConvert.DeserializeObject<GetAccountsResponse>(request.downloadHandler.text).data;
        }

        public async Task<Account> CreateAccount(int chainID, string address)
        {
            var json = JsonConvert.SerializeObject(new { chainId = chainID, externalOwnerAddress = address });
            var request = new UnityWebRequest($"{_baseURL}/v1/accounts", "POST");
            var bodyRaw = new UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            SetRequestHeaders(request);
            
            var op = request.SendWebRequest();
            var tsc = new TaskCompletionSource<UnityWebRequest.Result>();
            op.completed += _ => tsc.TrySetResult(request.result);
            await tsc.Task;
            
            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
            {
                throw new Exception($"Unexpected response: {request.responseCode}: {request.error}");
            }
            
            return JsonConvert.DeserializeObject<Account>(request.downloadHandler.text);
        }

        public async Task<Device> GetDevice(string deviceID)
        {
            var request = UnityWebRequest.Get($"{_baseURL}/v1/devices/{deviceID}");
            SetRequestHeaders(request);
            
            var op = request.SendWebRequest();
            var tsc = new TaskCompletionSource<UnityWebRequest.Result>();
            op.completed += _ => tsc.TrySetResult(request.result);
            await tsc.Task;
            
            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
            {
                throw new Exception($"Unexpected response: {request.responseCode}: {request.error}");
            }
            
            return JsonConvert.DeserializeObject<Device>(request.downloadHandler.text);
        }

        public async Task<Device> GetPrimaryDevice(string account)
        {
            var request = UnityWebRequest.Get($"{_baseURL}/v1/devices/primary?account={account}");
            SetRequestHeaders(request);
            
            var op = request.SendWebRequest();
            var tsc = new TaskCompletionSource<UnityWebRequest.Result>();
            op.completed += _ => tsc.TrySetResult(request.result);
            await tsc.Task;
            
            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
            {
                throw new Exception($"Unexpected response: {request.responseCode}: {request.error}");
            }
            
            return JsonConvert.DeserializeObject<Device>(request.downloadHandler.text);
        }

        public async Task<Device> CreateDevice(string accountID, string share)
        {
            var json = JsonConvert.SerializeObject(new { account = accountID, share });
            var request = new UnityWebRequest($"{_baseURL}/v1/devices", "POST");
            var bodyRaw = new UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            SetRequestHeaders(request);
            
            var op = request.SendWebRequest();
            var tsc = new TaskCompletionSource<UnityWebRequest.Result>();
            op.completed += _ => tsc.TrySetResult(request.result);
            await tsc.Task;
            
            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
            {
                throw new Exception($"Unexpected response: {request.responseCode}: {request.error}");
            }
            
            return JsonConvert.DeserializeObject<Device>(request.downloadHandler.text);
        }
        
        public async Task<string> VerifyToken(string accessToken)
        {
            var request = UnityWebRequest.Get($"{_baseURL}/iam/v1/{_publishableKey}/jwks.json");
            request.SetRequestHeader("Authorization", $"Bearer {_publishableKey}");
            
            var op = request.SendWebRequest();
            var tsc = new TaskCompletionSource<UnityWebRequest.Result>();
            op.completed += _ => tsc.TrySetResult(request.result);
            await tsc.Task;
            
            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
            {
                throw new Exception($"Unexpected response: {request.responseCode}: {request.error}");
            }
            
            var response = JsonConvert.DeserializeObject<JwtKeyResponse>(request.downloadHandler.text);
            if (response.keys.Length == 0)
            {
                throw new Exception("No keys found");
            }
            
            return Jwt.Validate(accessToken, response.keys[0].x, response.keys[0].y, response.keys[0].crv);
        }

        public async Task<string> VerifyThirdParty(string token, string thirdPartyProvider, string thirdPartyTokenType)
        {
            var json = JsonConvert.SerializeObject(new { token, provider = thirdPartyProvider, tokenType = thirdPartyTokenType });
            var request = new UnityWebRequest($"{_baseURL}/iam/v1/oauth/third_party", "POST");
            var bodyRaw = new UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", $"Bearer {_publishableKey}");
            
            var op = request.SendWebRequest();
            var tsc = new TaskCompletionSource<UnityWebRequest.Result>();
            op.completed += _ => tsc.TrySetResult(request.result);
            await tsc.Task;
            
            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
            {
                throw new Exception($"Unexpected response: {request.responseCode}: {request.error}");
            }
            
            var idResponse = JsonConvert.DeserializeObject<ID>(request.downloadHandler.text);
            return idResponse.id;
        }

        private void SetRequestHeaders(UnityWebRequest request)
        {
            request.SetRequestHeader("Authorization", $"Bearer {_publishableKey}");
            request.SetRequestHeader("Content-Type", "application/json");
            if (!string.IsNullOrEmpty(_accessToken))
            {
                request.SetRequestHeader("X-Player-Token", _accessToken);
            }
            
            if (_thirdPartyProvider == null || _thirdPartyTokenType == null) return;
            request.SetRequestHeader("X-Auth-Provider", _thirdPartyProvider);
            request.SetRequestHeader("X-Token-Type", _thirdPartyTokenType);
        }

        [Serializable]
        public class GetAccountsResponse
        {
            [JsonProperty("object")]
            public string objectType;
            public string url;
            public Account[] data;
            public int start;
            public int end;
            public int total;
        }

        [Serializable]
        public class CreateAccountRequest
        {
            public int chainId;
            public string externalOwnerAddress;
        }

        [Serializable]
        public class CreateDeviceRequest
        {
            public string account;
            public string share;
        }

        [Serializable]
        public class Account
        {
            public string id;
            [JsonProperty("object")]
            public string objectType;
            public long createdAt; 
            public string address;
            public string ownerAddress;
            public int chainId;
            public bool embeddedSigner;
            public bool custodial;
            public ID player;
            public bool deployed;
            public string accountType;
            public ID[] transactionIntents;
        }

        [Serializable]
        public class Device
        {
            public string id;
            [JsonProperty("object")]
            public string objectType;
            public string share;
            public bool isPrimary;
            public long createdAt;
            public string account;
        }

        [Serializable]
        public class ID
        {
            public string id;
        }
        
        [Serializable]
        public class JwtKeyResponse
        {
            public JwtKey[] keys;
        }
        
        [Serializable]
        public class JwtKey
        {
            public string kty;
            public string x;
            public string y;
            public string crv;
            public string kid;
            public string use;
            public string alg;
        }
    }
} 
