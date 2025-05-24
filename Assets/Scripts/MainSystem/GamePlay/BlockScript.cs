using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField, Header("Game Score")]
    private GameScoreScript GameScore;

    [SerializeField, Header("コンボ システム")]
    private ComboScript combo;

    [SerializeField, Header("ブロック ステータス")]
    private int _BlockLife = 0;

    [SerializeField, Header("アイテム")]
    private GameObject[] ItemArray;

    [SerializeField, Header("アイテムの落下速度")]
    private float INST_ITEM_PROBABILITY = 0.1f;

    private int _BlockMaxLife; // 元のヒットポイント



    private void Start()
    {
        _BlockMaxLife = _BlockLife;
    } 

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball"){
            _BlockLife -= GameDataScript.Instance._AttackLv;
            if (_BlockLife <= 0) {
                InstantiateItem();

                GameDataScript.Instance._Combo++;
                combo.ShowCombo();
                
                GameScore.AddScore(_BlockMaxLife * 100 * GameDataScript.Instance._Combo);
                Destroy(gameObject);
            }
        }
    }

    private void InstantiateItem(){
        float instRandom = Random.Range(0f,1f);

        if (instRandom > INST_ITEM_PROBABILITY) return;

        int selectItem = Random.Range(0,5);

        Instantiate(ItemArray[selectItem], gameObject.transform.position, ItemArray[selectItem].transform.localRotation);
    }
}
