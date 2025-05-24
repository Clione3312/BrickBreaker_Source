
using System.Collections.Generic;
using Unity.Collections;
using Unity.Multiplayer.Center.Common.Analytics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField, Header("ゲームデータ")]
    private GameDataScript gameData;

    [SerializeField, Header("パドルステータス")]
    private float _PaddleSpeed = 10f;

    private float _PaddleSpeedOld;

    [SerializeField, Header("Ball Object")]
    private BallScript _BallObject;
    
    [SerializeField, Header("Game Menu")]
    private GameObject gameMenu;

    [SerializeField, Header("時間システム")]
    private TimeCountScript timeCount;

    private Rigidbody rb;
    private BoxCollider bc;
    
    private const float PADDLE_SIDE_LENGTH = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        _PaddleSpeedOld = _PaddleSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float _DirecX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector3(_DirecX * _PaddleSpeed, 0, 0 ) * Time.deltaTime;

        MoveSetBall();

        UpdatePaddleSize();
        UpdatePaddleSpeed();
    }

    public void _GameStart(InputAction.CallbackContext context){
        if (!context.performed && !GameDataScript.Instance._GameStart) {
            _BallObject._MoveBall(-1f, 1f);
            GameDataScript.Instance._GameStart = true;
        }
    }

    public void MoveSetBall(){
        if (GameDataScript.Instance._GameStart || !_BallObject) return;
        _BallObject.gameObject.transform.position = new Vector3(gameObject.transform.position.x, _BallObject.gameObject.transform.position.y,gameObject.transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ball") return;
        
        // 衝突位置を取得
        BoxCollider bc = GetComponent<BoxCollider>();
        Vector3 leftPos = gameObject.transform.position - (bc.size / 2);
        Vector3 rightPos = gameObject.transform.position + (bc.size / 2);

        Vector3 hitPos = collision.transform.position;

        float distLeft = Mathf.Abs(leftPos.x - hitPos.x);
        float distRight = Mathf.Abs(rightPos.x - hitPos.x);
        
        if (distLeft < PADDLE_SIDE_LENGTH  ) { _BallObject._MoveBall(-1f, 0f); }
        if (distRight < PADDLE_SIDE_LENGTH) { _BallObject._MoveBall(0f, 1f); }
    }

    private void UpdatePaddleSize(){
        switch (GameDataScript.Instance._SizeLv)
        {
            case 1: 
                this.gameObject.transform.localScale = new Vector3(1.0f, 1f,1f); 
                bc.size = new Vector3(4f, 0.3f, 2f);
                break;
            case 2: 
                this.gameObject.transform.localScale = new Vector3(1.05f, 1f,1f);   
                bc.size = new Vector3(4f * 1.05f, 0.3f, 2f);
                break;
            case 3:
                this.gameObject.transform.localScale = new Vector3(1.2f, 1f,1f);    
                bc.size = new Vector3(4f * 1.2f, 0.3f, 2f);
                break;
            case 4: 
                this.gameObject.transform.localScale = new Vector3(1.35f, 1f,1f);   
                bc.size = new Vector3(4f * 1.35f, 0.3f, 2f);
                break;
            case 5:
                this.gameObject.transform.localScale = new Vector3(1.5f, 1f,1f);    
                bc.size = new Vector3(4f * 1.5f, 0.3f, 2f);
                break;
        }
    }

    private void UpdatePaddleSpeed(){
        switch (GameDataScript.Instance._SpeedLv)
        {
            case 1: 
                _PaddleSpeed = _PaddleSpeedOld * 1.0f;
                break;
            case 2: 
                _PaddleSpeed = _PaddleSpeedOld * 1.05f;
                break;
            case 3:
                _PaddleSpeed = _PaddleSpeedOld * 1.2f;
                break;
            case 4: 
                _PaddleSpeed = _PaddleSpeedOld * 1.35f;
                break;
            case 5:
                _PaddleSpeed = _PaddleSpeedOld * 1.5f;
                break;
        }
    }

    public void OnInputEscapeKey(InputAction.CallbackContext context){
        if (!context.performed && !gameMenu.activeSelf) {
            GameDataScript.Instance.velocityData = new List<Vector3>();
            foreach (var item in GameObject.FindGameObjectsWithTag("Ball"))
            {
                GameDataScript.Instance.velocityData.Add(item.GetComponent<Rigidbody>().linearVelocity);
                item.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            }
            timeCount._tStop();
            gameMenu.SetActive(true);
        }
    }


}
