using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField, Header("ボール ステータス")]
    public float _BallSpeed = 5f;

    [SerializeField, Header("SE Effect")]
    private AudioSource seReflect;
    [SerializeField] AudioSource seError;

    private Rigidbody rb;

    private float prevCollisionX;
    private float prevCollisionY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void _MoveBall(float min, float max){
        rb.linearVelocity = new Vector3(Random.Range(min, max) * _BallSpeed, _BallSpeed , 0f) * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {   
        if (gameObject.transform.position.x != prevCollisionX && gameObject.transform.position.y == prevCollisionY) {
            rb.linearVelocity = new Vector3(_BallSpeed, Random.Range(-1f, 1f) * _BallSpeed , 0f) * Time.deltaTime;
        }
        prevCollisionY = gameObject.transform.position.y;
        prevCollisionX = gameObject.transform.position.x;


        if (GameDataScript.Instance._GameStart){
            if (collision.gameObject.tag != "BreakArea") {
                Instantiate(seReflect);
            } else {
                Instantiate(seError);
            }
        }

        Vector3 velocity = rb.linearVelocity;
        float clampedSpeed = Mathf.Clamp(velocity.magnitude, _BallSpeed, _BallSpeed)  * Time.deltaTime;
        rb.linearVelocity = velocity.normalized * clampedSpeed;
    }

}
