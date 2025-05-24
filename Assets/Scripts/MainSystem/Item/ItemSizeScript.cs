using UnityEngine;

public class ItemSizeScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"){
            GameDataScript.Instance._SizeLv++;
        }
    }
}
