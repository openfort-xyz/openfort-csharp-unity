using System.Threading.Tasks;

namespace Openfort.Signer
{
    public enum Signer 
    {
        Embedded, 
        Session
    }
    internal interface ISigner
    {
        Task<string> Sign(string message);
        Task Logout();
        Signer GetSignerType();
        bool UseCredentials();
        void UpdateAuthentication(Authentication auth);
    }

}