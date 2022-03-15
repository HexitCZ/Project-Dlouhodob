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
        if(other.name == "MidBody" || other.name == "Head" && huh)
        {
            FPSInteractionManager.instance.DisableFPSWeapon();
            huh = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "MidBody" || other.name == "Head")
        {
            FPSInteractionManager.instance.EnableFPSWeapon();
        }
    }
}
