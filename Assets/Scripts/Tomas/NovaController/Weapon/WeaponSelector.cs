using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSelector : MonoBehaviour
{
    public float weaponChangeSpeed;
    public GameObject weaponHolder;

    private WeaponController weaponController;
    private int scrollIndex;
    private int maxScrollIndex;
    private int changingWeapon;

    private Quaternion baseRotation = Quaternion.Euler(0, 0, 0);
    private Quaternion changeRotation = Quaternion.Euler(30, -43, 1);


    void Start()
    {
        weaponController = WeaponController.instance;
        
    }

    private void UpdateScrollIndex(bool add)
    {
        maxScrollIndex = weaponController.weapons.Length;
        //Debug.Log(maxScrollIndex + " " + scrollIndex + " " + add);
        scrollIndex += add ? 1 : -1;
        if (scrollIndex > maxScrollIndex-1)
        {
            scrollIndex = 0;
        }
        else if(scrollIndex < 0)
        {
            scrollIndex = maxScrollIndex-1;
        }
        CheckWithProgress(add);
        changingWeapon = 1;
    }
    private void CheckWithProgress(bool add)
    {
        bool mg = GameProgressManager.instance.GetEventProgress("WeaponUnlocks", "UnlockMG");
        bool ar = GameProgressManager.instance.GetEventProgress("WeaponUnlocks", "UnlockAR");
        bool sp = GameProgressManager.instance.GetEventProgress("WeaponUnlocks", "UnlockSP");
        
        switch (scrollIndex)
        {
            case 0:
                if (ar)
                {
                    Debug.Log("ar");
                    return;
                }
                break;
            case 1:
                if (mg)
                {
                    Debug.Log("mg");
                    return;
                }
                break;
            case 2:
                if (sp)
                {
                    Debug.Log("sp");
                    return;
                }
                break;
        }
        Debug.Log(scrollIndex + " " + ar + mg + sp);
        UpdateScrollIndex(add);
    }


    private void Update()
    {
        if (changingWeapon == 1)
        {
            weaponHolder.transform.localRotation = Quaternion.Slerp(weaponHolder.transform.localRotation, changeRotation, weaponChangeSpeed);

        }
        else if (changingWeapon == -1)
        {
            weaponHolder.transform.localRotation = Quaternion.Slerp(weaponHolder.transform.localRotation, baseRotation, weaponChangeSpeed);

        }
        if (weaponHolder.transform.localRotation == changeRotation)
        {
            SelectWeapon(scrollIndex);
            changingWeapon = -1;
        }
        else if(weaponHolder.transform.localRotation == baseRotation)
        {
            changingWeapon = 0;
        }

    }


    public void SelectWeapon(int index)
    {
        if(weaponController == null)
        {
            Debug.LogWarning("Weapon controller not found");
            return;
        }
        weaponController.currentWeapon = weaponController.weapons[index];
    }

    public void OnScroll(InputAction.CallbackContext scroll)
    {
        float s = scroll.ReadValue<float>();
        if (s > 0)
        {
            UpdateScrollIndex(true);
            s = 0;
        }
        else if (s < 0)
        {
            UpdateScrollIndex(false);
            s = 0;
        }
    }

}
