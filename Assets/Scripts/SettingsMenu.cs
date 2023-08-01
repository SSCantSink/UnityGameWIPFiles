using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        // find the list of all the resolutions
        resolutions = Screen.resolutions;

        // clear the list of resolutions;
        resolutionDropdown.ClearOptions();


        int currentResolutionIndex = 0;
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // finally add our list of options.
        resolutionDropdown.AddOptions(options);

        // make sure that the current resolution is selected
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetSoundsVolume(float volume)
    {
        if (volume <= -19.9f)
        {
            audioMixer.SetFloat("SoundEffectsVolume", -80f);
        }
        else
        {
            audioMixer.SetFloat("SoundEffectsVolume", volume);
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (volume <= -19.9f)
        {
            audioMixer.SetFloat("MusicVolume", -80f);
        }
        else 
        {
            audioMixer.SetFloat("MusicVolume", volume);
        }
    }

    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen= isFullScreen;
    }
}
