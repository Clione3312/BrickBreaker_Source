using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioSource bgmMenu;

    private void Awake() {

        DontDestroyOnLoad(this.gameObject);

        CheckInstance();
    }

    private void CheckInstance(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }
}
