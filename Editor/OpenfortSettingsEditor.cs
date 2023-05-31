using UnityEditor;

#if UNITY_2018_3_OR_NEWER
namespace Openfort.Editor
{
    internal class OpenfortSettingsEditor
    {
        [SettingsProvider]
        internal static SettingsProvider CreateCustomSettingsProvider()
        {
            // First parameter is the path in the Settings window.
            // Second parameter is the scope of this setting: it only appears in the Project Settings window.
            var provider = new SettingsProvider("Project/Openfort", SettingsScope.Project)
            {
                // Create the SettingsProvider and initialize its drawing (IMGUI) function in place:
                guiHandler = (searchContext) =>
                {
                    UnityEditor.Editor.CreateEditor(OpenfortSettings.Instance).OnInspectorGUI();
                },

                // Populate the search keywords to enable smart search filtering and label highlighting:
                keywords = SettingsProvider.GetSearchKeywordsFromSerializedObject(new SerializedObject(OpenfortSettings.Instance))
            };

            return provider;
        }
    }
}
#endif