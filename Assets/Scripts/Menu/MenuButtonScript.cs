using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class MenuButtonScript : MonoBehaviour
{
    [SerializeField, Header("フェード時間")]
    private float fadeTime;
    [SerializeField, Header("フェードパネル")]
    private Image fade;

    [SerializeField, Header("SE")]
    private AudioSource seSubmit;
    [SerializeField]private AudioSource seCancel;

    [SerializeField, Header("Canvas Group")]
    private CanvasGroup menuPanel;
    [SerializeField]private CanvasGroup optionPanel;

    [SerializeField, Header("MsgBox YesNo")]
    private GameObject msgBox;
    [SerializeField]private TextMeshProUGUI msgText;
    [SerializeField]private Button btnYes;
    [SerializeField]private Button btnNo;

    [SerializeField, Header("MsgBox OK")]
    private GameObject msgBox2;
    [SerializeField]private TextMeshProUGUI msgText2;
    [SerializeField]private Button btnOK;

    private string sceneName;
    private LoadSceneMode loadSceneMode;

    private void ChangeScene() {
        fade.gameObject.SetActive(true);
        DOTween.Sequence()
            .Append(fade.DOFade(1f, fadeTime))
            .AppendInterval(1f)
            .OnComplete(() => SceneManager.LoadScene(sceneName, loadSceneMode))
            .Play();
            
        Instantiate(seSubmit);
    }

    public void ClickStageSelectBtn(){
        sceneName = "StageSelect";
        loadSceneMode = LoadSceneMode.Additive;
        ChangeScene();
    }

    public void ClickOptionBtn(){
        optionPanel.gameObject.SetActive(true);
        Sequence sequence = DOTween.Sequence();

        sequence
            .Append(menuPanel.DOFade(0f, 1f))
            .AppendInterval(1f)
            .Append(optionPanel.DOFade(1f, 1f));

        Instantiate(seSubmit);
    }

    public void ClickQuitBtn(){
        Instantiate(seSubmit);
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void ClickCloseBtn() {
        Sequence sequence = DOTween.Sequence();
        sequence
            .Append(optionPanel.DOFade(0f, 1f))
            .AppendInterval(1f)
            .Append(menuPanel.DOFade(1f, 1f))
            .OnComplete(() => optionPanel.gameObject.SetActive(false));
        Instantiate(seCancel);
    }

    public void ClickDataDeleteBtn() {
        Sequence sequence = DOTween.Sequence();
        sequence
            .OnStart(() => {
                msgBox.SetActive(true);
                msgText.text = "今までの記録を初期化しますか？";    
            })
            .Append(msgBox.transform.DOScaleX(1f, 0.1f))
            .Join(msgBox.transform.DOScaleY(1f, 0.2f))
            .AppendInterval(0.5f)
            .Append(msgText.DOFade(1f, 0.5f))
            .Join(btnYes.GetComponent<Image>().DOFade(1f, 0.5f))
            .Join(btnNo.GetComponent<Image>().DOFade(1f, 0.5f))
            .Join(btnYes.transform.GetChild(0).GetComponent<TextMeshProUGUI>().DOFade(1f, 0.1f))
            .Join(btnNo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().DOFade(1f, 0.2f));
        
        Instantiate(seSubmit);
    }

    public void OnClickYesBtn(){
        CloseMsgBox();

        msgBox2.SetActive(true);

        Sequence sequence = DOTween.Sequence();
        sequence
            .OnStart(() => {
                msgText2.text = "初期化中…";    
            })
            .Append(msgBox2.GetComponent<Image>().DOFade(1f, 0.1f))
            .Append(msgText2.DOFade(1f, 0.1f))
            .Join(btnOK.GetComponent<Image>().DOFade(1f, 0f))
            .Join(btnOK.transform.GetChild(0).GetComponent<TextMeshProUGUI>().DOFade(1f, 0f))
            .OnComplete(() => defaultScoreData())
            .Play()
            
        
            .OnStart(() => {
                msgText2.text = "初期化完了しました";    
            })
            .Play();

        Instantiate(seSubmit);
    }

    public void OnClickNoBtn(){
        CloseMsgBox();
        Instantiate(seCancel);
    }

    private void CloseMsgBox() {
        Sequence sequence = DOTween.Sequence();
        sequence
            .Append(msgText.DOFade(0f, 0.5f))
            .Join(btnYes.GetComponent<Image>().DOFade(0f, 0.5f))
            .Join(btnNo.GetComponent<Image>().DOFade(0f, 0.5f))
            .Join(btnYes.transform.GetChild(0).GetComponent<Image>().DOFade(0f, 0.5f))
            .Join(btnNo.transform.GetChild(0).GetComponent<Image>().DOFade(0f, 0.5f))
            .AppendInterval(0.5f)
            .Append(msgBox.transform.DOScaleX(0f, 0.2f))
            .Join(msgBox.transform.DOScaleY(0f, 0.1f))
            .OnComplete(() => {msgBox.SetActive(false);});
    }

    public void OnClickOKBtn(){
        Sequence sequence = DOTween.Sequence();
        sequence
            .OnStart(() => {
                msgText2.text = "";    
            })
            .Append(msgText2.DOFade(0f, 0.1f))
            .Join(btnOK.GetComponent<Image>().DOFade(0f, 0f))
            .Join(btnOK.transform.GetChild(0).GetComponent<TextMeshProUGUI>().DOFade(0f, 0f))
            .OnComplete(() => msgBox2.SetActive(false))
            .Play();

        Instantiate(seSubmit);
    }

    private void defaultScoreData() {
        File.Delete(Application.dataPath + "\\jsonFile\\StageResultData.json");
        GameSaveSystem.Instance.Load();
    }
}
