using UnityEngine;
using UnityEngine.Audio;

public class TitleAudioSystem : MonoBehaviour
{
    [SerializeField, Header("Audio Mixer")]
    private AudioMixer audioMixer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSaveSystem.Instance.Load();

        audioMixer.SetFloat("BGM",AudioSaveSystem.Instance.AudioConfigData.decibelBGM);
        audioMixer.SetFloat("SE",AudioSaveSystem.Instance.AudioConfigData.decibelSE);
    }
}
