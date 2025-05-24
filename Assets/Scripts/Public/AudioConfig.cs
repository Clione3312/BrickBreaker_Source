using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using AudioConfigFile;

public class AudioConfig : MonoBehaviour
{
    [SerializeField, Header("Audio Mixer")]
    private AudioMixer audioMixer;

    [SerializeField, Header("スライダー")]
    private Slider bgmSlider;
    [SerializeField] Slider seSlider;

    [SerializeField, Header("値表示")]
    private TextMeshProUGUI bgmValue;
    [SerializeField] TextMeshProUGUI seValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgmSlider.onValueChanged.AddListener((value) => {
            value = Mathf.Clamp01(value);
            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);
            audioMixer.SetFloat("BGM", decibel);

            bgmValue.text = ((Int32)(value * 100)).ToString();

            AudioSaveSystem.Instance.AudioConfigData.valBGM = value;
            AudioSaveSystem.Instance.AudioConfigData.decibelBGM  = decibel;
            AudioSaveSystem.Instance.Save();
        });

        seSlider.onValueChanged.AddListener((value) => {
            value = Mathf.Clamp01(value);
            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);
            audioMixer.SetFloat("SE", decibel);

            seValue.text = ((Int32)(value * 100)).ToString();
            AudioSaveSystem.Instance.AudioConfigData.valSE = value;
            AudioSaveSystem.Instance.AudioConfigData.decibelSE  = decibel;
            AudioSaveSystem.Instance.Save();
        });
        
    }

}
