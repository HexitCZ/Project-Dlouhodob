using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
    public GameObject fieldHolder;

    public TMP_Text levelPointText;

    private List<GameObject> fields;



    private void OnEnable()
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


        FPSInteractionManager.instance.DisableFPSInteraction(true);
    
        foreach (GameObject g in fields)
        {

            g.GetComponent<Button>().interactable = ExperienceSystem.instance.upgradePoints > 0 && !g.GetComponent<UpgradeField>().bought  ? true : false;

        }
    }

    private void OnDisable()
    {
        FPSInteractionManager.instance.EnableFPSInteraction();

    }

}
