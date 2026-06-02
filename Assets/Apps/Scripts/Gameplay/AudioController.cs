using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    public Action OnSoundSettingLoaded;
    
    private void Start()
    {
        LoadAudioSetting();
    }

    private void LoadAudioSetting()
    {
        float bgmVolume = PlayerPrefs.GetFloat("bgm", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("sfx", 1f);
        
        _audioMixer.SetFloat("bgm", bgmVolume);
        _audioMixer.SetFloat("sfx", sfxVolume);
        
        OnSoundSettingLoaded.Invoke();
    }

    public void SetBGM(float value)
    {
        _audioMixer.SetFloat("bgm", value);
        PlayerPrefs.SetFloat("bgm", value);
    }

    public void SetSFX(float value)
    {
        _audioMixer.SetFloat("sfx", value);
        PlayerPrefs.SetFloat("sfx", value);
    }
}
