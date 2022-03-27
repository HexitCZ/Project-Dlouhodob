using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class EMPUpgrade : BaseUpgrade
{

    public int radius;

    private bool canPerform = true;
    private FilmGrain grain;

    

    public override void Activate()
    {
        canPerform = false;
        Invoke("Cooldown", cooldown);
        print(this.ToString() + " activated");


        Collider[] cols = Physics.OverlapSphere(transform.GetChild(0).gameObject.transform.position, radius);
        
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].CompareTag("AI"))
            {
                cols[i].GetComponent<AI_Base>().health = 0;
            }

        }

        
        if (post.profile.TryGet<FilmGrain>(out FilmGrain g))
        {
            grain = g;
            grain.intensity.overrideState = true;
            grain.active = true;
            activated = true;
        }
    }

    private void Cooldown()
    {
        canPerform = true;
        icon.color = Color.white;
    }

    private void ResetGrain()
    {
        grain.intensity.value = 0f;
        grain.active = false;
        activated = false;
    }

    protected new void Update()
    {

        base.Update();

        if (activated)
        {
            grain.intensity.value = 1.0f;

            Invoke("ResetGrain", 2f);            
            

        }

    }

    public void OnEMP(InputAction.CallbackContext inp)
    {
        if (inp.performed && canPerform && GameProgressManager.instance.GetEventProgress("PowerUnlocks", "EMPCharge"))
        {

            Activate();
        }
    }


}
