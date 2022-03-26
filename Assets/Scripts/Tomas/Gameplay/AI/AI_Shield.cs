using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Shield : MonoBehaviour, IHittable
{
    public float health;


    public void GetHit()
    {
        health -= WeaponController.instance.currentWeapon.damage * WeaponController.instance.currentBullet.shieldDamageMultiplier;

        if (health <= 0)
        {
            this.transform.parent.gameObject.SetActive(false);
        }
    }

    
}
