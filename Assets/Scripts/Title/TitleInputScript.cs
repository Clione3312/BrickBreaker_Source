using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TitleInputScript : MonoBehaviour
{
    [SerializeField, Header("Fade")]
    private Image fade;

    [SerializeField, Header("BGM")]
    private AudioSource bgm;

    [SerializeField, Header("SE")]
    private AudioSource seSubmit;

    private bool isStart;

    public void OnAnyKey(InputAction.CallbackContext context){
        if (!context.performed && !isStart){
            isStart = true;
            DOTween.Sequence()
                .Append(fade.DOFade(1f, 2f))
                .Join(bgm.DOFade(0f, 1.5f))
                .OnComplete(() => SceneManager.LoadScene("Menu"));

            Instantiate(seSubmit);
        }
    }
}
