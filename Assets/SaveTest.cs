using System;
using System.Linq;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {

            GameSaveSystem.Instance.GameData.stageDatas[0] = new StageData();

            GameSaveSystem.Instance.GameData.stageDatas[0].stageName = "001";
            GameSaveSystem.Instance.GameData.stageDatas[0].resultData.clearScore = 25100;
            GameSaveSystem.Instance.GameData.stageDatas[0].resultData.isClear = true;
            GameSaveSystem.Instance.GameData.stageDatas[0].resultData.clearRank = "D";
            GameSaveSystem.Instance.GameData.stageDatas[0].resultData.ranking1 = 60000;
            GameSaveSystem.Instance.GameData.stageDatas[0].resultData.ranking2 = 50000;
            GameSaveSystem.Instance.GameData.stageDatas[0].resultData.ranking3 = 40000;
            GameSaveSystem.Instance.GameData.stageDatas[0].resultData.ranking4 = 30000;
            GameSaveSystem.Instance.GameData.stageDatas[0].resultData.ranking5 = 20000;


            Array.Resize(ref GameSaveSystem.Instance.GameData.stageDatas, 2);
            GameSaveSystem.Instance.GameData.stageDatas[1] = new StageData();

            GameSaveSystem.Instance.GameData.stageDatas[1].stageName = "002";
            GameSaveSystem.Instance.GameData.stageDatas[1].resultData.clearScore = 25100;
            GameSaveSystem.Instance.GameData.stageDatas[1].resultData.isClear = true;
            GameSaveSystem.Instance.GameData.stageDatas[1].resultData.clearRank = "D";
            GameSaveSystem.Instance.GameData.stageDatas[1].resultData.ranking1 = 60000;
            GameSaveSystem.Instance.GameData.stageDatas[1].resultData.ranking2 = 50000;
            GameSaveSystem.Instance.GameData.stageDatas[1].resultData.ranking3 = 40000;
            GameSaveSystem.Instance.GameData.stageDatas[1].resultData.ranking4 = 30000;
            GameSaveSystem.Instance.GameData.stageDatas[1].resultData.ranking5 = 20000;


            GameSaveSystem.Instance.Save();
        }

        if (Input.GetKeyDown(KeyCode.L)) {
            GameSaveSystem.Instance.Load();

            Debug.Log(GameSaveSystem.Instance.GameData.stageDatas[0].stageName);
        }

        if (Input.GetKeyDown(KeyCode.U)) {
            GameSaveSystem.Instance.Load();

            GameSaveSystem.Instance.GameData.stageDatas[0].resultData.clearScore = 60000;
            GameSaveSystem.Instance.GameData.stageDatas[0].resultData.clearRank = "S";

            GameSaveSystem.Instance.Save();
        }
    }
}
