using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine;
using System;

public class door_script : MonoBehaviour
{
    private string press;

    [Space]
    [Header("Bools")]
    [SerializeField]
    private bool open;
    [SerializeField]
    private bool broken;
    [SerializeField]
    private bool needsKey;

    [Space]
    [Header("Invokers")]
    public UnityEvent openInvoker;
    public UnityEvent closeInvoker;

    [Space]
    [Header("Animator")]
    public Animator doorAnimator;

    void Start()
    {
        //openInvoker = new UnityEvent();
        //closeInvoker = new UnityEvent();
    }

    void Update()
    {
        
    }
    public void OnInteract(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            this.open = true;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        openInvoker.Invoke();

        if (needsKey)
        {

            doorAnimator.SetBool("open", true);

        }
        else
        {

            if (open)
            {

                doorAnimator.SetBool("open", true);

            }

        }
    }

    public void OnTriggerExit(Collider other)
    {

        doorAnimator.SetBool("open", false);
        closeInvoker.Invoke();
        open = false;
                
    }
}
