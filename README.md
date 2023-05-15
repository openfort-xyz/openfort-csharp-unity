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

3. Add a GameObject to your scene with this MonoBehaviour in a file called `OpenfortHelloWorld.cs`:

```csharp
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using OpenfortSdk;
using UnityEngine;

public class OpenfortHelloWorld : MonoBehaviour
{
    public Chain chain = Chain.MATICMUMBAI;

    async UniTaskVoid Start()
    {

        if (string.IsNullOrEmpty(Config.PublishedKey))
        {
            Debug.LogError($"Openfort Publishable key are not set. Please set them in Edit > Project Settings > Openfort");
            return;
        }

        Log($"Getting players...");
        var client = new Openfort(Config.PublishedKey);
        var response = await client.PlayersApi.GetPlayers();

        Log($"Received players...");
        Log($"{response}");
        for (int i = 0; i < response.data.Count; i++)
        {
            Log($"{response.data[i]}");
        }
    }
    void Log(string s)
    {
        Debug.Log($"{Time.frameCount} | {s}");
    }
}
```

4. Generate keypair for player and register session

```csharp
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using OpenfortSdk.Crypto;
using UnityEngine;

public class OpenfortHelloWorld : MonoBehaviour
{
    async UniTaskVoid Start()
    {
        var privateKey = KeyPair.GetFromPlayerPrefs(); // Load player key from Player prefs
        if (privateKey == null) {
            var keyPair = KeyPair.Generate();
            // TODO: call the games server endpoint to authenticate user and create session in openfort with keyPair.PublicBase64
            keyPair.SaveToPlayerPrefs(); // In case of the previous step success save the key 
        } else {
            // The key has been loaded and ready to use
        }
    }
}
```
## Support

The Unity SDK is a work in progress. For support, [open an issue](https://github.com/openfort-xyz/openfort-csharp-unity/issues).


## Logging

Log levels in editor are controlled by settings in `Edit > Project Settings > Openfort`.

In builds all logging is disabled unless `OPENFORT_LOGGING` is defined in Unity's `Scripting Define Symbols`