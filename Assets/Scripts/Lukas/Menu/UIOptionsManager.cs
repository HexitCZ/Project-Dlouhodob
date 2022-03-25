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

    private float setVolume;

    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;

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

    private void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
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
        SetFullscreen(isFullscreen);
    }

    public void OnGraphicPresetChange()
    {

    }
}
