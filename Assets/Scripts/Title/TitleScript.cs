using UnityEngine;
using DG.Tweening;
using TMPro;

public class TitleScript : MonoBehaviour
{
    [SerializeField, Header("テキスト")]
    private TextMeshProUGUI StartText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence
            .Append(StartText.DOFade(0.5f, 1f))
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);

    }

}
