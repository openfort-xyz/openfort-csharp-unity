using UnityEngine;

namespace Openfort.Storage
{
    internal class PlayerPreferencesStorage : IStorage
    {
        public string Get(string key)
        {
            return PlayerPrefs.GetString(key);
        }

        public void Set(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }

        public void Delete(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }
    }
}