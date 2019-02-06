using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance;

    AudioSource audioSource;

    public AudioClip DeathClip;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}
