using System.Threading.Tasks;

namespace Openfort.Signer
{
    public interface ISigner
    {
        Task<string> Sign(string message);
    }
}