using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubScript : MonoBehaviour
{
    void Start()
    {
               
    }

    void Update()
    {
        
    }
    bool huh = true;
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "MidBody")
        {
            huh = true;
            FPSInteractionManager.instance.DisableFPSWeapon();
        }
        else if (other.name == "Head")
        {
            huh = true;
            FPSInteractionManager.instance.DisableFPSWeapon();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "MidBody")
        {
            huh = false;
            FPSInteractionManager.instance.EnableFPSWeapon();
        } 
        else if (other.name == "Head")
        {
            huh = false;
            FPSInteractionManager.instance.EnableFPSWeapon();
        }
    }
}
