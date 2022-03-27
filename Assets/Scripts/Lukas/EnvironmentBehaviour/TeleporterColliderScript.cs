using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterColliderScript : MonoBehaviour
{

    [Space]
    [SerializeField]
    [Header("Set teleport location")]
    private string location;

    void Start()
    {
        location = "None";
    }

    
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (location == "Environment1")
        {
            SceneManager.LoadScene(location);
        }
        else if(location == "Environment2")
        {
            SceneManager.LoadScene(location);
        }
        else
        {
            location = "None";
        }
    }

    public void setCurrentTeleportLocation(string location_name)
    {
        if (location_name == "First level")
        {
            location = "Environment1";
        }
        else if(location_name == "Second level")
        {
            location = "Environment2";
        }
        else
        {
            location = "None";
        }
    }

    public void OnTeleportEnvOne()
    {
        
        SceneManager.LoadScene(location);
    
    }

    public void OnTeleportEnvTwo()
    {
        
        SceneManager.LoadScene(location);
    
    }
}
