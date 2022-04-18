using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    [SerializeField]
    [Space]
    [Header("Name of OnClick options scene")]
    public string optionsButtonScene;

    [SerializeField]
    [Space]
    [Header("Name of OnClick play scene")]
    public string playButtonScene;

    public void OnPLAYButtonClick()
    {
        if (optionsButtonScene == "Hub")
        {
            SceneManager.LoadScene(playButtonScene);
        }
        else
        {
            playButtonScene = "Hub";
            SceneManager.LoadScene(playButtonScene);
        }
    }

    public void OnOPTIONSClick()
    {
        if (optionsButtonScene == "Options")
        {
            SceneManager.LoadScene(optionsButtonScene);
        }
        else
        {
            optionsButtonScene = "Options";
            SceneManager.LoadScene(optionsButtonScene);
        }
    }

    public void OnQUIT()
    {
        Application.Quit();
    }

}

