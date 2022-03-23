using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeField : MonoBehaviour
{
    public string fieldName;
    public string description;
    public Sprite icon;
    public string upgradeCategoryName;
    public string upgradeName;

    public bool bought;


    public void TryUpgrade()
    {
        if (ExperienceSystem.instance.TryPayLevelPoint())
        {
            bought = true;
            GameProgressManager.instance.FinishEventProgress(upgradeCategoryName, upgradeName);
            GetComponent<Button>().interactable = false;
        }
    }

}
