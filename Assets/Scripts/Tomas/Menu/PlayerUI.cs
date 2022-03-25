using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUI : MonoBehaviour
{
    public GameObject upgrade;
    public GameObject hud;

    
    public void OnUpgradeClick(InputAction.CallbackContext inp)
    {
        if (inp.performed)
        {
            upgrade.SetActive(!upgrade.activeSelf);
            hud.SetActive(!hud.activeSelf);
        }
    }

}
