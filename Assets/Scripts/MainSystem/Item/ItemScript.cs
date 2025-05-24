using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] float _Gravity = 0f;

    [SerializeField, Header("SE Effect")] 
    private AudioSource sePower;

    [SerializeField, Header("Game Score")]
    private GameScoreScript GameScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearDamping = _Gravity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(sePower);
            Destroy(gameObject);
        }
    }
}
