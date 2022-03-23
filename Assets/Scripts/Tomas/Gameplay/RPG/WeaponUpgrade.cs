using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    public GameObject[] upgradedWeapons;


    public void UpgradePistol()
    {
        WeaponController.instance.weapons[3].mesh = upgradedWeapons[3];
    }

    public void UpgradeMG()
    {
        WeaponController.instance.weapons[3].mesh = upgradedWeapons[1];

    }
    public void UpgradeAR()
    {
        WeaponController.instance.weapons[3].mesh = upgradedWeapons[0];

    }

    public void UpgradeSP()
    {
        WeaponController.instance.weapons[3].mesh = upgradedWeapons[2];

    }

}
