using System;
using System.Collections.Generic;

namespace Openfort.OpenfortSDK.Model
{
    [Serializable]
    public class SignTypedDataRequest
    {
        /**
        * Domain for the typed data
        */
        public TypedDataDomain domain;

        /**
        * Types for the typed data
        */
        public Dictionary<string, List<TypedDataField>> types;

        /**
        * Value for the typed data
        */
        public Dictionary<string, object> value;

        public SignTypedDataRequest(TypedDataDomain domain, Dictionary<string, List<TypedDataField>> types, Dictionary<string, object> value)
        {
            this.domain = domain;
            this.types = types;
            this.value = value;
        }

        /**
        * Creates a new SignTypedDataRequest with the provided domain, types, and value
        */
        public static SignTypedDataRequest Create(TypedDataDomain domain, Dictionary<string, List<TypedDataField>> types, Dictionary<string, object> value)
        {
            return new SignTypedDataRequest(domain, types, value);
        }
    }

    [Serializable]
    public class TypedDataDomain
    {
        public string name;
        public string version;
        public int chainId;
        public string verifyingContract;

        public TypedDataDomain(string name, string version, int chainId, string verifyingContract)
        {
            this.name = name;
            this.version = version;
            this.chainId = chainId;
            this.verifyingContract = verifyingContract;
        }
    }
}
