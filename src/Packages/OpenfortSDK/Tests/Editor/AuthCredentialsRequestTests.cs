using NUnit.Framework;
using Openfort.OpenfortSDK.Model;
using UnityEngine;

namespace Openfort.OpenfortSDK.Tests
{
    public class AuthCredentialsRequestTests
    {
        [Test]
        public void SerializesToBridgeStoreCredentialsShape()
        {
            var request = AuthCredentialsRequest.Create("pla_123", "access-token");

            Assert.AreEqual(
                "{\"userId\":\"pla_123\",\"token\":\"access-token\"}",
                JsonUtility.ToJson(request)
            );
        }

#pragma warning disable CS0618 // Exercises the obsolete overload kept for source compatibility.
        [Test]
        public void LegacyOverloadMapsPlayerAndAccessTokenAndDropsRefreshToken()
        {
            var request = AuthCredentialsRequest.Create("pla_123", "access-token", "refresh-token");

            Assert.AreEqual(
                "{\"userId\":\"pla_123\",\"token\":\"access-token\"}",
                JsonUtility.ToJson(request)
            );
        }
#pragma warning restore CS0618
    }
}
