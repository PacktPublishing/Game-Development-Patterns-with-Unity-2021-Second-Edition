using UnityEngine;
using UnityEditor;
using FPP.Scripts.Systems;

namespace FPP.Scripts.Tools
{
#if UNITY_EDITOR
    public class Sidekick : EditorWindow
    {
        [MenuItem("BladeRacer/Sidekick")]
        public static void ShowWindow()
        {
            GetWindow(typeof(Sidekick));
        }

        void OnGUI()
        {
            GUILayout.Label("Progression", EditorStyles.boldLabel);

            if (GUILayout.Button("Delete Save", GUILayout.MinWidth(80)))
            {
                SaveSystem saveSystem = new SaveSystem();
                saveSystem.DeleteSave();
            }
        }
    }
#endif
}