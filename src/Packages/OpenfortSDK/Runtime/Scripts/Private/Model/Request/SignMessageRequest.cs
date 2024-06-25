using System;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class SignMessageRequest
    {
        /**
        * Message to be signed, can be a string or byte array
        */
        public string message;

        /**
        * Options for signing the message
        */
        public SignMessageOptions options;

        public SignMessageRequest(string message, SignMessageOptions options = null)
        {
            this.message = message;
            this.options = options;
        }

        /**
        * Creates a new SignMessageRequest with the provided message and options
        */
        public static SignMessageRequest Create(string message, SignMessageOptions options = null)
        {
            return new SignMessageRequest(message, options);
        }
    }

    [Serializable]
    public class SignMessageOptions
    {
        /**
        * Indicates whether to hash the message
        */
        public bool? hashMessage;

        /**
        * Indicates whether to convert the message to an array
        */
        public bool? arrayifyMessage;

        public SignMessageOptions(bool? hashMessage = null, bool? arrayifyMessage = null)
        {
            this.hashMessage = hashMessage;
            this.arrayifyMessage = arrayifyMessage;
        }
    }
}
