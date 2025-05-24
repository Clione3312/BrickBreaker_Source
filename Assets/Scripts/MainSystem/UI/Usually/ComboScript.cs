using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class ComboScript : MonoBehaviour
{
    [SerializeField] CanvasGroup grCombo;
    [SerializeField] TextMeshProUGUI comboText;

    [SerializeField] RectTransform rectCombo;
    // private bool isCombo;

    Sequence sequence1;
    Sequence sequence2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sequence1 = DOTween.Sequence()
            .Append(grCombo.DOFade(1f, 0.2f))
            .Join(rectCombo.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.2f))
            .AppendInterval(1f)

            .Append(grCombo.DOFade(0f, 0.4f))
            .Pause().SetAutoKill(false).SetLink(gameObject);

        sequence2 = DOTween.Sequence()
            .Append(grCombo.DOFade(1f, 0.2f))
            .Join(rectCombo.DOScale(new Vector3(1.5f, 1.5f, 1.0f), 0.2f))
            .AppendInterval(1f)

            .Append(grCombo.DOFade(0f, 0.4f))
            .Join(rectCombo.DOScale(new Vector3(4.0f, 4.0f, 1.0f), 0.4f))
            .Pause().SetAutoKill(false).SetLink(gameObject);
    }

    public void ShowCombo(){
        
        comboText.SetText("{0}", GameDataScript.Instance._Combo);
        rectCombo.localScale = Vector3.one;

        if (GameDataScript.Instance._Combo % 5 == 0) {
            if (sequence1.IsPlaying()) sequence1.Complete();
            sequence2.Restart();
        } else {
            if (sequence2.IsPlaying()) sequence2.Complete();
            sequence1.Restart();
        }

        grCombo.alpha = 1f;
    }

    public void HideCombo(){
        grCombo.alpha = 0f;
    }
}
