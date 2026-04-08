using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace scripts.cs
{
    public class AudioPlayer : MonoBehaviour
    {
        public AudioCollection myAudioCollection;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            DontDestroyOnLoad(gameObject);
            if (myAudioCollection != null && myAudioCollection.AudioClipCollection.Count > 0)
            {
                AudioManager.Instance.PlaySound(myAudioCollection.AudioClipCollection[0]);
            }
            // Load the open scene additively
            string sceneToLoad = PlayerPrefs.GetString("CurrentScene", "SampleScene");
            if (sceneToLoad == "boot")
            {
                sceneToLoad = "SampleScene";
            }
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
            // Unload the boot scene
            StartCoroutine(UnloadBoot());
        }

        private IEnumerator UnloadBoot()
        {
            yield return new WaitForSeconds(0.1f); // Wait a bit for the scene to load
            SceneManager.UnloadSceneAsync("boot");
        }
    }
}