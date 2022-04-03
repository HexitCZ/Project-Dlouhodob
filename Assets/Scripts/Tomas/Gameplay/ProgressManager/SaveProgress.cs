using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    public static SaveProgress instance;

    private void Start()
    {
        instance = this;
        
    }

    public void Save()
    {
        Debug.LogWarning("Saved");

        BitArray b = new BitArray(GameProgressManager.instance.GetAllUpgrades());

        int[] output = new int[1];
        b.CopyTo(output, 0);

        PlayerPrefs.SetInt("upgrades", output[0]);
        PlayerPrefs.SetInt("level", ExperienceSystem.instance.level);
        PlayerPrefs.SetInt("xp", ExperienceSystem.instance.xp);
        PlayerPrefs.SetInt("bolts", PlayerCurrency.instance.amount);
        PlayerPrefs.SetInt("upgradePoints", ExperienceSystem.instance.upgradePoints);
        
        
        PlayerPrefs.SetInt("ammo1", WeaponController.instance.ammoData.ammoList[0].bullets_left);
        PlayerPrefs.SetInt("ammo2", WeaponController.instance.ammoData.ammoList[1].bullets_left);
        PlayerPrefs.SetInt("ammo3", WeaponController.instance.ammoData.ammoList[2].bullets_left);
        
        PlayerPrefs.Save();
    }

    public void Load()
    {
        Debug.LogWarning("Loaded");

        BitArray b = new BitArray(new int[] { PlayerPrefs.GetInt("upgrades") });

        bool[] bools = new bool[b.Count];
        b.CopyTo(bools, 0);

        GameProgressManager.instance.SetAllUpgrades(bools);

        ExperienceSystem.instance.level = PlayerPrefs.GetInt("level");
        ExperienceSystem.instance.xp = PlayerPrefs.GetInt("xp");
        PlayerCurrency.instance.amount = PlayerPrefs.GetInt("bolts");
        ExperienceSystem.instance.upgradePoints = PlayerPrefs.GetInt("upgradePoints");

        WeaponController.instance.ammoData.ammoList[0].bullets_left = PlayerPrefs.GetInt("ammo1");
        WeaponController.instance.ammoData.ammoList[1].bullets_left = PlayerPrefs.GetInt("ammo2");
        WeaponController.instance.ammoData.ammoList[2].bullets_left = PlayerPrefs.GetInt("ammo3");

    }


}
