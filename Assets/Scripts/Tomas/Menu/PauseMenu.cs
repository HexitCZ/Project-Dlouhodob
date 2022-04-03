using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    public GameObject escapeMenu;
    public GameObject exitMenu;

    private bool state;

    public void Show()
    {
        state = true;
        escapeMenu.SetActive(true);
        FPSInteractionManager.instance.DisableFPSInteraction(true);
        
    }

    public void Hide()
    {
        state=false;
        escapeMenu.SetActive(false);
        FPSInteractionManager.instance.EnableFPSInteraction();
    }

    public void OnExitButton()
    {
        exitMenu.SetActive(true);
    }


    public void OnConfirmExit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnDeclineExit()
    {
        exitMenu.SetActive(false);
    }

    private void OnStateChange()
    {
        if (state)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    public void OnEscape(InputAction.CallbackContext inp)
    {
        if (inp.performed)
        {
            state = !state;
            OnStateChange();
        }
    }
    
}
