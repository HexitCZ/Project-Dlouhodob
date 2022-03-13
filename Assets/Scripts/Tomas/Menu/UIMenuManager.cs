using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    public string playButtonScene;

    public void OnPLAYButtonClick()
    {
        SceneManager.LoadScene(playButtonScene);
    }
}
