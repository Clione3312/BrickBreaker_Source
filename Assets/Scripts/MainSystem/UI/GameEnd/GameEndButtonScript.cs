using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class GameEndButtonScript : MonoBehaviour
{
    [SerializeField, Header("フェード時間")]
    private float fadeTime;
    [SerializeField, Header("フェードパネル")]
    private Image image;

    [SerializeField, Header("Se Effect")]
    private AudioSource seSubmit;

    private string sceneName;

    private void ChangeScene() {
        Instantiate(seSubmit);
        image.gameObject.SetActive(true);
        DOTween.Sequence()
            .Append(image.DOFade(1f, fadeTime))
            .AppendInterval(1f)
            .OnComplete(() => {
                SceneManager.LoadScene(sceneName);
            });
        
    }

    public void ClickNextStageBtn(){
        GameStageDataScript.Instance.stageNo++;
        sceneName = SceneManager.GetActiveScene().name;
        ChangeScene();
    }

    public void ClickReplayBtn(){
        sceneName = SceneManager.GetActiveScene().name;
        ChangeScene();
    }

    public void ClickStageSelectBtn(){
        sceneName = "StageSelect";
        ChangeScene();
    }

    public void ClickMenuBtn(){
        sceneName = "Menu";
        ChangeScene();
    }
}
