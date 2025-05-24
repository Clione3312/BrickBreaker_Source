using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    enum Mode {
        FadeIn,
        FadeOut,
    }

    [SerializeField, Header("フェード時間")]
    private float fadeTime;
    [SerializeField, Header("フェード種類")]
    private Mode mode;

    private float _alpha;
    private Image image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<Image>();
        switch (mode)
        {
            case Mode.FadeIn:   _alpha = 1f; break;
            case Mode.FadeOut:  _alpha = 0f; break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _Fade(){
        
        DOTween.Sequence().Append(image.DOFade(_alpha, fadeTime)).Play();
    }

}
