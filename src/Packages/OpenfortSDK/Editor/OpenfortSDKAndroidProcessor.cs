#if UNITY_EDITOR

using System;
using System.IO;
using UnityEditor;
using UnityEditor.Android;
using UnityEngine;

namespace Openfort.OpenfortSDK.Editor
{
    class IdentityAndroidProcessor : IPostGenerateGradleAndroidProject
    {
        public int callbackOrder { get { return 0; } }
        public void OnPostGenerateGradleAndroidProject(string path)
        {
            Debug.Log("MyCustomBuildProcessor.OnPostGenerateGradleAndroidProject at path " + path);

            // Find the location of the files
            string openfortSDKWebFilesDir = Path.GetFullPath("Packages/com.openfort.sdk/Runtime/Resources");
            if (!Directory.Exists(openfortSDKWebFilesDir))
            {
                Debug.LogError("The OpenfortSDK files directory doesn't exist!");
                return;
            }

            FileHelpers.CopyDirectory(openfortSDKWebFilesDir, $"{path}/src/main/assets/OpenfortSDK/Runtime/OpenfortSDK");
            Debug.Log($"Sucessfully copied OpenfortSDK files");

            AddUseAndroidX(path);
        }

        private void AddUseAndroidX(string path)
        {
            var parentDir = Directory.GetParent(path).FullName;
            var gradlePath = parentDir + "/gradle.properties";

            if (!File.Exists(gradlePath))
                throw new Exception("gradle.properties does not exist");

            var text = File.ReadAllText(gradlePath);

            text += "\nandroid.useAndroidX=true\nandroid.enableJetifier=true";

            File.WriteAllText(gradlePath, text);
        }
    }
}

#endif