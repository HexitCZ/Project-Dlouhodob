using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChoose : MonoBehaviour
{
    public GameObject[] chooseObject;

    private void Start()
    {
        Check();   
    }

    public void Check()
    {
        bool laser = GameProgressManager.instance.GetEventProgress("BulletUpgrades", "Laser");
        bool electric = GameProgressManager.instance.GetEventProgress("BulletUpgrades", "Electro");

        for (int i = 0; i < chooseObject.Length; i++)
        {
            if (laser)
            {
                chooseObject[i].transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                chooseObject[i].transform.GetChild(1).gameObject.SetActive(false);

            }


            if (electric)
            {
                chooseObject[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                chooseObject[i].transform.GetChild(2).gameObject.SetActive(false);

            }
        }


    }
    

}
