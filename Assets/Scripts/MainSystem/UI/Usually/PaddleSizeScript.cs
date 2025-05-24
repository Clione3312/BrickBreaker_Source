using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaddleSizeScript : MonoBehaviour
{
    [SerializeField, Header("Game Data")]
    private GameDataScript gameData;

    [SerializeField, Header("Paddle Size Text")]
    private TextMeshProUGUI paddleSizeText;

    [SerializeField, Header("Speed Image")]
    private RawImage Size1;
    [SerializeField] RawImage Size2;
    [SerializeField] RawImage Size3;
    [SerializeField] RawImage Size4;
    [SerializeField] RawImage Size5;

    // Update is called once per frame
    void Update()
    {
        showSpeedImage();
    }

    private void showSpeedImage(){
        if (GameDataScript.Instance._SizeLv > GameDataScript.Instance.SizeMaxLv ) return;

        paddleSizeText.text = GameDataScript.Instance._SizeLv.ToString();

        // レベルに応じて、画像を表示する
        Size1.color = GameDataScript.Instance._SizeLv >= 1 ? Color.white : Color.black;
        Size2.color = GameDataScript.Instance._SizeLv >= 2 ? Color.white : Color.black;
        Size3.color = GameDataScript.Instance._SizeLv >= 3 ? Color.white : Color.black;
        Size4.color = GameDataScript.Instance._SizeLv >= 4 ? Color.white : Color.black;
        Size5.color = GameDataScript.Instance._SizeLv >= 5 ? Color.white : Color.black;
    }
}
