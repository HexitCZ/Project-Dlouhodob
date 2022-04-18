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

    /// <summary>
    /// Vypne zbrane hraci v zone, kde k nim nema mit pristup
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //huh = true;
            FPSInteractionManager.instance.DisableFPSWeapon();
        }
        
    }
    
    /// <summary>
    /// Opetovne dostava hrac sve zbrane
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //huh = false;
            FPSInteractionManager.instance.EnableFPSWeapon();
        } 
        
    }
}
