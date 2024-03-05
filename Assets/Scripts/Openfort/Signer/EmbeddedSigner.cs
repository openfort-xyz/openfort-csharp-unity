using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nethereum.Signer;
using Openfort.Api;
using Openfort.Client;
using Openfort.Crypto;
using Openfort.Model;
using Openfort.Storage;
using Org.BouncyCastle.Utilities.Encoders;

namespace Openfort.Signer
{
    public class EmbeddedSigner : ISigner
    {
        private readonly int _chainId;
        private readonly string _accessToken;
        private readonly string _recoveryPassword;
        private string _deviceId;
        private readonly IStorage _storage;
        private readonly AccountsApi _accountsApi;
        private readonly EmbeddedApi _embeddedApi;
        private readonly AuthenticationApi _authenticationApi;
        private const int Threshold = 2;
        private const int Shares = 3;
        private const int DeviceShareIndex = 0;
        private const int AuthShareIndex = 1;
        private const int RecoveryShareIndex = 2;
        
        public EmbeddedSigner(int chainId, string publishableKey, string accessToken, string recoveryPassword, [CanBeNull] string baseURL)
        {
            _chainId = chainId;
            _accessToken = accessToken;
            _recoveryPassword = recoveryPassword;
            _deviceId = string.Empty;
            _storage = new PlayerPreferencesStorage();
            
            var apiConfiguration = new Configuration(
                new Dictionary<string, string>
                {
                    { "Authorization", "Bearer " + publishableKey },
                    { "player-token" , accessToken }
                },
                new Dictionary<string, string> { { "Authorization", publishableKey } },
                new Dictionary<string, string> { { "Authorization", "Bearer" } }
            );
            
            if (baseURL != null)
            {
                apiConfiguration.BasePath = baseURL;
            }

            var api = new ApiClient(baseURL);
            
            _accountsApi = new AccountsApi(api, api, apiConfiguration);
            _embeddedApi = new EmbeddedApi(api, api, apiConfiguration);
            _authenticationApi = new AuthenticationApi(api, api, new Configuration(
                new Dictionary<string, string> {{ "Authorization", "Bearer " + publishableKey }},
                new Dictionary<string, string> { { "Authorization", publishableKey } },
                new Dictionary<string, string> { { "Authorization", "Bearer" } }
            ));
        }

        public async Task<string> EnsureEmbeddedAccount()
        {
            if (!string.IsNullOrEmpty(_deviceId)) return _deviceId;
            
            _deviceId = _storage.Get("deviceId");
            if (!string.IsNullOrEmpty(_deviceId)) return _deviceId;
            
            var playerId = await _authenticationApi.VerifyAuthTokenAsync(_accessToken);
            if (playerId == null) throw new System.Exception("Invalid player token");
            
            var accounts = await _accountsApi.GetAccountsAsync(playerId.PlayerId);
            foreach (var account in accounts.Data.Where(account => account.ChainId == _chainId))
            {
                await RecoverAccount(account.Id);
                return _deviceId;
            }
            
            await CreateAccount();
            return _deviceId;
        }

        private async Task CreateAccount()
        {
            var key = Nethereum.Signer.EthECKey.GenerateKey();
            var shares = ShamirSecretSharing.SplitPrivateKey(key.GetPrivateKey(), Shares, Threshold);
            
            var deviceShare = shares[DeviceShareIndex];
            var authShare = shares[AuthShareIndex];
            var recoveryShare = shares[RecoveryShareIndex];
            
            if (!string.IsNullOrEmpty(_recoveryPassword))
            {
                recoveryShare = Cypher.Encrypt(_recoveryPassword,recoveryShare);
            }

            var account = await _accountsApi.CreateAccountAsync(new CreateAccountRequest(_chainId, key.GetPublicAddress()));

            var device = await _embeddedApi.CreateDeviceAsync(new CreateDeviceRequest(account.Id));
            _deviceId = device.Id;

            await _embeddedApi.CreateDeviceShareAsync(_deviceId, new CreateShareRequest(recoveryShare, ShareType.Recovery, !string.IsNullOrEmpty(_recoveryPassword)));
            await _embeddedApi.CreateDeviceShareAsync(_deviceId, new CreateShareRequest(authShare, ShareType.Auth));
            _storage.Set("deviceId", _deviceId);
            _storage.Set("share", deviceShare);
        }

        private async Task RecoverAccount(string accountId)
        {
            var devices = await _embeddedApi.GetDevicesAsync(accountId);
            if (devices.Data.Count == 0) throw new System.Exception("No devices found for account");
            
            var recoveryDevice = devices.Data.First();
            var recoveryShares = await _embeddedApi.GetDeviceSharesAsync(recoveryDevice.Id);
            if (recoveryShares.Data.Count != Threshold) throw new System.Exception("Invalid number of shares found for recovery device");

            var recoveryShare = recoveryShares.Data.First(share => share.Type == ShareType.Recovery);
            var authShare = recoveryShares.Data.First(share => share.Type == ShareType.Auth);
            
            if (recoveryShare.UserEntropy && string.IsNullOrEmpty(_recoveryPassword)) throw new System.Exception("Recovery password required");
            
            if (recoveryShare.UserEntropy)
            {
                recoveryShare.Share = Cypher.Decrypt(_recoveryPassword,recoveryShare.Share);
            }

            var privateKey = ShamirSecretSharing.CombinePrivateKey(new[] { recoveryShare.Share, authShare.Share });
            var newShares = ShamirSecretSharing.SplitPrivateKey(privateKey, Shares, Threshold);
            
            var newDeviceShare = newShares[DeviceShareIndex];
            var newAuthShare = newShares[AuthShareIndex];
            var newRecoveryShare = newShares[RecoveryShareIndex];
            
            if (!string.IsNullOrEmpty(_recoveryPassword))
            {
                newRecoveryShare = Cypher.Encrypt(_recoveryPassword,newRecoveryShare);
            }
            
            var newDevice = await _embeddedApi.CreateDeviceAsync(new CreateDeviceRequest(accountId));
            _deviceId = newDevice.Id;
            
            await _embeddedApi.CreateDeviceShareAsync(_deviceId, new CreateShareRequest(newRecoveryShare, ShareType.Recovery, !string.IsNullOrEmpty(_recoveryPassword)));
            await _embeddedApi.CreateDeviceShareAsync(_deviceId, new CreateShareRequest(newAuthShare, ShareType.Auth));
            
            _storage.Set("deviceId", _deviceId);
            _storage.Set("share", newDeviceShare);
        }
        
        public async Task<string> Sign(string message)
        {
            await EnsureEmbeddedAccount();
            
            var deviceShare = _storage.Get("share");
            if (string.IsNullOrEmpty(deviceShare)) throw new System.Exception("Device share not found");
            
            var shares = await _embeddedApi.GetDeviceSharesAsync(_deviceId);
            if (shares.Data.Count == 0) throw new System.Exception("Auth share not found");
            
            var authShare = shares.Data.First(share => share.Type == ShareType.Auth);
            
            var privateKey = ShamirSecretSharing.CombinePrivateKey(new[] { deviceShare, authShare.Share });


            var bytes = Hex.Decode(message.TrimHexPrefix());
            
            var keyPair = new Nethereum.Signer.EthECKey(privateKey);
            
            var signer = new EthereumMessageSigner();
            return signer.Sign(bytes, keyPair);
        }
    }
}