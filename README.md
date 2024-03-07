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


## Usage
The package needs to be configured with your account's public key, which is available in the [dashboard](https://www.openfort.xyz/docs/guides/platform/keys). Require it with the key's value:
```csharp
var openfort = new OpenfortClient("pk_test_XXXXXXX");
```

### Authentication
The Openfort Unity SDK offers multiple authentication methods to ensure secure interaction with your services. Below are the detailed descriptions and usage examples for each method.

To begin, initialize the OpenfortAuth with your publishable key:
```csharp
var openfortAuth = new OpenfortAuth("pk_test_XXXXXXX");
```

To authenticate using an OAuth provider (e.g., Firebase), use the AuthWithToken method. You'll need to pass the OAuth provider and the token obtained from the provider:
```csharp
var authentication = await openfortAuth.AuthWithToken(OAuthProvider.Firebase, "your_oauth_token_here");
```

To validate and refresh an existing access token, use the ValidateAndRefreshToken method. This can be done with or without providing the access and refresh tokens explicitly:
```csharp
// Without tokens (uses the stored tokens)
var refreshedAuth = await openfortAuth.ValidateAndRefreshToken();

// With explicit tokens
var refreshedAuth = await openfortAuth.ValidateAndRefreshToken("access_token_here", "refresh_token_here");
```

To log out and end the current session:
```csharp
openfortAuth.Logout();
```

### Signers
In order to sign messages, you have 4 options to choose from:

* Let Openfort handle the signing process, dont need to pass any signer to the Openfort instance.
* Sign yourself and pass the signature to Openfort, dont need to pass any signer to the Openfort instance.
* Use a Session Key to sign messages, you need to pass a SessionSigner to the Openfort instance.
* Use Embedded Signer to sign messages, you need to pass an Embedded Signer to the Openfort instance.

#### Session Signer
```csharp
var sessionSigner = new SessionSigner();
var openfort = new OpenfortClient("pk_test_XXXXXXX", sessionSigner);
```

#### Embedded Signer
For the embedded signer, if your player has an account you can pass it to the embedded signer to use it. If the account is not provided, the embedded signer will check if the localstorage has a device which is already registered, if not, it will create a new device and store it in the localstorage. For the recovery process, you can ask the user for a password to encrypt the recovery share.
```csharp
var embeddedSigner = new EmbeddedSigner(chainId, "pk_test_XXXXXXX", accessToken, recoveryPassword);
var openfort = new OpenfortClient("pk_test_XXXXXXX", embeddedSigner);
```

## Support
The Unity SDK is a work in progress. For support, [open an issue](https://github.com/openfort-xyz/openfort-csharp-unity/issues).

## Example

For a working example using the Openfort Unity SDK, please refer to [Lost Dungeon repository](https://github.com/openfort-xyz/lost-dungeon)
