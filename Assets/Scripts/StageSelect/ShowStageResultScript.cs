using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowStageResultScript : MonoBehaviour
{
    [SerializeField, Header("Stage Count")]
    private int stageCount;

    [SerializeField, Header("Stage Format")]
    private GameObject goIcon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        int stageNo = 0;
        for (int i = 0; i < stageCount - 1; i++)
        {
            var Icon = Instantiate(goIcon, gameObject.transform);
            Icon.name =  (int.Parse(goIcon.name) + i + 1).ToString("000"); 
        }

        GameStageDataScript.Instance.stageCount = gameObject.transform.childCount;
        foreach (Transform child in gameObject.transform) {
            RawImage picStageImage = child.transform.GetChild(0).gameObject.GetComponent<RawImage>();
            Image rank = child.transform.GetChild(1).gameObject.GetComponent<Image>();
            TextMeshProUGUI text = child.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
            
            ResultData resultData = GameSaveSystem.Instance.GameData.stageDatas[stageNo].resultData;
            if (resultData.isClear) {

                // ランクの表示
                Texture2D rankImage = Resources.Load("Rank\\Rank" + resultData.clearRank) as Texture2D;
                rank.sprite = Sprite.Create(rankImage, new Rect(0,0,rankImage.width,rankImage.height), Vector2.zero);
                rank.color = new Color(1f,1f,1f,1f);

                // 表示画像の編集
                picStageImage.material = null;
            }

            if (stageNo > 0) {
                child.gameObject.SetActive(GameSaveSystem.Instance.GameData.stageDatas[stageNo - 1].resultData.isClear);
            }

            text.text = (stageNo +1 ).ToString();

            stageNo++;
        }

    }
}
