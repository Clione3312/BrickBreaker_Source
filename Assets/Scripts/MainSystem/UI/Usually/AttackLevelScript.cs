using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackLevelScript : MonoBehaviour
{
    [SerializeField, Header("Game Data")]
    private GameDataScript gameData;

    [SerializeField, Header("Attack Text")]
    private TextMeshProUGUI attackText;

    [SerializeField, Header("Attack Image")]
    private RawImage Attack1;
    [SerializeField] RawImage Attack2;
    [SerializeField] RawImage Attack3;
    [SerializeField] RawImage Attack4;
    [SerializeField] RawImage Attack5;

    // Update is called once per frame
    void Update()
    {
        showAttackImage();
    }

    private void showAttackImage(){
        if (GameDataScript.Instance._AttackLv > GameDataScript.Instance.AttackMaxLv ) return;

        attackText.text = GameDataScript.Instance._AttackLv.ToString();

        // レベルに応じて、画像を表示する
        Attack1.color = GameDataScript.Instance._AttackLv >= 1 ? Color.white : Color.black;
        Attack2.color = GameDataScript.Instance._AttackLv >= 2 ? Color.white : Color.black;
        Attack3.color = GameDataScript.Instance._AttackLv >= 3 ? Color.white : Color.black;
        Attack4.color = GameDataScript.Instance._AttackLv >= 4 ? Color.white : Color.black;
        Attack5.color = GameDataScript.Instance._AttackLv >= 5 ? Color.white : Color.black;
    }
}
