using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    public WeaponObject[] upgradedWeapons;

    private void FixedUpdate()
    {
        if (GameProgressManager.instance.upgrades[0].progressEvents[3].finished)
        {
            UpgradePistol();
        }

        if (GameProgressManager.instance.upgrades[0].progressEvents[4].finished)
        {
            UpgradeAR();
        }
        if (GameProgressManager.instance.upgrades[0].progressEvents[5].finished)
        {
            UpgradeMG();
        }
        if (GameProgressManager.instance.upgrades[0].progressEvents[6].finished)
        {
            UpgradeSP();
        }
        
        
    }

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
