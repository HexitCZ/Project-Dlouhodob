using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Walker : AI_Base
{
    
    public float slowDownSpeed;
    public float slowDownLength;
    private float startSpeed;
    private bool isSlowed;
    public float distanceTreshold;
    private WeaponController playerWeapon;
    private new void Start()
    {
        playerWeapon = WeaponController.instance;

        base.Start();
        
        startSpeed = navmesh.speed;
    }

    

    protected override void SetDestination(Transform destination)
    {
        base.SetDestination(destination);
    }

    protected override bool CheckHealth()
    {
        

        if (health > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public override void GetHit()
    {
        //Debug.Log("enemy hit " + gameObject.name);
        health -= playerWeapon.weapon.damage;
        TrySlowDown();
    }

    private void TrySlowDown()
    {
        
        if (!isSlowed)
        {
            CancelInvoke("ResetSpeed");
            isSlowed = true;
            Invoke("ResetSpeed", slowDownLength);
            navmesh.speed = slowDownSpeed;
        }
    }

    private void ResetSpeed()
    {
        isSlowed = false;
        navmesh.speed = startSpeed;
    }



    protected override bool CheckVisibility()
    {
        if (Physics.Raycast(gameObject.transform.position, targetDirection, out RaycastHit hit, range))
        {
            if (hit.collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    protected override bool CheckRange()
    {
        if(targetDistance < range)
        {
            
            return true;

        }
        else
        {
            return false;
        }
    }

    protected override void Attack()
    {
        weapon.Shoot(targetDirection);
    }

    protected override void Death()
    {

        Debug.Log("Death");
        gameObject.SetActive(false);


    }
}
