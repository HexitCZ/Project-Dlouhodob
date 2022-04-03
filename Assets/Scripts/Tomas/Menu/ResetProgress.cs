using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProgress : MonoBehaviour
{
    public void OnResetProgress()
    {
        PlayerPrefs.SetInt("upgrades", 0);
        PlayerPrefs.SetInt("progress", 0);
        PlayerPrefs.SetInt("level", 0);
        PlayerPrefs.SetInt("xp", 0);
        PlayerPrefs.SetInt("bolts", 0);
        PlayerPrefs.SetInt("upgradePoints", 0);



        PlayerPrefs.SetInt("ammo1", 0);
        PlayerPrefs.SetInt("ammo2", 0);
        PlayerPrefs.SetInt("ammo3", 0);
        PlayerPrefs.SetInt("endgame", 0);


        PlayerPrefs.Save();
    }
}