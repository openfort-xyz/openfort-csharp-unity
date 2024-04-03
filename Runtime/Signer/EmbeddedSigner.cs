using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients;
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
    public class RecoveryNotConfigured : Exception { public RecoveryNotConfigured(string message) : base(message) { } }
    public class MissingRecoveryPassword : Exception { public MissingRecoveryPassword(string message) : base(message) { } }
    internal class EmbeddedSigner : ISigner
    {
        private int _chainId;
        private string _deviceId;
        private readonly string _publishableKey;
        private readonly IStorage _storage;
        private readonly Clients.Openfort _openfort;
        private readonly Clients.Shield _shield;
        private const int Threshold = 2;
        private const int Shares = 3;
        private const int DeviceShareIndex = 0;
        private const int AuthShareIndex = 1;
        private const int RecoveryShareIndex = 2;
        
        public EmbeddedSigner(int chainId, string publishableKey, IStorage storage, string shieldAPIKey = null, string openfortURL = "https://api.openfort.xyz", string shieldURL = "https://shield.openfort.xyz")
        {
            _chainId = chainId;
            _deviceId = string.Empty;
            _storage = storage;
            _publishableKey = publishableKey;
            _openfort = new Clients.Openfort(publishableKey, _storage.Get(Keys.AuthToken), _storage.Get(Keys.ThirdPartyProvider), _storage.Get(Keys.ThirdPartyTokenType), openfortURL);
            if (shieldAPIKey != null)
            {
                _shield = new Clients.Shield(shieldAPIKey, shieldURL);
            }
        }
        
        public string GetDeviceId()
        {
            return _deviceId;
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

        public async Task<string> EnsureEmbeddedAccount(string recoveryPassword = null, Shield.ShieldAuthOptions auth = null)
        {
            if (!string.IsNullOrEmpty(_deviceId)) return _deviceId;
            
            _deviceId = _storage.Get(Keys.DeviceId);
            if (!string.IsNullOrEmpty(_deviceId)) return _deviceId;
            
            var playerId = _storage.Get(Keys.PlayerId);

            if (_shield == null)
            {
                throw new RecoveryNotConfigured("Shield API not configured");
            }
            
            if (auth == null)
            {
                throw new RecoveryNotConfigured("Auth options required");
            }

            var accounts = await _openfort.GetAccounts(playerId);
            foreach (var account in accounts.Where(account => account.chainId == _chainId))
            {
                await RecoverAccount(account.id, recoveryPassword, auth);
                return _deviceId;
            }
            
            await CreateAccount(recoveryPassword, auth);
            return _deviceId;
        }

        private async Task CreateAccount(string recoveryPassword, Shield.ShieldAuthOptions auth)
        {
            var key = EthECKey.GenerateKey();
            var shares = ShamirSecretSharing.SplitPrivateKey(key.GetPrivateKey(), Shares, Threshold);
            
            var deviceShare = shares[DeviceShareIndex];
            var authShare = shares[AuthShareIndex];
            var recoveryShare = shares[RecoveryShareIndex];

            var salt = "";
            if (!string.IsNullOrEmpty(recoveryPassword))
            {
                salt = Cypher.GenerateRandomSalt();
                var encryptionKey = Cypher.DeriveKey(recoveryPassword, salt);
                recoveryShare = Cypher.Encrypt(encryptionKey,recoveryShare);
            }

            var account = await _openfort.CreateAccount(_chainId, key.GetPublicAddress());
            var device = await _openfort.CreateDevice(account.id, authShare);
            _deviceId = device.id;
            
            var share = new Shield.Share
            {
                secret = recoveryShare,
                userEntropy = !string.IsNullOrEmpty(recoveryPassword)
            };

            if (!string.IsNullOrEmpty(salt))
            {
                share.encryptionParameters = new Shield.EncryptionParameters
                {
                    salt = salt,
                    iterations = 1000,
                    length = 256,
                    digest = "SHA-256"
                };
            }
            await _shield.StoreSecret(share, auth)!;
            _storage.Set("deviceId", _deviceId);
            _storage.Set("share", deviceShare);
        }

        private async Task RecoverAccount(string accountId, string recoveryPassword, Shield.ShieldAuthOptions auth)
        {
            var primaryDevice = await _openfort.GetPrimaryDevice(accountId);
            var recoveryShare = await _shield.GetSecret(auth);
            
            if (recoveryShare.userEntropy)
            {
                if (string.IsNullOrEmpty(recoveryPassword)) throw new MissingRecoveryPassword("Recovery password required");
                var salt = recoveryShare.encryptionParameters.salt;
                if (string.IsNullOrEmpty(salt)) throw new MissingRecoveryPassword("Recovery salt required");
                var encryptionKey = Cypher.DeriveKey(recoveryPassword, salt);
                recoveryShare.secret = Cypher.Decrypt(encryptionKey,recoveryShare.secret);
            }

            var privateKey = ShamirSecretSharing.CombinePrivateKey(new[] { recoveryShare.secret, primaryDevice.share });
            var newShares = ShamirSecretSharing.SplitPrivateKey(privateKey, Shares, Threshold);
            
            var newDeviceShare = newShares[DeviceShareIndex];
            var newAuthShare = newShares[AuthShareIndex];
          
            var newDevice = await _openfort.CreateDevice(accountId, newAuthShare);
            _deviceId = newDevice.id;
            _storage.Set("deviceId", _deviceId);
            _storage.Set("share", newDeviceShare);
        }
        
        public async Task<string> Sign(string message)
        {
            await EnsureEmbeddedAccount();
            
            var deviceShare = _storage.Get("share");
            if (string.IsNullOrEmpty(deviceShare)) throw new System.Exception("Device share not found");
            
            var device = await _openfort.GetDevice(_deviceId);
            var privateKey = ShamirSecretSharing.CombinePrivateKey(new[] { deviceShare, device.share });

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
            _openfort.AccessToken = auth.Token;
        }
    }
}