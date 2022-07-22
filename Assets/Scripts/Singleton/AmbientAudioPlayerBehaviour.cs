using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudioPlayerBehaviour : MonoBehaviour
{
    private static AmbientAudioPlayerBehaviour instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            Debug.Log($"Create AmbientAudioPlayerBehaviour instance {gameObject.GetInstanceID()}");
            instance = this;
            // keep instance even if we changed / loaded a new scene
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Debug.Log($"Destroy AmbientAudioPlayerBehaviour instance {gameObject.GetInstanceID()}");
            Destroy(gameObject);
        }
    }

    public void FadeNewMusic(AudioClip clip)
    {
        // TODO
    }
}
