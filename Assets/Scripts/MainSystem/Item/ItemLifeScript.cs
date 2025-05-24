using UnityEngine;

public class ItemLifeScript : MonoBehaviour
{
    [SerializeField, Header("ゲームデータ")]
    private GameDataScript GameData; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"){
            GameDataScript.Instance._PlayerLife++;
        }
    }
}
