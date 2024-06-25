using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class RegisterSessionRequest
    {
        /**
        * ID of the session
        */
        public string sessionId;

        /**
        * Signature for the session
        */
        public string signature;

        /**
        * Indicates whether to use optimistic mode
        */
        public bool? optimistic;

        public RegisterSessionRequest(string sessionId, string signature, bool? optimistic = null)
        {
            this.sessionId = sessionId;
            this.signature = signature;
            this.optimistic = optimistic;
        }

        /**
        * Creates a new RegisterSessionRequest with the provided sessionId, signature, and optimistic flag
        */
        public static RegisterSessionRequest Create(string sessionId, string signature, bool? optimistic = null)
        {
            return new RegisterSessionRequest(sessionId, signature, optimistic);
        }
    }
}
