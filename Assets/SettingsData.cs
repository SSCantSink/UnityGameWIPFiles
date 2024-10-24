using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData
{
    public float soundVolume;
    public float musicVolume;
    public bool isFullScreen;
    public int resolutionIndex;

    public SettingsData(float soundVolume, float musicVolume, bool isFullScreen, int resolutionIndex)
    {
        this.soundVolume = soundVolume;
        this.musicVolume = musicVolume;
        this.isFullScreen = isFullScreen;
        this.resolutionIndex = resolutionIndex;
    }
}
