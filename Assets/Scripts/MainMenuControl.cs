using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuControl : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    [Header("Paneles")]
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject mainMenuButtons;

    void Start()
    {
        // Carga los valores guardados (o pone 1 = 100% por defecto la primera vez)
        float savedMusic = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float savedSFX = PlayerPrefs.GetFloat("SFXVolume", 1f);

        musicSlider.value = savedMusic;
        sfxSlider.value = savedSFX;

        SetMusicVolume(savedMusic);
        SetSFXVolume(savedSFX);

        if (optionsPanel != null)
            optionsPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        mainMenuButtons.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        mainMenuButtons.SetActive(true);
    }

    public void SetMusicVolume(float value)
    {
        // value va de 0 a 1, lo convertimos a decibeles para el Mixer
        float dB = (value <= 0.0001f) ? -80f : Mathf.Log10(value) * 20f;
        bool success = audioMixer.SetFloat("MusicVolume", dB);
        Debug.Log("MUSICA -> ¿Se aplicó?: " + success + " | value: " + value + " | dB: " + dB);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        float dB = (value <= 0.0001f) ? -80f : Mathf.Log10(value) * 20f;
        bool success = audioMixer.SetFloat("SFXVolume", dB);
        Debug.Log("SFX -> ¿Se aplicó?: " + success + " | value: " + value + " | dB: " + dB);
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}