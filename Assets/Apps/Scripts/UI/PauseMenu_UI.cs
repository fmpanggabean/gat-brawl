using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu_UI : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    private AudioController _audioController;
    
    private void Awake()
    {
        _audioController = FindFirstObjectByType<AudioController>();
        
        //set event listener
        bgmSlider.onValueChanged.AddListener(delegate { _audioController.SetBGM(bgmSlider.value); });
        sfxSlider.onValueChanged.AddListener(delegate { _audioController.SetSFX(sfxSlider.value); });

        _audioController.OnSoundSettingLoaded += SetSliderValue;
    }

    private void SetSliderValue()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("bgm");
        sfxSlider.value = PlayerPrefs.GetFloat("sfx");
    }
}
