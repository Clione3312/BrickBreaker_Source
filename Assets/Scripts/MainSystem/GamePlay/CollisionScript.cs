using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField, Header("Time Count")]
    private TimeCountScript TimeCount;

    [SerializeField, Header("Game Data")]
    private GameDataScript GameData;

    [SerializeField, Header("コンボ システム")]
    private ComboScript combo;

    [SerializeField, Header("Player Ball")]
    private GameObject PlayerBall;

    [SerializeField, Header("Player System")]
    private PlayerScript PlayerSystem;

    [SerializeField, Header("Cut In")]
    private GameObject panelCutIn;
    [SerializeField] private CanvasGroup cgLife;
    [SerializeField] private TextMeshProUGUI textCount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball") {
            
            List<GameObject> go = IsExistsBall(collision.gameObject);
            if (go.Count == 0) {
                GameDataScript.Instance._GameStart = false;

                Vector3 PlayerPos = PlayerSystem.gameObject.transform.localPosition;
                Vector3 BallPos = new Vector3(PlayerPos.x, 3.5f, 0f);

                collision.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                collision.gameObject.transform.localPosition = BallPos;

                if (GameDataScript.Instance._PlayerLife > 0) {
                    DOTween.Sequence()
                        .OnStart(() => panelCutIn.SetActive(true))
                        .Append(panelCutIn.transform.DOMove(new Vector3(960f,540f,0f), 0.5f))
                        .Join(panelCutIn.transform.DORotate(new Vector3(0f,0f,0f), 0.5f))
                        .Join(panelCutIn.GetComponent<CanvasGroup>().DOFade(1f, 0.5f))
                        .AppendCallback(() => {
                            textCount.text = (GameDataScript.Instance._PlayerLife).ToString();
                            cgLife.alpha = 1f;
                        })
                        .AppendInterval(1f)
                        .AppendCallback(() => {
                            cgLife.alpha = 0f;
                        })
                        .Append(panelCutIn.transform.DOMove(new Vector3(0f,540f,0f), 0.5f))
                        .Join(panelCutIn.transform.DORotate(new Vector3(-90f,0f,0f), 0.5f))
                        .Join(panelCutIn.GetComponent<CanvasGroup>().DOFade(0f, 0.5f))
                        .OnComplete(() => {
                            panelCutIn.transform.position = new Vector3(960f,540f,0f);
                            panelCutIn.SetActive(false);
                        });
                }

                combo.HideCombo();
                TimeCount._tStop();
                GameDataScript.Instance._PlayerLife--;
                GameDataScript.Instance._Combo = 0;
            }

            if (GameDataScript.Instance._PlayerLife < 0 || go.Count > 0) {
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.tag == "Item") {
            Destroy(collision.gameObject);
        }
    }

    private List<GameObject> IsExistsBall(GameObject obj){
        var _List = GameObject.FindGameObjectsWithTag("Ball");
        List<GameObject> go = new List<GameObject>();

        foreach (var item in _List)
        {
            if(obj != item) go.Add(item);
        }

        return go;
    }
}
