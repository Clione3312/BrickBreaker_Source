using UnityEngine;

public class MenuStartScript : MonoBehaviour
{
    [SerializeField, Header("BGM")]
    private AudioSource bgmMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameSaveSystem.Instance.Load();

        if (GameObject.FindAnyObjectByType<AudioSource>() == null) {
            Instantiate(bgmMenu);
        }    
    }
}
