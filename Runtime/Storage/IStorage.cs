namespace Openfort.Storage
{
    internal static class Keys
    {
        internal const string DeviceId = "openfort.deviceId";
        internal const string Share = "openfort.share";
        internal const string AuthToken = "openfort.auth_token";
        internal const string RefreshToken = "openfort.refresh_token";
        internal const string PlayerId = "openfort.player_id";
        internal const string SessionKey = "openfort.session_key";
    }
    
    internal interface IStorage
    {
        string Get(string key);
        void Set(string key, string value);
        void Delete(string key);
    }
}