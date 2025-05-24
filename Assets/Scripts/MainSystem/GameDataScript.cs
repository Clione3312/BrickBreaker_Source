using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class GameDataScript : MonoBehaviour
{
    #region Singleton
    private static GameDataScript instance = new GameDataScript();
    public static GameDataScript Instance => instance;
    #endregion 


    [SerializeField, Header("ブロック 種類")]
    public GameObject BlockRed;
    [SerializeField ]public GameObject BlockOrange;
    [SerializeField ]public GameObject BlockYellow;
    [SerializeField ]public GameObject BlockGreen;
    [SerializeField ]public GameObject BlockBlue;
    [SerializeField ]public GameObject BlockIbory;
    [SerializeField ]public GameObject BlockPurple;

    [SerializeField, Header("プレイヤー ステータス")]
    public int _PlayerMaxLife = 5;
    [SerializeField ]public int _PlayerLife = 3;

    [SerializeField ]public int AttackMaxLv = 5;
    [SerializeField ]public int _AttackLv = 1;
    
    [SerializeField ]public int SizeMaxLv = 5;
    [SerializeField ]public int _SizeLv = 1;
    
    [SerializeField ]public float _SpeedMaxLv = 5;
    [SerializeField ]public float _SpeedLv = 1;

    [SerializeField ]public int _TotlScore = 0;
    [SerializeField ]public int _CurrentScore = 0;

    [SerializeField ]public int _Combo = 0;

    private const int BLOCK_FILED_HEIGHT = 20;
    private const int BLOCK_FILED_WIDTH = 7;
    public int FILED_HEIGHT = BLOCK_FILED_HEIGHT;
    public int FILED_WIDTH = BLOCK_FILED_WIDTH;

    public float SET_POS_START_Y = 36.5f;
    public float SET_POS_START_X = -15.5f;

    public bool _GameStart = false;
    public bool _GameClear = false;
    public bool _GameOver = false;

    public List<Vector3> velocityData;

    public enum BlockCategory{
        None,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Ibory,
        Purple,
    }
    public BlockCategory[,] _FieldState = new BlockCategory[BLOCK_FILED_HEIGHT, BLOCK_FILED_WIDTH];

    [SerializeField] public AudioSource bgm;

    private void Start() {
        bgm = GetComponent<AudioSource>();
    }

    public void BGMStop() {
        bgm.Stop();
    }

    public void BGMPlay() {
        bgm.Play();
    }

    private void Awake(){
        checkInstance();
    }

    public void checkInstance(){
        if (instance == null) {
            instance = (GameDataScript)this;
            return;
        } else if (instance == this) {
            return;
        }
        Destroy(this);
    }
}