namespace Openfort.Storage
{
    public interface IStorage
    {
        string Get(string key);
        void Set(string key, string value);
        void Delete(string key);
    }
}