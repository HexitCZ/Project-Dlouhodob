using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI_script : MonoBehaviour
{
    [Space]
    [Header("Canvas")]
    public Text pressText;

    private bool open; 

    void Start()
    {
        open = false;  
    }

    void Update()
    {
       
    }
    
    public void view_press_e()
    {
        pressText.text = "Press E";
    }
    
    public void view_none()
    {
        pressText.text = "";
    }

    public void view_broken()
    {
        try
        {

        
        pressText.text = "The door is broken";
        pressText.color = Color.red;

        }
        catch (UnassignedReferenceException)
        {

        }
    }

    public bool GetInput()
    {
        return open;
    }

    public void OnInteract(InputAction.CallbackContext input)
    {
        if (input.started)
        {

            open = true;

        }

    }

    public void ResetOpen()
    {
        open = false;
    }
    
}
