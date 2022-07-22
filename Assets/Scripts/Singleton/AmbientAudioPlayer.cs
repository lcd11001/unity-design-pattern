using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudioPlayer
{
    private static AmbientAudioPlayer instance = null;
    public static AmbientAudioPlayer GetInstance()
    {
        if (instance == null)
        {
            // only ONE instance
            instance = new AmbientAudioPlayer();
        }
        return instance;
    }

    private AmbientAudioPlayer()
    {
        // don't allow create any instance via new operator OUTSIDE this class
        // except using INTERNAL in this class
    }

    public void FadeNewMusic(AudioClip clip)
    {
        // TODO
    }
}
