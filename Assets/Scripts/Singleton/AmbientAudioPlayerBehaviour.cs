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
            instance = this;
            // keep instance even if we changed / loaded a new scene
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void FadeNewMusic(AudioClip clip)
    {
        // TODO
    }
}