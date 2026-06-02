using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu_UI : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private Button _resumeButton;

    private AudioController _audioController;
    
    private void Awake()
    {
        _audioController = FindFirstObjectByType<AudioController>();
        _canvas = GetComponent<Canvas>();
        
        //set event listener
        _bgmSlider.onValueChanged.AddListener(delegate { _audioController.SetBGM(_bgmSlider.value); });
        _sfxSlider.onValueChanged.AddListener(delegate { _audioController.SetSFX(_sfxSlider.value); });

        _resumeButton.onClick.AddListener(Hide);
        
        _audioController.OnSoundSettingLoaded += SetSliderValue;
    }

    private void SetSliderValue()
    {
        _bgmSlider.value = PlayerPrefs.GetFloat("bgm");
        _sfxSlider.value = PlayerPrefs.GetFloat("sfx");
    }

    public void Show()
    {
        _canvas.enabled = true;
    }

    public void Hide()
    {
        _canvas.enabled = false;
    }
}
