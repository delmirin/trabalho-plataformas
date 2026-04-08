using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class BootLoaderEditor
{
    static BootLoaderEditor()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    static void OnPlayModeStateChanged(PlayModeStateChange change)
    {
        if (change == PlayModeStateChange.EnteredPlayMode)
        {
            // Store the current scene name
            string sceneName = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("CurrentScene", sceneName);
            PlayerPrefs.Save();
        }
    }
}
