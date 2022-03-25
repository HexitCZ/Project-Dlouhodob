using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIOptionsManager : MonoBehaviour
{

    [SerializeField]
    [Space]
    [Header("Name of OnClick main menu scene")]
    public string mainMenuScene;

    [SerializeField]
    [Space]
    [Header("Game is fullscreen")]
    private bool isFullscreen;
    
    [SerializeField]
    [Space]
    [Header("Game Audio level")]
    private float currentVolume;

    [SerializeField]
    [Space]
    [Header("Fullscreen setting ui element reference")]
    private Transform fullscreenButton;

    private float setVolume;

    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;   

    public Slider volumeSlider;

    Resolution[] resolutions;

    void Start()
    {
        isFullscreen = false;
        currentVolume = 0f;
        mainMenuScene = "Menu";
        
    }

    void Update()
    {
        currentVolume = AudioListener.volume;
    }

    private float GetVolumeFromSlider()
    {
        float volume = 0f;
        volume = volumeSlider.value * 10;

        return volume;
    }

    private void SetVolume(float volume)
    {
        setVolume = volume;
        AudioListener.volume = setVolume;
    }

    private void SetFullscreen()
    {
        Screen.fullScreen = true;
    }
    
    private void SetWindowed()
    {
        Screen.fullScreen = false;
    }
    

    public void OnSliderDrag()
    {
        float volume = GetVolumeFromSlider();
        SetVolume(volume);
    }

    public void OnBackClick()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void OnFullscreenChange()
    {

        isFullscreen = !isFullscreen;

    }

    public void OnGraphicPresetChange()
    {
        Debug.Log(QualitySettings.currentLevel);
    }
}
