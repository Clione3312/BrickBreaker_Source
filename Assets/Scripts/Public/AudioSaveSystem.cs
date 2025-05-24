using System;
using System.IO;
using AudioConfigFile;
using Unity.VisualScripting;
using UnityEngine;

public class AudioSaveSystem
{
    #region Singleton
    private static AudioSaveSystem instance = new AudioSaveSystem();
    public static AudioSaveSystem Instance => instance;
    #endregion

    private AudioSaveSystem() {Load();}

    public string Path => Application.dataPath + "\\AudioData.json";
    
    public AudioConfigData AudioConfigData{get; private set;}

    public void Save(){
        string jsonData = JsonUtility.ToJson(AudioConfigData);
        StreamWriter writer = new StreamWriter(Path, false);
        writer.WriteLine(jsonData);
        writer.Flush();
        writer.Close();
    }

    public void Load(){
        if (!File.Exists(Path)){
            AudioConfigData = new AudioConfigData();
            Save();
        }

        StreamReader reader = new StreamReader(Path);
        string jsonData = reader.ReadToEnd();
        AudioConfigData = JsonUtility.FromJson<AudioConfigData>(jsonData);
        reader.Close();
    }
}
