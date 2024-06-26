using System;
using System.Linq;
using System.Threading.Tasks;
using Clients;
using Nethereum.Signer;
using Nethereum.Signer.EIP712;
using Nethereum.Util;
using Openfort.Crypto;
using Openfort.Storage;

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
        private readonly string _encryptionShare;
        private readonly Shield _shield;
        private const int Threshold = 2;
        private const int Shares = 3;
        private const int DeviceShareIndex = 0;
        private const int AuthShareIndex = 1;
        private const int RecoveryShareIndex = 2;

        public EmbeddedSigner(int chainId, string publishableKey, IStorage storage, string shieldAPIKey = null, string encryptionShare = null, string openfortURL = "https://api.openfort.xyz", string shieldURL = "https://shield.openfort.xyz")
        {
            _chainId = chainId;
            _deviceId = string.Empty;
            _storage = storage;
            _encryptionShare = encryptionShare;
            _publishableKey = publishableKey;
            _openfort = new Clients.Openfort(publishableKey, _storage.Get(Keys.AuthToken), _storage.Get(Keys.ThirdPartyProvider), _storage.Get(Keys.ThirdPartyTokenType), openfortURL);
            if (shieldAPIKey != null)
            {
                _shield = new Shield(shieldAPIKey, shieldURL, encryptionShare);
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
            var shieldShare = new Shield.Share
            {
                secret = recoveryShare,
                entropy = "none"
            };

            if (!string.IsNullOrEmpty(recoveryPassword))
            {
                var salt = Cypher.GenerateRandomSalt();
                var encryptionKey = Cypher.DeriveKey(recoveryPassword, salt);
                shieldShare.secret = Cypher.Encrypt(encryptionKey, recoveryShare);
                shieldShare.entropy = "user";
                shieldShare.salt = salt;
                shieldShare.iterations = 1000;
                shieldShare.length = 256;
                shieldShare.digest = "SHA-256";
            }

            var account = await _openfort.CreateAccount(_chainId, key.GetPublicAddress());
            var device = await _openfort.CreateDevice(account.id, authShare);
            _deviceId = device.id;

            if (!string.IsNullOrEmpty(_encryptionShare) && shieldShare.entropy != "user")
            {
                shieldShare.entropy = "project";
                shieldShare.encryptionPart = _encryptionShare;
            }

            await _shield.StoreSecret(shieldShare, auth)!;
            _storage.Set("deviceId", _deviceId);
            _storage.Set("share", deviceShare);
        }

        private async Task RecoverAccount(string accountId, string recoveryPassword, Shield.ShieldAuthOptions auth)
        {
            var primaryDevice = await _openfort.GetPrimaryDevice(accountId);
            var recoveryShare = await _shield.GetSecret(auth);

            if (recoveryShare.entropy == "user")
            {
                if (string.IsNullOrEmpty(recoveryPassword)) throw new MissingRecoveryPassword("Recovery password required");
                var salt = recoveryShare.salt;
                if (string.IsNullOrEmpty(salt)) throw new MissingRecoveryPassword("Recovery salt required");
                var encryptionKey = Cypher.DeriveKey(recoveryPassword, salt);
                recoveryShare.secret = Cypher.Decrypt(encryptionKey, recoveryShare.secret);
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

        public async Task<string> Sign(byte[] message, bool typedData = false)
        {
            await EnsureEmbeddedAccount();

            var deviceShare = _storage.Get("share");
            if (string.IsNullOrEmpty(deviceShare)) throw new System.Exception("Device share not found");

            var device = await _openfort.GetDevice(_deviceId);
            var privateKey = ShamirSecretSharing.CombinePrivateKey(new[] { deviceShare, device.share });

            var keyPair = new EthECKey(privateKey);
            if (typedData)
            {
                return EthECDSASignature.CreateStringSignature(keyPair.SignAndCalculateV(Sha3Keccack.Current.CalculateHash(message)));
            }
            else
            {
                EthereumMessageSigner signer = new EthereumMessageSigner();
                return signer.Sign(message, keyPair);
            }


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