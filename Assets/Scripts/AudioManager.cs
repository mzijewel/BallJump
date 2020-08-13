using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager i;

    [SerializeField] AudioClip clipCoinHit, clipBallHit, clipMusic;

    bool isMusic, isSound, isVibration;
    AudioSource source;

    private void Awake()
    {
        if (i != null)
            return;
        i = this;
        DontDestroyOnLoad(this);
        isMusic = PlayerPrefs.GetInt(Constants.MUSIC, 1) == 1;
        isSound = PlayerPrefs.GetInt(Constants.SOUND, 1) == 1;
        isVibration = PlayerPrefs.GetInt(Constants.VIBRATE, 1) == 1;

        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayMusic();
    }

    public void PlayBallHit()
    {
        if (isSound)
            source.PlayOneShot(clipBallHit);
    }
    public void PlayCoinHit()
    {
        if (isSound)
            source.PlayOneShot(clipCoinHit);
    }
    public void PlayMusic()
    {
        if (isMusic)
        {
            source.clip = clipMusic;
            source.Play();
        }

    }
    public void StopMusic()
    {
        source.Stop();
    }

    public bool SoundToggle()
    {
        isSound = !isSound;
       
        PlayerPrefs.SetInt(Constants.SOUND, isSound ? 1 : 0);
        return isSound;
    }
    public bool MusicToggle()
    {
        isMusic = !isMusic;
        if (!isMusic)
        {
            StopMusic();
        }
        else
        {
            PlayMusic();
        }
        PlayerPrefs.SetInt(Constants.MUSIC, isMusic ? 1 : 0);
        return isMusic;
    }
    public bool VibrateToggle()
    {
        isVibration = !isVibration;

        PlayerPrefs.SetInt(Constants.VIBRATE, isVibration ? 1 : 0);
        return isVibration;
    }

    public bool IsSound()
    {
        return isSound;
    }
    public bool IsMusic()
    {
        return isMusic;
    }
    public bool IsVibrate()
    {
        return isVibration;
    }
}
