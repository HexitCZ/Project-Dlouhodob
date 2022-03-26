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

    [SerializeField]
    [Space]
    [Header("Background image reference")]
    private Transform background;

    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;   

    public Slider volumeSlider;

    Resolution[] resolutions;

    void Start()
    {

        isFullscreen = Screen.fullScreen;
        currentVolume = 0f;
        mainMenuScene = "Menu";
        
    }
    

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }

    public void Awake()
    {

        /*UnvailGradient();
        StartCoroutine(Wait());*/

    }

    public void OnDestroy()
    {
        
        /*CoverGradient();
        StartCoroutine(Wait());*/


    }

    void Update()
    {
        currentVolume = AudioListener.volume;

    }

    public void UnvailGradient()
    {
        for (float f = 0.01f; f <= 1.0f; f++)
        {
            background.GetComponent<Image>().fillAmount += f;
        }
    }

    public void CoverGradient()
    {
        for (float f = 1.0f; f >= 0.0f; f--)
        {
            background.GetComponent<Image>().fillAmount -= f;
        }
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
        fullscreenButton.GetChild(0).GetComponent<TextMeshProUGUI>().text = "windowed";
        Screen.fullScreen = true;
        TextMeshProUGUI fullscreen_text = fullscreenButton.GetChild(0).GetComponent<TextMeshProUGUI>();
        fullscreen_text.text = "Windowed";
        fullscreen_text.fontSize = 45;
        Debug.Log("fullscreen");
    }
    
    private void SetWindowed()
    {

        TextMeshProUGUI fullscreen_text = fullscreenButton.GetChild(0).GetComponent<TextMeshProUGUI>();
        fullscreen_text.text = "Full\nscreen";
        fullscreen_text.fontSize = 52.7f;
        Screen.fullScreen = false;
        Debug.Log("windowed");

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

        if (isFullscreen)
        {
            SetFullscreen();
        }
        else
        {
            SetWindowed();
        }
    }

    public void OnGraphicPresetChange()
    {
        int qualityIndex = qualityDropdown.value;
        qualityIndex += 1;
        ChangeGraphicsPreset(qualityIndex);
    }

    private void ChangeGraphicsPreset(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
