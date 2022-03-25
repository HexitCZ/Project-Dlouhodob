using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        SceneManager.LoadScene(playButtonScene);
    }

    public void OnOPTIONSClick()
    {
        SceneManager.LoadScene(optionsButtonScene);
    }

    public void OnQUIT()
    {
        Application.Quit();
    }

}
