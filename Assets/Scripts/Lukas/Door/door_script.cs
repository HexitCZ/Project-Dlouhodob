using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;

[Serializable]
public class Invoker : UnityEvent<string>
{
    
}

public class door_script : MonoBehaviour
{
    private string press;
    [Space]
    [Header("Referenced scripts")]
    public ui_script ui_s;

    /*[Space]
    [Header("Bools")]
    private bool open;
    private bool broken;
    private bool needsKey;*/

    [Space]
    [Header("Invokers")]
    public Invoker openInvoker;
    public Invoker closeInvoker;

    [Space]
    [Header("Animator")]
    public Animator doorAnimator;

    void Start()
    {
        openInvoker = new Invoker();
        openInvoker.AddListener(ui_s.view_press);
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //invoker.AddListener()
        //openInvoker.Invoke();
        doorAnimator.SetBool("open", true);
        openInvoker.Invoke("E");
    }

    public void OnTriggerExit(Collider other)
    {
        //closeInvoker.Invoke();
        doorAnimator.SetBool("open", false);
    }
}
