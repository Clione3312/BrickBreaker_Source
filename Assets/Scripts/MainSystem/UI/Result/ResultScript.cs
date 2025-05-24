using DG.Tweening;
using UnityEngine;

public class ResultScript : MonoBehaviour
{
    [SerializeField] CanvasGroup grResult;

    public void FadeIn() {
        grResult.DOFade(1f,3f);
    }
}
