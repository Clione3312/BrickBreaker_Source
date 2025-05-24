using UnityEngine;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour
{
    [SerializeField, Header("Game Data")]
    private GameDataScript gameData;

    [SerializeField, Header("Life Image")]
    private RawImage Life1;
    [SerializeField] RawImage Life2;
    [SerializeField] RawImage Life3;
    [SerializeField] RawImage Life4;
    [SerializeField] RawImage Life5;

    private void Update()
    {
        showLifeImage();
    }

    private void showLifeImage(){
        if (GameDataScript.Instance._PlayerLife > GameDataScript.Instance._PlayerMaxLife) return;

        // 条件に応じて、画像を表示
        Life1.enabled = GameDataScript.Instance._PlayerLife >= 1;
        Life2.enabled = GameDataScript.Instance._PlayerLife >= 2;
        Life3.enabled = GameDataScript.Instance._PlayerLife >= 3;
        Life4.enabled = GameDataScript.Instance._PlayerLife >= 4;
        Life5.enabled = GameDataScript.Instance._PlayerLife >= 5;
    }

}
