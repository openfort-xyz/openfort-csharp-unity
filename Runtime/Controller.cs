using UnityEngine;

namespace Openfort
{
    internal class Controller : MonoBehaviour
    {
        #region Singleton

        private static Controller _instance;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializeBeforeSceneLoad()
        {
            OpenfortSettings.ClearInstance();
            OpenfortSettings.LoadSettings();
            Initialize();
        }

        internal static void Initialize()
        {
            GetInstance();
        }

        internal static Controller GetInstance()
        {
            if (_instance == null)
            {
                GameObject g = new GameObject("Openfort");
                _instance = g.AddComponent<Controller>();
                DontDestroyOnLoad(g);
            }
            return _instance;
        }

        #endregion
    }
}