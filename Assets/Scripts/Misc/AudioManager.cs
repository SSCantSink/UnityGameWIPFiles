using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("References")]
    public Sound[] sounds;
    public AudioMixerGroup soundEffectsAudioMixerGroup;
    public AudioMixerGroup musicAudioMixerGroup;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            // Assign the audio mixer group to the Audio Source
            s.source.outputAudioMixerGroup = soundEffectsAudioMixerGroup;
            if (s.name == "Theme" || s.name == "StartMenuTheme")
            {
                s.source.outputAudioMixerGroup = musicAudioMixerGroup;
            }
        }
    }

    void Start()
    {
        Play("Theme");
        Play("StartMenuTheme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }
}
