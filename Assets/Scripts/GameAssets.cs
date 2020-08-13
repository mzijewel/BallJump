using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets i;

    public Transform pfPlatform;

    public Sprite sprSound, sprMusic, sprVibrate, sprSoundDisable, sprMusicDisable, sprVibrateDisable;

    private void Awake()
    {
        if (i != null)
            return;
        i = this;
        DontDestroyOnLoad(this);
    }
}
