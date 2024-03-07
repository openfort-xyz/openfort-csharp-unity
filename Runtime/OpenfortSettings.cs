using System;
using System.IO;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Openfort
{
    public class OpenfortSettings : ScriptableObject
    {
        [Tooltip("Published Key of your game https://www.openfort.xyz/docs/guides/platform/keys")]
        public string PublishedKey;

        [Tooltip("Log Level")]
        public LogLevel LogLevel;

        #region static
        private static OpenfortSettings _instance;

        public static void LoadSettings()
        {
            if (!_instance)
            {
                _instance = FindOrCreateInstance();
                Config.LogLevel = _instance.LogLevel;
                Config.PublishedKey = _instance.PublishedKey;
            }
        }

        public static void ClearInstance()
        {
            _instance = null;
        }

        public static OpenfortSettings Instance
        {
            get
            {
                LoadSettings();
                return _instance;
            }
        }

        private static OpenfortSettings FindOrCreateInstance()
        {
            OpenfortSettings instance = null;
            instance = instance ? null : Resources.Load<OpenfortSettings>("Openfort");
            instance = instance ? instance : Resources.LoadAll<OpenfortSettings>(string.Empty).FirstOrDefault();
            instance = instance ? instance : CreateAndSave<OpenfortSettings>();
            if (instance == null) throw new Exception("Could not find or create settings for Openfort");
            return instance;
        }

        private static T CreateAndSave<T>() where T : ScriptableObject
        {
            T instance = CreateInstance<T>();
#if UNITY_EDITOR
			//Saving during Awake() will crash Unity, delay saving until next editor frame
			if (EditorApplication.isPlayingOrWillChangePlaymode)
			{
				EditorApplication.delayCall += () => SaveAsset(instance);
			}
			else
			{
				SaveAsset(instance);
			}
#endif
            return instance;
        }

#if UNITY_EDITOR
		private static void SaveAsset<T>(T obj) where T : ScriptableObject
		{

			string dirName = "Assets/Resources";
			if (!Directory.Exists(dirName))
			{
				Directory.CreateDirectory(dirName);
			}
			AssetDatabase.CreateAsset(obj, "Assets/Resources/Openfort.asset");
			AssetDatabase.SaveAssets();
		}
#endif
        #endregion
    }
}
