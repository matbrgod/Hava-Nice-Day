using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerizador : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        LoadVolume();
    }
    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void UpdateSoundVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }

    public void SaveVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        audioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    public void LoadVolume()
    {
        if(musicSlider != null)
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        if(sfxSlider != null)
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        audioMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
    }
}
