using UnityEngine;

public class ItemDoubleScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"){
            GameObject[] go = GameObject.FindGameObjectsWithTag("Ball");
            foreach (var item in go)
            {
                var ball = Instantiate(item, item.transform.position, item.transform.localRotation);
                float _Speed = ball.GetComponent<BallScript>()._BallSpeed;
                ball.GetComponent<Rigidbody>().linearVelocity = new Vector3(Random.Range(-1f, 1f) * _Speed, _Speed , 0f) * Time.deltaTime;
            }
        }
    }
}
