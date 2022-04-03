using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class UpgradeUI : MonoBehaviour
{
    public GameObject fieldHolder;

    //public TMP_Text levelPointText;

    private List<GameObject> fields;

    private void Start()
    {
        fields = new List<GameObject>();

        GameObject temp;

        for (int i = 0; i < fieldHolder.transform.childCount; i++)
        {
            temp = fieldHolder.transform.GetChild(i).gameObject;

            if (temp.GetComponent<Button>() != null)
            {
                fields.Add(temp);
            }
        }

        Debug.LogWarning(fields.Count);

        Enable();
        Disable();
        

    }

    public void Enable()
    {
        FPSInteractionManager.instance.DisableFPSInteraction(true);
        foreach (GameObject g in fields)
        {
            UpgradeField ug = g.GetComponent<UpgradeField>();
            ug.bought = GameProgressManager.instance.GetEventProgress(ug.upgradeCategoryName, ug.upgradeName);
            g.GetComponent<Button>().interactable = ExperienceSystem.instance.upgradePoints > 0 && !ug.bought ? true : false;

        }


    }

    public void Disable()
    {

        FPSInteractionManager.instance.EnableFPSInteraction();
    }

}
