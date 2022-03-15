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
    private int lastScrollFrame; 


    private Quaternion baseRotation = Quaternion.Euler(0, 0, 0);
    private Quaternion changeRotation = Quaternion.Euler(30, -43, 1);


    void Start()
    {
        weaponController = WeaponController.instance;
        
    }

    private void UpdateScrollIndex(bool add)
    {
        maxScrollIndex = weaponController.weapons.Length-1;
        
        scrollIndex += add ? 1 : -1;
        if (scrollIndex > maxScrollIndex)
        {
            scrollIndex = 0;
        }
        else if(scrollIndex < 0)
        {
            scrollIndex = maxScrollIndex;
        }
        CheckWithProgress(add);
        changingWeapon = 1;
    }
    private void CheckWithProgress(bool add)
    {
        bool ar = GameProgressManager.instance.GetEventProgress("WeaponUnlocks", "UnlockAR");
        bool mg = GameProgressManager.instance.GetEventProgress("WeaponUnlocks", "UnlockMG");
        bool sp = GameProgressManager.instance.GetEventProgress("WeaponUnlocks", "UnlockSP");
        
        
        switch (scrollIndex)
        {
            case 0:
                if (ar)
                {
                    Debug.Log("assaultrifle");
                    return;
                }
                //Debug.Log("ar false");
                break;
            case 1:
                if (mg)
                {
                    Debug.Log("machinegun");
                    return;
                }
                //Debug.Log("mg false");
                break;
            case 2:
                if (sp)
                {
                    
                    Debug.Log("sniper");
                    return;
                }
                //Debug.Log("sp false");
                break;
            case 3: //          pistol is always enabled
                Debug.Log("pistol");
                return; ;
        }
        
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
            Debug.Log("badabum " + scrollIndex);
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
        weaponController.currentBullet = weaponController.bullets[index];
    }

    public void OnScroll(InputAction.CallbackContext scroll)
    {
        float s = scroll.ReadValue<float>();
        Debug.Log(s);
        if (lastScrollFrame != Time.frameCount)
        {
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

            lastScrollFrame = Time.frameCount;
        }
    }

}
