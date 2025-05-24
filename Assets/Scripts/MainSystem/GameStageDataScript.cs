using UnityEngine;

public class GameStageDataScript : MonoBehaviour
{
    #region Singleton
    private static GameStageDataScript instance = new GameStageDataScript();
    public static GameStageDataScript Instance => instance;
    #endregion 

    [SerializeField, Header("Stage No")]
    public int stageNo;
    [SerializeField]public int stageCount;
}
