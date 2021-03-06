using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInteractionManager : MonoBehaviour
{
    public static FPSInteractionManager instance;

    public Behaviour[] interactionComponents;

    public Behaviour[] weaponComponents;
    public GameObject weaponRender;
    void Awake()
    {
        instance = this;
    }
    
    public void DisableFPSInteraction(bool stopTime = false)
    {
        for (int i = 0; i < interactionComponents.Length; i++)
        {
            interactionComponents[i].enabled = false;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (stopTime)
        {
            Time.timeScale = 0;
        }

    }

    public void EnableFPSInteraction()
    {
        for (int i = 0; i < interactionComponents.Length; i++)
        {
            interactionComponents[i].enabled = true;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1;

    }

    public void DisableFPSWeapon()
    {
        for (int i = 0; i < weaponComponents.Length; i++)
        {
            weaponComponents[i].enabled = false;
        }
        weaponRender.SetActive(false);
    }

    public void EnableFPSWeapon()
    {
        for (int i = 0; i < weaponComponents.Length; i++)
        {
            weaponComponents[i].enabled = true;
        }
        weaponRender.SetActive(true);
    }
}
