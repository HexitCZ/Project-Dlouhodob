using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubScript : MonoBehaviour
{
    
    

    void Start()
    {
       
    }

    void Update()
    {
        
    }
    //bool huh = true;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //huh = true;
            FPSInteractionManager.instance.DisableFPSWeapon();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //huh = false;
            FPSInteractionManager.instance.EnableFPSWeapon();
        } 
        
    }
}
