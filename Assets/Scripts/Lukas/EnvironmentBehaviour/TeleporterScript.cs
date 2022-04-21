using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TeleporterScript : MonoBehaviour
{



    [SerializeField]
    [Space]
    [Header("Name of first environment scene")]
    public string firstEnvScene;

    [SerializeField]
    [Space]
    [Header("Name of second environment scene")]
    public string secondEnvScene;

    [SerializeField]
    [Space]
    [Header("Name of last environment scene")]
    public string lastEnvScene;

    [SerializeField]
    [Space]
    [Header("Name of OnClick first environment scene")]
    public string currentLoadScene;
    
    [SerializeField]
    [Space]
    [Header("Teleporter text")]
    public TextMeshProUGUI tele_text;

    [SerializeField]
    [Space]
    [Header("Set location to first environment")]
    public Transform tele_first_button;
    
    [SerializeField]
    [Space]
    [Header("Set location to second environment")]
    public Transform tele_second_button;

    [SerializeField]
    [Space]
    [Header("Set location to second environment")]
    public Transform tele_last_button;

    [SerializeField]
    [Space]
    [Header("Teleporter collider script reference")]
    public TeleporterColliderScript tele_coll;

    [SerializeField]
    [Space]
    [Header("Player is in range")]
    private bool inRange;

    void Start()
    {
        currentLoadScene = "None";
        inRange = false;
    }

    
    void Update()
    {
        
    }

    private void setTeleportLocation(string load_scene)
    {
        tele_coll.setCurrentTeleportLocation(load_scene);
    }


    public void OnTeleportEnvOne()
    {
        currentLoadScene = "First level";
        setTeleportLocation(currentLoadScene);
    }

    public void OnTeleportEnvTwo()
    {
        currentLoadScene = "Second level";
        setTeleportLocation(currentLoadScene);
    }

    public void OnTeleportEnvLast()
    {
        currentLoadScene = "Last level";
        setTeleportLocation(currentLoadScene);
    }

    public void OnFirstInteract(InputAction.CallbackContext input)
    {
        

        if (input.started)
        {
            if (inRange)
            {
                OnTeleportEnvOne();
            }

        }

    }

    public void OnSecondInteract(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            if (inRange)
            {
                OnTeleportEnvTwo();
            }

        }

    }

    public void OnLastInteract(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            if (inRange)
            {
                OnTeleportEnvLast();
            }

        }

    }

    public void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "Head")
        {
            inRange = true;
        }
        else if (other.name == "Body")
        {
            inRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.name == "Head")
        {
            inRange = false;
        } 
        else if(other.name == "Body")
        {
            inRange = false;
        }
    }
}
