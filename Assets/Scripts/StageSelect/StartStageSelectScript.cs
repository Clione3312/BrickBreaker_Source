using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartStageSelectScript : MonoBehaviour
{
    [SerializeField, Header("フェード時間")]
    private float fadeTime;
    [SerializeField, Header("フェードパネル")]
    private Image fade;

    [SerializeField, Header("Canvas Group")]
    private CanvasGroup StageSelectPanel;

    [SerializeField, Header("BGM Menu")]
    private AudioSource bgmMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DOTween.Sequence()
            .Append(fade.DOFade(0f, fadeTime))
            .Join(StageSelectPanel.DOFade(1f, fadeTime))
            .AppendInterval(1f)
            .OnComplete(() => fade.gameObject.SetActive(false))
            .Play();

        if (GameObject.FindAnyObjectByType<AudioSource>() == null){
            Instantiate(bgmMenu);
        }
    }
}
