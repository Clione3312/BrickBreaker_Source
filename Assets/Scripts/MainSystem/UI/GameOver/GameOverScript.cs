using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    [SerializeField, Header("Game End Panel")]
    private CanvasGroup grGameOver;
    [SerializeField] private CanvasGroup grGameEnd;
    [SerializeField] private Button btnNextStage;
    [SerializeField] private float fadeTime;

    private bool bPush;

    private void Update()
    {
        gameObject.SetActive(GameDataScript.Instance._GameOver);
    }

    public void FadeIn() {
        DOTween.Sequence().Append(grGameOver.DOFade(1f,3f));
    }

    public void OnAnyKeyInput(InputAction.CallbackContext context){
        if (!context.performed && !bPush && grGameOver.gameObject.activeSelf){
            btnNextStage.gameObject.SetActive(false);

            bPush = true;
            grGameEnd.gameObject.SetActive(true);
            DOTween.Sequence()
                .Append(grGameEnd.DOFade(1f, fadeTime))
                .Join(grGameOver.DOFade(0f,fadeTime));
        }
    }
}
