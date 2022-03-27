using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : PickupBase
{
    public WeaponType WeaponType;


    protected override void Action()
    {
        switch (WeaponType)
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