using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimatorOnRollOver : UIBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float Rate;
    [SerializeField] private Image FillImage;
    [SerializeField] private TextMeshProUGUI TMP;
    [SerializeField] private Color RollOverTextColor;
    private Color BaseTextColor;
    private Vector3 BaseScale;

    protected override void Start()
    {
        base.Start();
        FillImage.fillAmount = 0;
        BaseTextColor = TMP.color;
        BaseScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData){
        FillImage.DOFillAmount(endValue:1f, duration:0.25f)
            .SetEase(Ease.OutCubic)
            .Play();
        FillImage.transform.DOScale(endValue:BaseScale * Rate, duration:0.25f)
            .SetEase(Ease.OutBounce)
            .Play();
        TMP.DOColor(RollOverTextColor, duration:0.25f)
            .Play();
    }

    public void OnPointerExit(PointerEventData eventData){
        FillImage.DOFillAmount(endValue:0f, duration:0.25f)
            .SetEase(Ease.OutCubic)
            .Play();
        FillImage.transform.DOScale(endValue:BaseScale, duration:0.25f)
            .SetEase(Ease.OutBounce)
            .Play();
        TMP.DOColor(BaseTextColor, duration:0.25f)
            .Play();
    }
}
