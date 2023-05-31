# Openfort SDK For Unity

## Installation (Unity Package Manager)

**Option 1 - File System**

Open `Packages/manifest.json` and add these lines:

```
"com.openfort.sdk": "https://github.com/openfort-xyz/openfort-csharp-unity.git",
"com.unity.nuget.newtonsoft-json": "3.0.1",
"com.cysharp.unitask": "https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask#2.3.3"
```

**Option 2 - Editor UI**

Follow these instructions:

https://docs.unity3d.com/Manual/upm-ui-giturl.html

And add these urls:

`https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask#2.3.3`

`https://github.com/needle-mirror/com.unity.nuget.newtonsoft-json`

`https://github.com/openfort-xyz/openfort-csharp-unity.git`


## Getting Started

1. Retrieve your openfort credentials: https://docs.openfort.xyz/docs/keys

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
            openfort.GenerateSessionKey();
            // TODO: call the games server endpoint to authenticate user and create session in openfort with keyPair.PublicBase64
            // To get public key use keyPair.PublicBase64 property
            openfort.SaveToPlayerPrefs(); // In case of the previous step success save the key

            var signature = openfort.SignMessage(message);
            openfort.SendSignatureSessionRequest(sessionId, signature);
        }
    }
}
```
## Support

The Unity SDK is a work in progress. For support, [open an issue](https://github.com/openfort-xyz/openfort-csharp-unity/issues).


## Logging

Log levels in editor are controlled by settings in `Edit > Project Settings > Openfort`.

In builds all logging is disabled unless `OPENFORT_LOGGING` is defined in Unity's `Scripting Define Symbols`