using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using System.Diagnostics;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] BGM;
    public AudioClip[] SFX;

    [SerializeField] AudioSource BGM_Source;
    [SerializeField] AudioSource SFX_Source;

    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private AudioMixerGroup bgmMixer;
    [SerializeField] private AudioMixerGroup sfxMixer;

    [Header("UI Volume Control")]
    [SerializeField]
    private VisualTreeAsset VolumeMenu;
    private VisualElement VolumeStuff;

    private static float BGM_Volume; //= 0.5f;// to change background music volume
    private static float SFX_Volume; //= 0.5f;
    private static float master_volume; //= 1.0f;

    public void Start()
    {
        VolumeStuff = VolumeMenu.CloneTree();
        UnityEngine.UIElements.Slider MasterVol = VolumeStuff.Q<Slider>("MasterVolSlider");
        UnityEngine.UIElements.Slider BGMVol = VolumeStuff.Q<Slider>("BGMSlider");
        UnityEngine.UIElements.Slider SFXVol = VolumeStuff.Q<Slider>("SFXSlider");

        //BGM_volume.value = BGM_Volume;
        //SFX_volume.value = SFX_Volume;
        //master_volume.value = master_volume;

        MasterVol.RegisterValueChangedCallback(evt =>
        {
            UnityEngine.Debug.Log(evt.newValue);
        });

        master_volume = MasterVol.value;
        SFX_Volume = SFXVol.value;
        BGM_Volume = BGMVol.value;
        BGM_Source.volume = BGM_Volume * master_volume;
        SFX_Source.volume = SFX_Volume * master_volume;

        //MasterVol.onValueChanged.AddListener(delegate { ValueChangeCheckMaster(); });
        //BGMVol.onValueChanged.AddListener(delegate { ValueChangeCheckBGM(); });
        //SFXVol.onValueChanged.AddListener(delegate { ValueChangeCheckSFX(); });
    }

    public void convertToDB()
    {
        float masVol = master_volume;
        float masDB = Mathf.Max(-80, 20 * Mathf.Log10(masVol));
        PlayerPrefs.SetFloat("decibels", masDB);
        masterMixer.SetFloat("Volume", masDB);
    }

    public void ValueChangeCheckMaster()
    {
        //master_volume = Master_volume.value;
        BGM_Source.volume = BGM_Volume * master_volume;
        SFX_Source.volume = SFX_Volume * master_volume;

    }

    public void ValueChangeCheckBGM()
    {
        //BGM_Volume = BGM_volume.value;
        BGM_Source.volume = BGM_Volume * master_volume;
    }


    public void ValueChangeCheckSFX()
    {
       // SFX_Volume = SFX_volume.value;
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
