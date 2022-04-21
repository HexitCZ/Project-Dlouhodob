using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : PickupBase
{
    public WeaponType weaponType;

   

    protected override void Action()
    {
        
        WeaponController.instance.ammoData.ammoList[(int)weaponType].bullets_left += 100;


        switch (weaponType)
        {
            case WeaponType.AssaultRifle:
                GameProgressManager.instance.FinishEventProgress("WeaponUnlocks", "UnlockAR");
                break;
            case WeaponType.MachineGun:
                GameProgressManager.instance.FinishEventProgress("WeaponUnlocks", "UnlockMG");
                break;
            case WeaponType.SniperRifle:
                GameProgressManager.instance.FinishEventProgress("WeaponUnlocks", "UnlockSP");
                break;
            
        }
    }
}

public enum WeaponType
{
    AssaultRifle = 0,
    MachineGun = 1,
    SniperRifle = 2
    
}