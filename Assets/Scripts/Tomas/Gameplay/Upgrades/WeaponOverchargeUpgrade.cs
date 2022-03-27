using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class WeaponOverchargeUpgrade : BaseUpgrade
{
    public int length;

    public int damageMultiplier;

    private bool canPerform = true;
    private ColorAdjustments color;



    public override void Activate()
    {
        canPerform = false;
        Invoke("Cooldown", cooldown);

        WeaponController.instance.overchargeMultiplier = damageMultiplier;
        print(this.ToString() + " activated");


        Invoke("ResetDamage", length);


        if (post.profile.TryGet<ColorAdjustments>(out ColorAdjustments g))
        {
            color = g;
            color.active = true;
            activated = true;
            Invoke("ResetColor", 2f);
        }
    }

    private void ResetDamage()
    {
        WeaponController.instance.overchargeMultiplier = 1.0f;
    }

    private void Cooldown()
    {
        canPerform = true;
    }

    private void ResetColor()
    {
        color.active = false;
        activated = false;

    }

    protected new void Update()
    {

        base.Update();

        

    }

    public void OnEMP(InputAction.CallbackContext inp)
    {
        if (inp.performed && canPerform && GameProgressManager.instance.GetEventProgress("PowerUnlocks", "WeaponOvercharge"))
        {

            Activate();
        }
    }
}
