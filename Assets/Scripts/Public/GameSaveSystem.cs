using System.IO;
using UnityEngine;

public class GameSaveSystem
{
    #region Singleton
    private static GameSaveSystem instance = new GameSaveSystem();
    public static GameSaveSystem Instance => instance;
    #endregion

    private GameSaveSystem() {Load();}

    public string Path => Application.dataPath + "\\StageResultData.json";

    public GameData GameData { get; private set; }

    public void Save(){
        string jsonData = JsonUtility.ToJson(GameData);
        StreamWriter writer = new StreamWriter(Path, false);
        writer.WriteLine(jsonData);
        writer.Flush();
        writer.Close();
    }

    public void Load(){
        if (!File.Exists(Path)) {
            GameData = new GameData();
            GameData.stageDatas = new StageData[1000];
            for(int i = 0; i < 1000; i++){
                GameData.stageDatas[i] = new StageData();
                
            }
            // GameData = new GameData();
            Save(); 
            return;
        }

        StreamReader reader = new StreamReader(Path);
        string jsonData = reader.ReadToEnd();
        GameData = JsonUtility.FromJson<GameData>(jsonData);
        reader.Close();
    }
}
