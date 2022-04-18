using System.Collections;
using TMPro;
using UnityEngine;
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
    [Header("Game fullscreen mode")]
    private string fullscreen_mode;

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

    private string[] fullscreen_modes;

    private Resolution[] resolutions;
    private Resolution currentResolution;


    void Start()
    {
        try
        {

            currentVolume = 0f;
            mainMenuScene = "Menu";
            fullscreen_modes = new string[] {
            "Maximized\nWindow",
            "Exclusive\nFullscreen",
            "Windowed",
            "Full\nscreen"
        };
        }
        catch (UnassignedReferenceException)
        {

        }
        fullscreen_mode = "Full\nscreen";
        //Screen.SetResolution(640, 480, FullScreenMode.ExclusiveFullScreen, 60);

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
        try
        {
            int height = Screen.currentResolution.height;
            int width = Screen.currentResolution.width;
            int refreshRate = Screen.currentResolution.refreshRate;
            Screen.SetResolution(height, width, FullScreenMode.FullScreenWindow, refreshRate);
            TextMeshProUGUI fullscreen_text = fullscreenButton.GetChild(0).GetComponent<TextMeshProUGUI>();
            fullscreen_text.text = "Windowed";
            fullscreen_text.fontSize = 45;
            fullscreen_mode = fullscreen_text.text;
        }
        catch (UnassignedReferenceException)
        {

        }
    }

    private void SetWindowed()
    {
        try
        {
            int height = Screen.currentResolution.height;
            int width = Screen.currentResolution.width;
            int refreshRate = Screen.currentResolution.refreshRate;
            Screen.SetResolution(height, width, FullScreenMode.Windowed, refreshRate);
            TextMeshProUGUI fullscreen_text = fullscreenButton.GetChild(0).GetComponent<TextMeshProUGUI>();
            fullscreen_text.text = "Exclusive\nFullscreen";
            fullscreen_text.fontSize = 35f;
            fullscreen_mode = fullscreen_text.text;
        }
        catch (UnassignedReferenceException)
        {

        }
    }

    private void SetExclusiveFullscreen()
    {
        try
        {
            int height = Screen.currentResolution.height;
            int width = Screen.currentResolution.width;
            int refreshRate = Screen.currentResolution.refreshRate;

            Screen.SetResolution(height, width, FullScreenMode.FullScreenWindow, refreshRate);

            TextMeshProUGUI fullscreen_text = fullscreenButton.GetChild(0).GetComponent<TextMeshProUGUI>();

            fullscreen_text.text = "Maximized\nWindow";
            fullscreen_text.fontSize = 35f;
            fullscreen_mode = fullscreen_text.text;
        }
        catch (UnassignedReferenceException)
        {

        }
    }

    private void SetMaximizedWindow()
    {
        try
        {
            int height = Screen.currentResolution.height;
            int width = Screen.currentResolution.width;
            int refreshRate = Screen.currentResolution.refreshRate;

            Screen.SetResolution(height, width, FullScreenMode.FullScreenWindow, refreshRate);

            TextMeshProUGUI fullscreen_text = fullscreenButton.GetChild(0).GetComponent<TextMeshProUGUI>();

            fullscreen_text.text = "Full\nscreen";
            fullscreen_text.fontSize = 45f;
            fullscreen_mode = fullscreen_text.text;

        }
        catch (UnassignedReferenceException)
        {

        }
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
        try
        {

            if (fullscreen_mode == fullscreen_modes[3])
            {
                SetFullscreen();
            }
            else if (fullscreen_mode == fullscreen_modes[2])
            {
                SetWindowed();
            }
            else if (fullscreen_mode == fullscreen_modes[1])
            {
                SetExclusiveFullscreen();
            }
            else if (fullscreen_mode == fullscreen_modes[0])
            {
                SetMaximizedWindow();
            }
        }
        catch (UnassignedReferenceException)
        {

        }
    }

    public void OnResolutionChange()
    {
        try
        {


            if (resolutionDropdown.value == 0)
            {
                Screen.SetResolution(1920, 1080, Screen.fullScreenMode, 60);
            }
            else if (resolutionDropdown.value == 1)
            {
                Screen.SetResolution(1600, 900, Screen.fullScreenMode, 60);
            }
            else if (resolutionDropdown.value == 2)
            {
                Screen.SetResolution(1280, 720, Screen.fullScreenMode, 60);
            }
        }
        catch (UnassignedReferenceException)
        {

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
