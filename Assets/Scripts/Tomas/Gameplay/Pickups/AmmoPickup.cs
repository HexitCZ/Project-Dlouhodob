using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : PickupBase
{

    public int ammoAmount;
    public int ammoIndex;

    public bool currentlyHeldWeaponAmmo;

    protected override void Action()
    {
        if (currentlyHeldWeaponAmmo)
        {
            WeaponController.instance.ammoData.ammoList[WeaponController.instance.currentWeapon.ammoIndex].bullets_left += ammoAmount;
        }
        else
        {
            WeaponController.instance.ammoData.ammoList[ammoIndex].bullets_left += ammoAmount;
        }
    }

}
