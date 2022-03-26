using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : PickupBase
{

    public int ammoAmount;
    public int ammoIndex;

    protected override void Action()
    {
        WeaponController.instance.ammoData.ammoList[ammoIndex].bullets_left += ammoAmount;
    }

}
