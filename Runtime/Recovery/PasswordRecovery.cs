namespace Openfort.Recovery
{
    public class PasswordRecovery : IRecovery
    {
        private readonly string _password;
        public PasswordRecovery(string password)
        {
            _password = password;
        }
        public string GetRecoveryPassword()
        {
            return _password;
        }
    }    
}