using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChoose : MonoBehaviour
{
    public GameObject[] chooseObject;
    public PlayerProjectileObject[] bullets;
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
    public void PiP()
    {
        WeaponController.instance.bullets[3] = bullets[0];
    }
    public void PiL()
    {
        WeaponController.instance.bullets[3] = bullets[1];

    }
    public void PiE()
    {
        WeaponController.instance.bullets[3] = bullets[2];

    }


    public void ARP()
    {
        WeaponController.instance.bullets[0] = bullets[0];

    }
    public void ARL()
    {
        WeaponController.instance.bullets[0] = bullets[1];

    }
    public void ARE()
    {
        WeaponController.instance.bullets[0] = bullets[2];

    }

    public void MGP()
    {
        WeaponController.instance.bullets[1] = bullets[0];

    }
    public void MGL()
    {
        WeaponController.instance.bullets[0] = bullets[1];
    }
    public void MGE()
    {
        WeaponController.instance.bullets[0] = bullets[2];
    }

    public void SPP()
    {
        WeaponController.instance.bullets[2] = bullets[0];

    }
    public void SPL()
    {
        WeaponController.instance.bullets[0] = bullets[1];
    }
    public void SPE()
    {
        WeaponController.instance.bullets[0] = bullets[2];
    }


}
