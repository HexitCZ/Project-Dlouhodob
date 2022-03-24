using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    public WeaponObject[] upgradedWeapons;
    

    public void UpgradePistol()
    {
        WeaponController.instance.weapons[3] = upgradedWeapons[3];
    }

    public void UpgradeMG()
    {
        WeaponController.instance.weapons[1] = upgradedWeapons[1];
    }

    public void UpgradeAR()
    {
        WeaponController.instance.weapons[0] = upgradedWeapons[0];
    }

    public void UpgradeSP()
    {
        WeaponController.instance.weapons[2] = upgradedWeapons[2];
    }

}
