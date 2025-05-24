using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SceneChangeScript : MonoBehaviour
{
    [SerializeField, Header("フェード 設定")]
    private float fadeTime;
    [SerializeField]private Image fade;
    [SerializeField]private AudioSource seSubmit;
    [SerializeField]private AudioSource bgmMenu;

    private Sequence sequence;

    private const string STAGE_SCENE_FORMAT = "Stage";
    private const string NUMBERING_FORMAT = "000";

    public void OnClickStage(){
        GameStageDataScript.Instance.stageNo = int.Parse(gameObject.name);

        ActivateFade();
        Instantiate(seSubmit);
        sequence = DOTween.Sequence()
            .Append(fade.DOFade(1f, fadeTime))
            .Join(bgmMenu.DOFade(0f,fadeTime ))
            .AppendInterval(0.5f)
            .OnComplete(() => SceneChange(STAGE_SCENE_FORMAT));
    }

    private void ActivateFade(){
        fade.gameObject.SetActive(true);
    }

    private void SceneChange(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
