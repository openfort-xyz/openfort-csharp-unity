using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nethereum.Signer;
using Openfort.Api;
using Openfort.Client;
using Openfort.Crypto;
using Openfort.Model;
using Openfort.Recovery;
using Openfort.Storage;
using Org.BouncyCastle.Utilities.Encoders;

namespace Openfort.Signer
{
    internal class EmbeddedSigner : ISigner
    {
        private int _chainId;
        private IRecovery _recovery;
        private string _deviceId;
        private readonly string _publishableKey;
        private readonly IStorage _storage;
        private AccountsApi _accountsApi;
        private EmbeddedApi _embeddedApi;
        private const int Threshold = 2;
        private const int Shares = 3;
        private const int DeviceShareIndex = 0;
        private const int AuthShareIndex = 1;
        private const int RecoveryShareIndex = 2;
        
        public EmbeddedSigner(int chainId, string publishableKey, IStorage storage, string basePath = null)
        {
            _chainId = chainId;
            _deviceId = string.Empty;
            _storage = storage;
            _publishableKey = publishableKey;
            ConfigureAPIs();
        }
        
        public string GetDeviceId()
        {
            return _deviceId;
        }
        
        private void ConfigureAPIs()
        {
            var apiConfiguration = new Configuration(
                new Dictionary<string, string>
                {
                    { "Authorization", "Bearer " + _publishableKey },
                    { "player-token" , _storage.Get(Keys.AuthToken) }
                },
                new Dictionary<string, string> { { "Authorization", _publishableKey } },
                new Dictionary<string, string> { { "Authorization", "Bearer" } }
            );
            
            
            var api = new ApiClient(apiConfiguration.BasePath);
            
            _accountsApi = new AccountsApi(api, api, apiConfiguration);
            _embeddedApi = new EmbeddedApi(api, api, apiConfiguration); 
        }
        
        public void Logout()
        {
            _storage.Delete(Keys.DeviceId);
            _storage.Delete(Keys.Share);
            _deviceId = string.Empty;
        }
        
        public bool IsLoaded()
        {
            return !string.IsNullOrEmpty(_deviceId) || !string.IsNullOrEmpty(_storage.Get(Keys.DeviceId));
        }

        public async Task<string> EnsureEmbeddedAccount()
        {
            if (!string.IsNullOrEmpty(_deviceId)) return _deviceId;
            
            _deviceId = _storage.Get(Keys.DeviceId);
            if (!string.IsNullOrEmpty(_deviceId)) return _deviceId;
            
            var playerId = _storage.Get(Keys.PlayerId);
            var accounts = await _accountsApi.GetAccountsAsync(playerId);
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
            var key = EthECKey.GenerateKey();
            var shares = ShamirSecretSharing.SplitPrivateKey(key.GetPrivateKey(), Shares, Threshold);
            
            var deviceShare = shares[DeviceShareIndex];
            var authShare = shares[AuthShareIndex];
            var recoveryShare = shares[RecoveryShareIndex];
            
            if (!string.IsNullOrEmpty(_recovery.GetRecoveryPassword()))
            {
                recoveryShare = Cypher.Encrypt(_recovery.GetRecoveryPassword(),recoveryShare);
            }

            var account = await _accountsApi.CreateAccountAsync(new CreateAccountRequest(_chainId, externalOwnerAddress: key.GetPublicAddress()));

            var device = await _embeddedApi.CreateDeviceAsync(new CreateDeviceRequest(account.Id));
            _deviceId = device.Id;

            await _embeddedApi.CreateDeviceShareAsync(_deviceId, new CreateShareRequest(recoveryShare, ShareType.Recovery, !string.IsNullOrEmpty(_recovery.GetRecoveryPassword())));
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
            
            if (recoveryShare.UserEntropy && string.IsNullOrEmpty(_recovery.GetRecoveryPassword())) throw new System.Exception("Recovery password required");
            
            if (recoveryShare.UserEntropy)
            {
                recoveryShare.Share = Cypher.Decrypt(_recovery.GetRecoveryPassword(),recoveryShare.Share);
            }

            var privateKey = ShamirSecretSharing.CombinePrivateKey(new[] { recoveryShare.Share, authShare.Share });
            var newShares = ShamirSecretSharing.SplitPrivateKey(privateKey, Shares, Threshold);
            
            var newDeviceShare = newShares[DeviceShareIndex];
            var newAuthShare = newShares[AuthShareIndex];
            var newRecoveryShare = newShares[RecoveryShareIndex];
            
            if (!string.IsNullOrEmpty(_recovery.GetRecoveryPassword()))
            {
                newRecoveryShare = Cypher.Encrypt(_recovery.GetRecoveryPassword(),newRecoveryShare);
            }
            
            var newDevice = await _embeddedApi.CreateDeviceAsync(new CreateDeviceRequest(accountId));
            _deviceId = newDevice.Id;
            
            await _embeddedApi.CreateDeviceShareAsync(_deviceId, new CreateShareRequest(newRecoveryShare, ShareType.Recovery, !string.IsNullOrEmpty(_recovery.GetRecoveryPassword())));
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
            
            var keyPair = new EthECKey(privateKey);
            
            var signer = new EthereumMessageSigner();
            return signer.Sign(bytes, keyPair);
        }
        
        public Signer GetSignerType()
        {
            return Signer.Embedded;
        }

        public bool UseCredentials()
        {
            return true;
        }

        public void UpdateAuthentication(Authentication auth)
        {
            ConfigureAPIs();
        }

        public void SetRecovery(IRecovery recovery)
        {
            _recovery = recovery;
        }
    }
}