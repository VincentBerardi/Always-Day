using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider effectsVolumeSlider;

    void Awake()
    {
        // Set audio slider defaults
        if (!PlayerPrefs.HasKey("MasterVolume"))
            masterVolumeSlider.value = 1f;
        else
            masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");

        if (!PlayerPrefs.HasKey("MusicVolume"))
            musicVolumeSlider.value = 0.5f;
        else
            musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        if (!PlayerPrefs.HasKey("EffectsVolume"))
            effectsVolumeSlider.value = 1f;
        else
            effectsVolumeSlider.value = PlayerPrefs.GetFloat("EffectsVolume");

        masterVolumeSlider.onValueChanged.AddListener(delegate { MasterVolumeChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { MusicVolumeChange(); });
        effectsVolumeSlider.onValueChanged.AddListener(delegate { EffectsVolumeChange(); });

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            //s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            //s.source.bypassEffects = s.bypassEffects;
        }
    }

    private void Update()
    {
        //setPitchEffects();
    }

    // Changes the pitch of the audio clip according to Time.timeScale, clamped from 0 to 1.  
    //private void setPitchEffects()
    //{
    //    foreach (Sound s in sounds)
    //        if (!s.source.bypassEffects)
    //            s.source.pitch = Mathf.Clamp(Time.timeScale, 0.0f, 1.0f);  
    //}

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s != null)
            s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s != null)
            s.source.Stop();
    }

    public void MasterVolumeChange()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);

        foreach (Sound s in sounds)
        {
            if (s.soundType == Sound.SoundType.Music)
                s.source.volume = masterVolumeSlider.value * musicVolumeSlider.value;

            if (s.soundType == Sound.SoundType.Effect)
                s.source.volume = masterVolumeSlider.value * effectsVolumeSlider.value;
        }
    }
    public void MusicVolumeChange()
    {
        PlayerPrefs.SetFloat("MusicVolume", masterVolumeSlider.value);

        foreach (Sound s in sounds)
        {
            if (s.soundType == Sound.SoundType.Music)
                s.source.volume = masterVolumeSlider.value * musicVolumeSlider.value;
        }
    }
    public void EffectsVolumeChange()
    {
        PlayerPrefs.SetFloat("EffectsVolume", masterVolumeSlider.value);

        foreach (Sound s in sounds)
        {
            if(s.soundType == Sound.SoundType.Effect)
                s.source.volume = masterVolumeSlider.value * effectsVolumeSlider.value;
        }
    }
}