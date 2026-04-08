using UnityEngine;

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
        }
    }
}