![Openfort][banner-image]

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

## Set up

### Android setup

On Android, we utilize Chrome [Custom Tabs](https://developer.chrome.com/docs/android/custom-tabs/) (if available) to seamlessly connect gamers to OpenfortSDK from within the game.

1. In Unity go to Build Settings -> Player Settings -> Android -> Publishing Settings -> Enable Custom Main Manifest and Custom Main Gradle Template under the Build section
2. Open the newly generated Assets/Plugins/Android/AndroidManifest.xml file. Add the following code inside the <application> element:

```
<activity
  android:name="com.openfort.unity.RedirectActivity"
  android:exported="true" >
  <intent-filter android:autoVerify="true">
    <action android:name="android.intent.action.VIEW" />
    <category android:name="android.intent.category.DEFAULT" />
    <category android:name="android.intent.category.BROWSABLE" />
    <data android:scheme="mygame" android:host="callback" />
    <data android:scheme="mygame" android:host="logout" />
  </intent-filter>
</activity>
```

3. Open the newly generated Assets/Plugins/Android/mainTemplate.gradle file. Add the following code inside dependencies block:

```
implementation('androidx.browser:browser:1.5.0')
```


For this version of the Chrome Custom Tabs to work, the compileSdkVersion must be at least 33. This is usually the same value as the targetSdkVersion, which you can set in Build Settings -> Player Settings -> Android -> Other Settings -> Target API Level.

**Proguard**

If you enable Minify in your project settings, you will need to add a custom Proguard file to your project.

In Unity go to Build Settings -> Player Settings -> Android -> Publishing Settings -> Enable Custom Proguard File under the Build section
Open the newly generated Assets/Plugins/Android/proguard-user.txt file. Add the following code inside the <application> element
-dontwarn com.openfort.**
-keep class com.openfort.** { *; }
-keep interface com.openfort.** { *; }

```
-dontwarn androidx.**
-keep class androidx.** { *; }
-keep interface androidx.** { *; }
```


### iOS setup

In Unity go to Build Settings -> Player Settings -> iOS -> Other Settings -> Supported URL schemes
Increment the Size number
Add your URL scheme in the Element field, e.g. if the deeplink URL is mygame://callback, add the scheme mygame to the field.


## IL2CPP Settings

Ensure your IL2CPP settings are configured to not strip too aggressively:

- Open Player Settings: Go to Edit > Project Settings > Player.
- Other Settings: Under Other Settings, find the Managed Stripping Level and set it to Low or Disabled.


## Support
The Unity SDK is a work in progress. For support, [open an issue](https://github.com/openfort-xyz/openfort-csharp-unity/issues).