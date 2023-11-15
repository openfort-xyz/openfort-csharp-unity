![Openfort Protocol][banner-image]

<div align="center">
  <h4>
    <a href="https://www.openfort.xyz/">
      Website
    </a>
    <span> | </span>
    <a href="https://www.openfort.xyz/docs">
      Documentation
    </a>
    <span> | </span>
    <a href="https://www.openfort.xyz/docs/reference/api/authentication">
      API Docs
    </a>
    <span> | </span>
    <a href="https://twitter.com/openfortxyz">
      Twitter
    </a>
  </h4>
</div>

[banner-image]: https://blog-cms.openfort.xyz/uploads/1_38e40747b6.png

# Openfort Unity SDK

## Installation (Unity Package Manager)

**Option 1 - File System**

Open `Packages/manifest.json` and add these lines:

```
"com.openfort.sdk": "https://github.com/openfort-xyz/openfort-csharp-unity.git",
"com.unity.nuget.newtonsoft-json": "3.0.1",
"com.cysharp.unitask": "https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask#2.3.3"
```

**Option 2 - Editor UI**

Follow this instructions:

https://docs.unity3d.com/Manual/upm-ui-giturl.html

And add these urls:

`https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask#2.3.3`

`https://github.com/needle-mirror/com.unity.nuget.newtonsoft-json.git`

`https://github.com/openfort-xyz/openfort-csharp-unity.git`


## Getting Started

1. Retrieve your openfort credentials at the [dashboard](https://www.openfort.xyz/docs/guides/platform/keys)

2. Set credentials in `Edit > Project Settings > Openfort`

3. Generate keypair for player and register session

```csharp
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Openfort;

public class OpenfortHelloWorld : MonoBehaviour
{
    async UniTaskVoid Start()
    {
        var openfort = new OpenfortClient("pk_test_XXXXXXX");
        if (openfort.LoadSessionKey() == null) { // Load player key from Player prefs
            openfort.CreateSessionKey();
            // To get session address use sessionKey.Address property
            openfort.SaveSessionKey();

            // After registering the session key, you can then use it like:
            var signature = openfort.SignMessage(message);
            openfort.SendSignatureSessionRequest(sessionId, signature);
        }
    }
}
```
## Support

The Unity SDK is a work in progress. For support, [open an issue](https://github.com/openfort-xyz/openfort-csharp-unity/issues).

## Example

For a working example using the Openfort Unity SDK, please refer to [Lost Dungeon repository](https://github.com/openfort-xyz/lost-dungeon)
