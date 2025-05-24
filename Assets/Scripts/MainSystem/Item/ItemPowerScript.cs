using UnityEngine;

public class ItemPowerScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"){
            GameDataScript.Instance._AttackLv++;
        }
    }
}
