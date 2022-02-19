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
    [SerializeField]
    private bool inRange;

    [Space]
    [Header("Invokers")]
    public UnityEvent openInvoker;
    public UnityEvent closeInvoker;
    public UnityEvent brokenInvoker;

    [Space]
    [Header("Animator")]
    public Animator doorAnimator;

    void Start()
    {
        //openInvoker = new UnityEvent();
        //closeInvoker = new UnityEvent();
        if (broken)
        {
            doorAnimator.SetBool("broken", true);
        }
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
        if (broken)
        {
            brokenInvoker.Invoke();
        }
        else if (GetComponent<Renderer>().isVisible)
        {

            openInvoker.Invoke();

        }

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
        open = false;
        closeInvoker.Invoke();

    }
}
