using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;

    public GameObject backButton;

    public SettingsData settingsData;

    public GameObject soundsSlider;

    public GameObject musicSlider;

    public GameObject fullscreenCheckbox;

    public GameObject buttonToSelectAfterQuitting;


    AudioManager sounds;

    Resolution[] resolutions;

    void Start()
    {

        sounds = FindObjectOfType<AudioManager>();

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
        LoadSettings();
        resolutionDropdown.RefreshShownValue();

    }

    public void SaveSettings()
    {
        SaveSystem.SaveSettings(settingsData.soundVolume, settingsData.musicVolume, settingsData.isFullScreen, settingsData.resolutionIndex);
    }

    public void LoadSettings()
    {
        settingsData = SaveSystem.LoadSettings();
        if (settingsData != null)
        {
            SetSoundsVolume(settingsData.soundVolume);
            soundsSlider.GetComponent<Slider>().value = settingsData.soundVolume;
            SetMusicVolume(settingsData.musicVolume);
            musicSlider.GetComponent<Slider>().value = settingsData.musicVolume;
            SetResolution(settingsData.resolutionIndex);
            resolutionDropdown.value = settingsData.resolutionIndex;
            setFullScreen(settingsData.isFullScreen);
            fullscreenCheckbox.GetComponent<Toggle>().isOn = settingsData.isFullScreen;
        } else
        {
            settingsData = new SettingsData(0, 0, false, 0);
            Debug.Log("Here");
        }
        
    }

    public void SetResolution(int resolutionIndex)
    {
        if (resolutions != null) 
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            settingsData.resolutionIndex = resolutionIndex;
        }
        
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
        settingsData.soundVolume = volume;
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
        settingsData.musicVolume = volume;
    }

    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen= isFullScreen;
        settingsData.isFullScreen= isFullScreen;
    }

    public void closeOptions()
    {
        sounds.Play("MenuCancel");
        Selector backButtonSelector = backButton.GetComponent<Selector>();
        backButtonSelector.OnPointerExit(null);

        if (buttonToSelectAfterQuitting != null)
        {
            EventSystem.current.SetSelectedGameObject(buttonToSelectAfterQuitting);
        }

        //SaveSystem.SaveSettings();
    }
}
