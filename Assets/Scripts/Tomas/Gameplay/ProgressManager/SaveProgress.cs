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
        BitArray b = new BitArray(GameProgressManager.instance.GetAllUpgrades());

        int[] output = new int[1];
        b.CopyTo(output, 0);

        PlayerPrefs.SetInt("upgrades", output[0]);
        
        
        PlayerPrefs.Save();
    }

    public void Load()
    {
        BitArray b = new BitArray(new int[] { PlayerPrefs.GetInt("upgrades") });

        bool[] bools = new bool[b.Count];
        b.CopyTo(bools, 0);

        GameProgressManager.instance.SetAllUpgrades(bools);
    }

    public void Reload()
    {
        PlayerPrefs.SetInt("progress", 0);
        
        
        
        PlayerPrefs.Save();
    }

}
