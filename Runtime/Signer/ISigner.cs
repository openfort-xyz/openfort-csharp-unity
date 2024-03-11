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
        void Logout();
        Signer GetSignerType();
        bool UseCredentials();
        void UpdateAuthentication(Authentication auth);
    }

}