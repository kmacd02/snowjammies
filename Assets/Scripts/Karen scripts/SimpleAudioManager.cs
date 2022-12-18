using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class SimpleAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BGM_Source;
    [SerializeField] AudioSource SFX_Source;

    public AudioClip[] BGM;
    public AudioClip[] SFX;

    private float bgm_volume = 0.5f;
    private float sfx_volume = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        bgm_volume = AudioManager.BGM_Volume * AudioManager.master_volume;
        BGM_Source.volume = bgm_volume;
        sfx_volume = AudioManager.SFX_Volume * AudioManager.master_volume;
        SFX_Source.volume = sfx_volume;
    }


    public void PlayBGMWithLoop(int n)
    {
        if (n < 0)
        {
            BGM_Source.Stop();
            return;
        }
        BGM_Source.clip = BGM[n];
        BGM_Source.Play();
        BGM_Source.loop = true;
    }

    public void PlayBGMWithoutLoop(int n)
    {
        if (n < 0)
        {
            BGM_Source.Stop();
            return;
        }
        BGM_Source.clip = BGM[n];
        BGM_Source.Play();
        BGM_Source.loop = false;
    }

    public void PlaySFX(int n)
    {
        SFX_Source.clip = SFX[n];
        SFX_Source.Play();
    }

}
