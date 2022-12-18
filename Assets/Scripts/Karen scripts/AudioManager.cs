using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] BGM;
    public AudioClip[] SFX;

    [SerializeField] AudioSource BGM_Source;
    [SerializeField] AudioSource SFX_Source;

    public Slider Master_volume;
    public Slider BGM_volume;
    public Slider SFX_volume;

    private static float BGM_Volume = 0.5f;// to change background music volume
    private static float SFX_Volume = 0.5f;
    private static float master_volume = 1.0f;

    public void Start()
    {
        Master_volume.onValueChanged.AddListener (delegate {ValueChangeCheckMaster ();});
        BGM_volume.onValueChanged.AddListener (delegate {ValueChangeCheckBGM ();});
        SFX_volume.onValueChanged.AddListener (delegate {ValueChangeCheckSFX ();});
        BGM_volume.value = BGM_Volume;
        SFX_volume.value = SFX_Volume;
        Master_volume.value = master_volume;
        BGM_Source.volume = BGM_Volume * master_volume;
        SFX_Source.volume = SFX_Volume * master_volume;
    }

    public void ValueChangeCheckMaster()
    {
        master_volume = Master_volume.value;
        BGM_Source.volume = BGM_Volume * master_volume;
        SFX_Source.volume = SFX_Volume * master_volume;
    }

    public void ValueChangeCheckBGM()
    {
        BGM_Volume = BGM_volume.value;
        BGM_Source.volume = BGM_Volume * master_volume;        
    }


    public void ValueChangeCheckSFX()
    {
        SFX_Volume = SFX_volume.value;
        SFX_Source.volume = SFX_Volume * master_volume;
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

    public void muteAll()
    {
        BGM_Source.volume = 0;
        SFX_Source.volume = 0; 
    }

    public void unmuteAll()
    {
        BGM_Source.volume = BGM_Volume;
        SFX_Source.volume = SFX_Volume;
    }

    public void stopBGM()
    {
        BGM_Source.Stop();
    }

}
