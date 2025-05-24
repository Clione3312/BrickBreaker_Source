using UnityEngine;

public class SE : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayingEnd();
    }

    private void PlayingEnd(){
        if (audioSource.isPlaying) return;
        Destroy(gameObject);
    }
}
