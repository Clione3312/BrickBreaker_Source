using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.InputSystem;

public class ResultSocreScript : MonoBehaviour
{
    DG.Tweening.Core.DOGetter<int> dispScoreGetter;
    DG.Tweening.Core.DOSetter<int> dispScoreSetter;

    [SerializeField, Header("時間計測")]
    private TimeCountScript timeCount;

    [SerializeField, Header("Game End Panel")]
    private CanvasGroup grResult;
    [SerializeField] private CanvasGroup grGameEnd;
    [SerializeField] private Button btnNextStage;
    [SerializeField] private float fadeTime;

    [SerializeField, Header("UI")]private CanvasGroup rsGroup;
    [SerializeField] private Image resultBg;
    [SerializeField] private TextMeshProUGUI resultTitle;
    [SerializeField] private Image scoreTitleBg;
    [SerializeField] private TextMeshProUGUI scoreTitleText;
    [SerializeField] private Image scoreValueBg;
    [SerializeField] private TextMeshProUGUI scoreValueText;
    [SerializeField] private Image lifeTitleBg;
    [SerializeField] private TextMeshProUGUI lifeTitleText;
    [SerializeField] private Image lifeValueBg;
    [SerializeField] private TextMeshProUGUI lifeValueText;
    [SerializeField] private Image timeTitleBg;
    [SerializeField] private TextMeshProUGUI timeTitleText;
    [SerializeField] private Image timeValueBg;
    [SerializeField] private TextMeshProUGUI timeValueText;
    [SerializeField] private Image splitLine;
    [SerializeField] private Image totalTitleBg;
    [SerializeField] private TextMeshProUGUI totalTitleText;
    [SerializeField] private Image totalValueBg;
    [SerializeField] private TextMeshProUGUI totalValueText;
    [SerializeField] private TextMeshProUGUI rankTitle;
    [SerializeField] private Image rankValueBg;
    [SerializeField] private CanvasGroup newRecord;

    [SerializeField, Header("Rank Image")]private Image rankS;
    [SerializeField]private Image rankA;
    [SerializeField]private Image rankB;
    [SerializeField]private Image rankC;
    [SerializeField]private Image rankD;

    [SerializeField, Header("スコア表示")]private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI life;
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI totalScore;
    [SerializeField] private TextMeshProUGUI rank;

    // [SerializeField, Header("SE Effect")]private AudioSource seDrumroll;
    // [SerializeField] private AudioSource seDrumend;
    // [SerializeField] private AudioSource seShowRank;
    // [SerializeField] private AudioSource seNewRec;

    [SerializeField, Header("SE Effect")]
    private AudioClip seDrumroll;
    [SerializeField] private AudioClip seDrumend;
    [SerializeField] private AudioClip seShowRank;
    [SerializeField] private AudioClip seNewRec;
    [SerializeField] private AudioClip seShowCategory;

    [SerializeField, Header("BGM")]
    private AudioSource bgmResult;

    private AudioSource audioSource = default;

    private int scorePoint;
    private int lifePoint;
    private int timePoint; 
    private int totalPoint; 
    private string getRank;

    private int prevScorePoint;
    private int prevLifePoint;
    private int prevTimePoint;
    private int prevTotalPoint;

    private bool isAnim;
    private bool bPush;

    private Sequence sequence;

    private const string CSV_FOLDER = "csv\\";
    private string refTimeFile = "TimeRecords";
    private string refRankFile = "ScoreRank";
    private string stageName;

    private bool boolNewRec;

    private void Start()
    {
        Instantiate(bgmResult);
        audioSource  = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        UpdateScoreText();
    }

    public void Animate() {
        Initialize();
        registResultData();

        if (!isAnim) CountUpAnim();
    }

    private void Initialize() {
        GameDataScript.Instance._GameClear = true;

        dispScoreGetter = GetCurrentDispScore;
        dispScoreSetter = SetCurrentDispScore;

        stageName = GameStageDataScript.Instance.stageNo.ToString("000");

        scorePoint = GameDataScript.Instance._CurrentScore;
        lifePoint = GameDataScript.Instance._PlayerLife * 5000;
        timePoint = CalcTimePoint();
        
        totalPoint = scorePoint + lifePoint + timePoint;
        getRank = CalcGetRank();
    }

    // データを記録する
    private void registResultData(){
        int stageNo = int.Parse(stageName);

        GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].stageName = stageName;
        if (totalPoint > GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.clearScore) {
            boolNewRec = true;
            GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.clearScore = totalPoint;
        }
        GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.isClear = true;
        GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.clearRank = getRank;

        int swapPoint = 0;
        int tgPoint = totalPoint;

        if (tgPoint >= GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.ranking1) {
            swapPoint = GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.ranking1;
            GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.ranking1 = tgPoint;
            tgPoint = swapPoint;
        }
        if (tgPoint >= GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.ranking2) {
            swapPoint = GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.ranking2;
            GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.ranking2 = tgPoint;
            tgPoint = swapPoint;
        }
        if (tgPoint >= GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.ranking3) {
            swapPoint = GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.ranking3;
            GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.ranking3 = tgPoint;
            tgPoint = swapPoint;
        }
        if (tgPoint >= GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.ranking4) {
            swapPoint = GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.ranking4;
            GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.ranking4 = tgPoint;
            tgPoint = swapPoint;
        }
        if (tgPoint >= GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.ranking5) {
            swapPoint = GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.ranking5;
            GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.ranking5 = tgPoint;
            tgPoint = swapPoint;
        }

        GameSaveSystem.Instance.Save();
    }


    private void UpdateScoreText(){
        score.SetText("{0:0}",prevScorePoint);
        life.SetText("{0:0}", prevLifePoint);
        time.SetText("{0:0}", prevTimePoint);
        totalScore.SetText("{0:0}", prevTotalPoint);
    }

    private int CalcTimePoint(){
        TextAsset csvFile  = Resources.Load(CSV_FOLDER + refTimeFile) as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        
        // CSVファイルから、ステージごとの時間情報を取得する
        int y = 0;
        List<String> _List = new List<string>();
        while(reader.Peek() != -1){
            string line = reader.ReadLine();
            _List = new List<string>();
            foreach (var item in line.Split(",")) _List.Add(item);

            if (_List[0] == stageName) break;
            y++;
        }
        reader.Close();

        // クリア時間と、抜き出した時間情報と比較する
        string editRecordTime = timeCount.timeString.Substring(0, timeCount.timeString.Length - 4);
        DateTime currentTime = DateTime.Parse(editRecordTime);
        int idx;
        for (idx = 1; idx < _List.Count; idx++)
        {
            DateTime comparisonTime = DateTime.Parse(_List[idx]);
            if (currentTime < comparisonTime) break;
        }

        int point = 0;
        switch (idx)
        {
            case 1: point = 10000; break;
            case 2: point = 8000; break;
            case 3: point = 5000; break;
            case 4: point = 3000; break;
            case 5: point = 1000; break;
        }

        return point;
    }

    private string CalcGetRank() {
        TextAsset csvFile  = Resources.Load(CSV_FOLDER + refRankFile) as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        
        // CSVファイルから、ステージごとの時間情報を取得する
        int y = 0;
        List<String> _List = new List<string>();
        while(reader.Peek() != -1){
            string line = reader.ReadLine();
            _List = new List<string>();
            foreach (var item in line.Split(",")) _List.Add(item);

            if (_List[0] == stageName) break;
            y++;
        }
        reader.Close();

        // クリア時間と、抜き出した時間情報と比較する
        int idx;
        for (idx = 1; idx < _List.Count; idx++)
        {
            if (totalPoint >= int.Parse(_List[idx])) break;
        }

        String str = "";
        switch (idx)
        {
            case 1: str = "S"; break;
            case 2: str = "A"; break;
            case 3: str = "B"; break;
            case 4: str = "C"; break;
            default: str = "D"; break;
        }
        
        return str;
    }


    private void CountUpAnim(){

        isAnim = true;

        // リザルト画面
        sequence = DOTween.Sequence()
            .Append(rsGroup.DOFade(1f, 1f))
            .AppendInterval(0.5f);
    
        // タイトル - 背景
        sequence
            .Append(resultBg.DOFade(1f, 0.5f))
            .Join(resultBg.rectTransform.DOLocalMoveX(600f, 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory));

        // タイトル - 文字
        sequence
            .Append(resultTitle.DOFade(1f, 0.5f))
            .Join(resultTitle.rectTransform.DOLocalMoveX(600f, 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory))
            .AppendInterval(0.5f);

        // スコアタイトル - 背景
        sequence
            .Append(scoreTitleBg.DOFade(1f, 0.5f))
            .Join(scoreTitleBg.rectTransform.DOLocalMove(new Vector3(0f,0f,0f), 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory));

        // スコアタイトル - 文字
        sequence
            .Append(scoreTitleText.DOFade(1f, 0.5f))
            .Join(scoreTitleText.rectTransform.DOLocalMove(new Vector3(0f,0f,0f), 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory))
            .AppendInterval(0.5f);

        // スコアバリュー - 背景
        sequence
            .Append(scoreValueBg.DOFade(1f, 0.5f))
            .Join(scoreValueBg.rectTransform.DOLocalMove(new Vector3(0f,0f,0f), 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory));
        
        // スコアバリュー - 文字
        sequence
            .Append(scoreValueText.DOFade(1f, 0.5f))
            .Join(scoreValueText.rectTransform.DOLocalMoveX(500f, 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory))
            .AppendInterval(0.5f);

        // ライフタイトル - 背景
        sequence
            .Append(lifeTitleBg.DOFade(1f, 0.5f))
            .Join(lifeTitleBg.rectTransform.DOLocalMove(new Vector3(0f,0f,0f), 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory));
        
        // ライフタイトル - 文字
        sequence
            .Append(lifeTitleText.DOFade(1f, 0.5f))
            .Join(lifeTitleText.rectTransform.DOLocalMove(new Vector3(0f,0f,0f), 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory))
            .AppendInterval(0.5f);

        // ライフバリュー - 背景
        sequence
            .Append(lifeValueBg.DOFade(1f, 0.5f))
            .Join(lifeValueBg.rectTransform.DOLocalMove(new Vector3(0f,0f,0f), 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory));
        
        // ライフバリュー - 文字
        sequence
            .Append(lifeValueText.DOFade(1f, 0.5f))
            .Join(lifeValueText.rectTransform.DOLocalMoveX(500f, 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory))
            .AppendInterval(0.5f);

        // タイムタイトル - 背景
        sequence
            .Append(timeTitleBg.DOFade(1f, 0.5f))
            .Join(timeTitleBg.rectTransform.DOLocalMove(new Vector3(0f,0f,0f), 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory));
        
        // タイムタイトル - 文字
        sequence
            .Append(timeTitleText.DOFade(1f, 0.5f))
            .Join(timeTitleText.rectTransform.DOLocalMove(new Vector3(0f,0f,0f), 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory))
            .AppendInterval(0.5f);

        // タイムバリュー - 背景
        sequence
            .Append(timeValueBg.DOFade(1f, 0.5f))
            .Join(timeValueBg.rectTransform.DOLocalMove(new Vector3(0f,0f,0f), 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory));
        
        // タイムバリュー - 文字
        sequence
            .Append(timeValueText.DOFade(1f, 0.5f))
            .Join(timeValueText.rectTransform.DOLocalMoveX(500f, 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory))
            .AppendInterval(0.5f);

        // 罫線
        sequence
            .Append(splitLine.rectTransform.DOLocalMoveX(-500f, 0.5f));

        // トータルタイトル - 背景
        sequence
            .Append(totalTitleBg.DOFade(1f, 0.5f))
            .Join(totalTitleBg.rectTransform.DOLocalMove(new Vector3(0f,0f,0f), 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory));
        
        // トータルタイトル - 文字
        sequence
            .Append(totalTitleText.DOFade(1f, 0.5f))
            .Join(totalTitleText.rectTransform.DOLocalMove(new Vector3(0f,0f,0f), 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory));

        // トータルバリュー - 背景
        sequence
            .Append(totalValueBg.DOFade(1f, 0.5f))
            .Join(totalValueBg.rectTransform.DOLocalMoveX(0f, 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory));
        
        // トータルバリュー - 文字
        sequence
            .Append(totalValueText.DOFade(1f, 2f))
            .Join(totalValueText.rectTransform.DOLocalMoveX(500f, 0.5f))
            .JoinCallback(() => audioSource.PlayOneShot(seShowCategory));

        // カウント - 取得スコア
        sequence
            .Append(DOTween.To(
                () => prevScorePoint,
                (num) => prevScorePoint = num,
                scorePoint,
                1.5f))
            .SetEase(Ease.Linear)
            .JoinCallback(() => audioSource.PlayOneShot(seDrumroll))
            .AppendInterval(0.5f)
            .JoinCallback(() => {
                if(audioSource.isPlaying) audioSource.Stop();
                audioSource.PlayOneShot(seDrumend);
            });

        // カウント - ライフボーナス
        sequence
            .Append(DOTween.To(
                () => prevLifePoint,
                (num) => prevLifePoint = num,
                lifePoint,
                1.5f))
            .SetEase(Ease.Linear)
            .JoinCallback(() => audioSource.PlayOneShot(seDrumroll))
            .AppendInterval(0.5f)
            .JoinCallback(() => {
                if(audioSource.isPlaying) audioSource.Stop();
                audioSource.PlayOneShot(seDrumend);
            });
        // カウント - タイムボーナス
        sequence
            .Append(DOTween.To(
                () => prevTimePoint,
                (num) => prevTimePoint = num,
                timePoint,
                1.5f))
            .SetEase(Ease.Linear)
            .JoinCallback(() => audioSource.PlayOneShot(seDrumroll))
            .AppendInterval(0.5f)
            .JoinCallback(() => {
                if(audioSource.isPlaying) audioSource.Stop();
                audioSource.PlayOneShot(seDrumend);
            });

        // カウント - 総合スコア
        sequence
            .Append(DOTween.To(
                () => prevTotalPoint,
                (num) => prevTotalPoint = num,
                totalPoint,
                1.5f))
            .SetEase(Ease.Linear)
            .JoinCallback(() => audioSource.PlayOneShot(seDrumroll))
            .AppendInterval(0.5f)
            .JoinCallback(() => {
                if(audioSource.isPlaying) audioSource.Stop();
                audioSource.PlayOneShot(seDrumend);
            })
            .AppendInterval(0.5f);

        // ランク - 背景
        sequence
            .Append(rankValueBg.DOFade(1f, 0.5f))
            .Join(rankValueBg.rectTransform.DOLocalMove(new Vector3(0f,0f,0f), 0.5f));
        
        // ランクタイトル - 文字
        sequence
            .Append(rankTitle.DOFade(1f, 2f))
            .Join(rankTitle.transform.DOShakePosition(duration: 0.6f, strength: 4))
            .AppendInterval(0.5f);

        // ランク 表示
        switch (getRank)
        {
            case "S":
                sequence
                    .Append(rankS.DOFade(1f, 0.1f))
                    .Join(rankS.transform.DOShakePosition(duration: 0.6f, strength: 4))
                    .JoinCallback(() => {
                        audioSource.PlayOneShot(seShowRank);
                    })  
                    .AppendInterval(0.5f);
                break;

            case "A":
                sequence
                    .Append(rankA.DOFade(1f, 0.1f))
                    .Join(rankA.transform.DOShakePosition(duration: 0.6f, strength: 4))
                    .JoinCallback(() => {
                        audioSource.PlayOneShot(seShowRank);
                    })  
                    .AppendInterval(0.5f);
                break;

            case "B":
                sequence
                    .Append(rankB.DOFade(1f, 0.1f))
                    .Join(rankB.transform.DOShakePosition(duration: 0.6f, strength: 4))
                    .JoinCallback(() => {
                        audioSource.PlayOneShot(seShowRank);
                    })  
                    .AppendInterval(0.5f);
                break;

            case "C":
                sequence
                    .Append(rankC.DOFade(1f, 0.1f))
                    .Join(rankC.transform.DOShakePosition(duration: 0.6f, strength: 4))
                    .JoinCallback(() => {
                        audioSource.PlayOneShot(seShowRank);
                    })  
                    .AppendInterval(0.5f);
                break;

            default:
                sequence
                    .Append(rankD.DOFade(1f, 0.1f))
                    .Join(rankD.transform.DOShakePosition(duration: 0.6f, strength: 4))
                    .JoinCallback(() => {
                        audioSource.PlayOneShot(seShowRank);
                    })  
                    .AppendInterval(0.5f);
                break;

        }

        if (boolNewRec) {
                sequence
                    .Append(newRecord.transform.DOLocalMoveX(1000f, 0.2f))
                    .AppendCallback(() => {
                        audioSource.PlayOneShot(seNewRec);
                    })  
                    .AppendInterval(0.5f);
        }
    }

    private int GetCurrentDispScore() => scorePoint;

    private void SetCurrentDispScore(int val){
        scorePoint = val;
    } 

    public void OnAnyKeyInput(InputAction.CallbackContext context){
        if (!context.performed && !bPush && grResult.gameObject.activeSelf){
            btnNextStage.gameObject.SetActive(GameStageDataScript.Instance.stageNo < GameStageDataScript.Instance.stageCount && GameDataScript.Instance._GameClear);

            bPush = true;
            grGameEnd.gameObject.SetActive(true);
            sequence = DOTween.Sequence()
                .Append(grGameEnd.DOFade(1f, fadeTime));
        }
    }
}
