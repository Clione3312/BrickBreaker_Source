using UnityEngine;

public class ItemSpeedScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"){
            GameDataScript.Instance._SpeedLv++;
        }
    }
}
