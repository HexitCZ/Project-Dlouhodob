using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeField : MonoBehaviour
{
    public string fieldName;
    public string description;
    public Sprite icon;
    public string upgradeCategoryName;
    public string upgradeName;

    private TMP_Text text; 

    public bool bought;

    private void Start()
    {
        text = transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        text.text = fieldName;
    }

    public void TryUpgrade()
    {
        if (ExperienceSystem.instance.TryPayLevelPoint())
        {
            bought = true;
            GetComponent<Button>().interactable = false;
            print(upgradeCategoryName + "       " + upgradeName);
            GameProgressManager.instance.FinishEventProgress(upgradeCategoryName, upgradeName);
        }
    }

}
