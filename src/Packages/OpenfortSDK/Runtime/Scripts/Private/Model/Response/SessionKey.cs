using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class SessionKey
    {
        /**
        * Address associated with the session key
        */
        public string address;

        /**
        * Indicates whether the session key is registered
        */
        public bool isRegistered;

        public SessionKey(string address, bool isRegistered)
        {
            this.address = address;
            this.isRegistered = isRegistered;
        }

        /**
        * Creates a new SessionKey with the provided address and isRegistered flag
        */
        public static SessionKey Create(string address, bool isRegistered)
        {
            return new SessionKey(address, isRegistered);
        }
    }
}


class SessionKey { public string Address { get; set; } public bool IsRegistered { get; set; } }