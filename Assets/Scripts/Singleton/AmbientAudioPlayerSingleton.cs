using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudioPlayerSingleton
{
    private static AmbientAudioPlayerSingleton instance = null;
    public static AmbientAudioPlayerSingleton GetInstance()
    {
        if (instance == null)
        {
            // only ONE instance
            instance = new AmbientAudioPlayerSingleton();
        }
        return instance;
    }

    private AmbientAudioPlayerSingleton()
    {
        // don't allow create any instance via new operator OUTSIDE this class
        // except using INTERNAL in this class
    }

    public void FadeNewMusic(AudioClip clip)
    {
        // TODO
    }
}
