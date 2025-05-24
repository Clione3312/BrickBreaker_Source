using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class GameSystemScript : MonoBehaviour
{
    [SerializeField, Header("ゲーム データ")]
    private GameDataScript GameData;

    [SerializeField, Header("ステージ 読み込み")]
    private string _FolderPath = "csv\\";
    private string stageName;

    [SerializeField, Header("フェード")]
    private Image fade;

    [SerializeField, Header("Cut In")]
    private GameObject panelCutIn;
    [SerializeField] private CanvasGroup cgText;
    [SerializeField] private TextMeshProUGUI textCutIn;

    [SerializeField, Header("Result Panel")]
    private GameObject result;
    [SerializeField, Header("Game Over Panel")]
    private GameObject gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stageName = GameStageDataScript.Instance.stageNo.ToString("000");

        DOTween.Sequence()
            .Append(fade.DOFade(0f, 3f))
            .AppendInterval(3.0f)
            .OnComplete(() => fade.gameObject.SetActive(false));

        DOTween.Sequence()
            .OnStart(() => panelCutIn.SetActive(true))
            .Append(panelCutIn.transform.DOMove(new Vector3(960f,540f,0f), 0.5f))
            .Join(panelCutIn.transform.DORotate(new Vector3(0f,0f,0f), 0.5f))
            .Join(panelCutIn.GetComponent<CanvasGroup>().DOFade(1f, 0.5f))
            .AppendCallback(() => {
                textCutIn.text = "STAGE " + stageName;
                cgText.alpha = 1f;
            })
            .AppendInterval(1f)
            .AppendCallback(() => {
                cgText.alpha = 0f;
            })
            .Append(panelCutIn.transform.DOMove(new Vector3(0f,540f,0f), 0.5f))
            .Join(panelCutIn.transform.DORotate(new Vector3(-90f,0f,0f), 0.5f))
            .Join(panelCutIn.GetComponent<CanvasGroup>().DOFade(0f, 0.5f))
            .OnComplete(() => {
                panelCutIn.transform.position = new Vector3(960f,540f,0f);
                panelCutIn.SetActive(false);
            })
            .Play();

        readStageCSV();
        InitializeField();
    }


    private void InitializeField(){
        float _BlockPosX = 0;
        float _BlockPosY = 0;
        float _BlockWidth = 0;
        float _BlockHeight = 0;
        var _block = gameObject;

        for (int y = 0; y < GameData.FILED_HEIGHT; y++)
        {
            for (int x = 0; x < GameData.FILED_WIDTH; x++)
            {

                switch ((GameDataScript.BlockCategory)GameData._FieldState[y,x])
                {
                    case GameDataScript.BlockCategory.None: 
                        break;

                    case GameDataScript.BlockCategory.Red: 
                        _BlockPosX = GameData.BlockRed.transform.localScale.x;
                        _BlockPosY = GameData.BlockRed.transform.localScale.y;
                        _BlockWidth = GameData.BlockRed.GetComponent<Renderer>().bounds.size.x;
                        _BlockHeight = GameData.BlockRed.GetComponent<Renderer>().bounds.size.y;

                        _block = Instantiate(GameData.BlockRed,new Vector3(GameData.SET_POS_START_X + x * _BlockPosX * _BlockWidth, GameData.SET_POS_START_Y - y * _BlockPosY * _BlockHeight, 0f),GameData.BlockRed.transform.localRotation);

                        break;


                    case GameDataScript.BlockCategory.Orange: 
                        _BlockPosX = GameData.BlockOrange.transform.localScale.x;
                        _BlockPosY = GameData.BlockOrange.transform.localScale.y;
                        _BlockWidth = GameData.BlockOrange.GetComponent<Renderer>().bounds.size.x;
                        _BlockHeight = GameData.BlockOrange.GetComponent<Renderer>().bounds.size.y;

                        _block = Instantiate(GameData.BlockOrange,new Vector3(GameData.SET_POS_START_X + x * _BlockPosX * _BlockWidth, GameData.SET_POS_START_Y - y * _BlockPosY * _BlockHeight, 0f),GameData.BlockOrange.transform.localRotation);

                        break;

                    case GameDataScript.BlockCategory.Yellow: 
                        _BlockPosX = GameData.BlockYellow.transform.localScale.x;
                        _BlockPosY = GameData.BlockYellow.transform.localScale.y;
                        _BlockWidth = GameData.BlockYellow.GetComponent<Renderer>().bounds.size.x;
                        _BlockHeight = GameData.BlockYellow.GetComponent<Renderer>().bounds.size.y;

                        _block = Instantiate(GameData.BlockYellow,new Vector3(GameData.SET_POS_START_X + x * _BlockPosX * _BlockWidth, GameData.SET_POS_START_Y - y * _BlockPosY * _BlockHeight, 0f),GameData.BlockYellow.transform.localRotation);

                        break;


                    case GameDataScript.BlockCategory.Green: 
                        _BlockPosX = GameData.BlockGreen.transform.localScale.x;
                        _BlockPosY = GameData.BlockGreen.transform.localScale.y;
                        _BlockWidth = GameData.BlockGreen.GetComponent<Renderer>().bounds.size.x;
                        _BlockHeight = GameData.BlockGreen.GetComponent<Renderer>().bounds.size.y;

                        _block = Instantiate(GameData.BlockGreen,new Vector3(GameData.SET_POS_START_X + x * _BlockPosX * _BlockWidth, GameData.SET_POS_START_Y - y * _BlockPosY * _BlockHeight, 0f),GameData.BlockGreen.transform.localRotation);

                        break;

                    case GameDataScript.BlockCategory.Blue: 
                        _BlockPosX = GameData.BlockBlue.transform.localScale.x;
                        _BlockPosY = GameData.BlockBlue.transform.localScale.y;
                        _BlockWidth = GameData.BlockBlue.GetComponent<Renderer>().bounds.size.x;
                        _BlockHeight = GameData.BlockBlue.GetComponent<Renderer>().bounds.size.y;

                        _block = Instantiate(GameData.BlockBlue,new Vector3(GameData.SET_POS_START_X + x * _BlockPosX * _BlockWidth, GameData.SET_POS_START_Y - y * _BlockPosY * _BlockHeight, 0f),GameData.BlockBlue.transform.localRotation);

                        break;

                    case GameDataScript.BlockCategory.Ibory: 
                        _BlockPosX = GameData.BlockIbory.transform.localScale.x;
                        _BlockPosY = GameData.BlockIbory.transform.localScale.y;
                        _BlockWidth = GameData.BlockIbory.GetComponent<Renderer>().bounds.size.x;
                        _BlockHeight = GameData.BlockIbory.GetComponent<Renderer>().bounds.size.y;

                        _block = Instantiate(GameData.BlockIbory,new Vector3(GameData.SET_POS_START_X + x * _BlockPosX * _BlockWidth, GameData.SET_POS_START_Y - y * _BlockPosY * _BlockHeight, 0f),GameData.BlockIbory.transform.localRotation);

                        break;


                    case GameDataScript.BlockCategory.Purple: 
                        _BlockPosX = GameData.BlockPurple.transform.localScale.x;
                        _BlockPosY = GameData.BlockPurple.transform.localScale.y;
                        _BlockWidth = GameData.BlockPurple.GetComponent<Renderer>().bounds.size.x;
                        _BlockHeight = GameData.BlockPurple.GetComponent<Renderer>().bounds.size.y;

                        _block = Instantiate(GameData.BlockPurple,new Vector3(GameData.SET_POS_START_X + x * _BlockPosX * _BlockWidth, GameData.SET_POS_START_Y - y * _BlockPosY * _BlockHeight, 0f),GameData.BlockPurple.transform.localRotation);

                        break;

                }
            }
        }

        Destroy(GameData.BlockRed);
        Destroy(GameData.BlockOrange);
        Destroy(GameData.BlockYellow);
        Destroy(GameData.BlockGreen);
        Destroy(GameData.BlockBlue);
        Destroy(GameData.BlockIbory);
        Destroy(GameData.BlockPurple);

    }

    private void readStageCSV() {
        TextAsset csvFile  = Resources.Load(_FolderPath + stageName) as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        int y = 0;

        while(reader.Peek() != -1){
            string line = reader.ReadLine();
            var _List = line.Split(",");

            for (int x = 0; x < GameData.FILED_WIDTH; x++)
            {
                GameData._FieldState[y,x] = (GameDataScript.BlockCategory)int.Parse(_List[x]);
            }
            y++;
        }

        reader.Close();
    }

}
