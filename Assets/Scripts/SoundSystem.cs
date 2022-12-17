using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioBalance : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public string clipName;

    [Range(0, 1)]
    public float volume = 0.5f;




    public static AudioBalance Instance;

    [SerializeField] private AudioBalance[] sounds;

    private void Awake()
    {
        Instance = this;

        foreach (AudioBalance s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.loop = s.isLoop;
            s.source.volume = s.volume;

            if (s.playOnAwake)
                s.source.Play;
        }
    }

}
