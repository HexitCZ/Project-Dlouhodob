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
    
    public void DisableFPSInteraction()
    {
        for (int i = 0; i < interactionComponents.Length; i++)
        {
            interactionComponents[i].enabled = false;
        }
    }

    public void EnableFPSInteraction()
    {
        for (int i = 0; i < interactionComponents.Length; i++)
        {
            interactionComponents[i].enabled = true;
        }
    }

    public void DisableFPSWeapon()
    {
        for (int i = 0; i < interactionComponents.Length; i++)
        {
            weaponComponents[i].enabled = false;
        }
        weaponRender.SetActive(false);
    }

    public void EnableFPSWeapon()
    {
        for (int i = 0; i < interactionComponents.Length; i++)
        {
            weaponComponents[i].enabled = true;
        }
        weaponRender.SetActive(true);
    }
}
