using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeCountScript : MonoBehaviour
{
    [SerializeField, Header("時間表示")]
    private TextMeshProUGUI TimeText;

    public string timeString;
    private float TimeCount = 0;
    private bool isTimer;
    private bool _bSwitch;

    // Update is called once per frame
    void Update()
    {
        if (isTimer) { TimeCount += Time.deltaTime; }
        timeString  = ToStringTimeCount();
        TimeText.text = timeString;
    }

    public void _TimeAction(InputAction.CallbackContext context) {
        if (!context.performed && !_bSwitch){
            _bSwitch = true;
            if (!isTimer) isTimer = true;

            _bSwitch = false;
        }
    }

    public void _tPlay(){
        isTimer = true;
    }

    public void _tStop(){
        isTimer = false;
    }

    private string ToStringTimeCount(){

        int sec = (int)TimeCount;
        int mm = sec / 60;
        int ss = sec % 60;
        int ms = (int)(TimeCount * 100f) % 100;

        return mm.ToString("D2") + ":" + ss.ToString("D2") + ":" + ms.ToString("D3");
    }
}
