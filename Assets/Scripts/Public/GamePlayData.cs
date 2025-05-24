using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public StageData[] stageDatas = new StageData[1];
}

[System.Serializable]
public class StageData
{
    public string stageName = (0).ToString("000");
    public ResultData resultData = new ResultData();   
}

[System.Serializable]
public class ResultData
{
    public int clearScore = 0;
    public bool isClear = false;
    public string clearRank = "";
    public int ranking1 = 0;
    public int ranking2 = 0;
    public int ranking3 = 0;
    public int ranking4 = 0;
    public int ranking5 = 0;
}
