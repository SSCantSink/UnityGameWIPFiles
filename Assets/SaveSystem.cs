using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveSettings(float soundVolume, float musicVolume, bool isFullScreen, int resolutionIndex)
    {
        BinaryFormatter formatter= new BinaryFormatter();
        string path = Application.persistentDataPath + "/settings.gem";
        FileStream stream = new FileStream(path, FileMode.Create);

        SettingsData data = new SettingsData(soundVolume, musicVolume, isFullScreen, resolutionIndex);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SettingsData LoadSettings()
    {
        string path = Application.persistentDataPath + "/settings.gem";
        if (File.Exists(path))
        {
            BinaryFormatter formatter= new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SettingsData data = formatter.Deserialize(stream) as SettingsData;
            stream.Close();

            return data;
        }
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
