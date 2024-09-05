![Illustration_03](https://github.com/user-attachments/assets/60e38fd3-2078-4af6-ada5-8eebf35f3f7c)


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

## Installation

### Via UPM window

Since .dll files are stored on Git Large File Storage, you must download and install git-lfs from [here](https://git-lfs.github.com/).
1. Open the Package Manager
2. Click the add + button and select "Add package from git URL..."
Enter https://github.com/openfort-xyz/openfort-csharp-unity.git?path=/src/Packages/OpenfortSDK and click 'Add'

### Via manifest.json
Since .dll files are stored on Git Large File Storage, you must download and install git-lfs from [here](https://git-lfs.github.com/).
1. Open your project's Packages/manifest.json file
2. Add "com.openfort.sdk": "https://github.com/openfort-xyz/openfort-csharp-unity.git?path=/src/Packages/OpenfortSDK" in the dependencies block


**Dependencies**
The Unity SDK requires [UniTask](https://github.com/Cysharp/UniTask) package (version 2.3.3) as specified in package.json.

How to install UniTask:
Follow the instructions [here](https://github.com/Cysharp/UniTask#upm-package).

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

## Supported platforms
- Windows (64-bit)
- macOS (minimum version 12.5)
- Android (minimum version 5.1)
- iOS (minimum version 15.2)

## Supported Unity Versions
- Unity 2021.3 or newer for Windows, macOS, Android and iOS
- Unity 2019.4 or newer for macOS, Android, and iOS. Windows isn't supported on Unity versions from 2019.4 up through 2021.2.

## Target platform VS Unity editor platform
We have added compilation flags to the Unity SDK to ensure that specific Unity editors can only build certain platform targets. Please note that the table below indicates which editor you can use to build a platform target, but it does not determine whether you can run the SDK in that editor.

For example, the SDK allows you to build iOS games using a macOS Unity Editor, but you cannot use the Windows Unity Editor.

Target Platform: The platform you're building for

| Target Platform      | Windows | macOS | Android | iOS |
| -------------------- | ------- | ----- | ------- | --- |
| Windows Unity Editor | ✅       | ❌     | ✅       | ❌   |
| macOS Unity Editor   | ❌       | ✅     | ✅       | ✅   |

## Support
The Unity SDK is a work in progress. For support, [open an issue](https://github.com/openfort-xyz/openfort-csharp-unity/issues).
