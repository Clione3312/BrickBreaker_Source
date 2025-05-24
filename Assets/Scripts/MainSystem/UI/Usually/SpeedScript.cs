using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedScript : MonoBehaviour
{
    [SerializeField, Header("Game Data")]
    private GameDataScript gameData;

    [SerializeField, Header("Speed Text")]
    private TextMeshProUGUI speedText;

    [SerializeField, Header("Speed Image")]
    private RawImage Speed1;
    [SerializeField] RawImage Speed2;
    [SerializeField] RawImage Speed3;
    [SerializeField] RawImage Speed4;
    [SerializeField] RawImage Speed5;

    // Update is called once per frame
    void Update()
    {
        showSpeedImage();
    }

    private void showSpeedImage(){
        if (GameDataScript.Instance._SpeedLv > GameDataScript.Instance._SpeedMaxLv ) return;

        speedText.text = GameDataScript.Instance._SpeedLv.ToString();

        // レベルに応じて、画像を表示する
        Speed1.color = GameDataScript.Instance._SpeedLv >= 1 ? Color.white : Color.black;
        Speed2.color = GameDataScript.Instance._SpeedLv >= 2 ? Color.white : Color.black;
        Speed3.color = GameDataScript.Instance._SpeedLv >= 3 ? Color.white : Color.black;
        Speed4.color = GameDataScript.Instance._SpeedLv >= 4 ? Color.white : Color.black;
        Speed5.color = GameDataScript.Instance._SpeedLv >= 5 ? Color.white : Color.black;
    }
}
