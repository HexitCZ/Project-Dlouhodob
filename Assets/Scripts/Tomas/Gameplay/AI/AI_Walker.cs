using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AI_Walker : AI_Base
{
    
    public float slowDownSpeed;
    public float slowDownLength;
    private new float startSpeed;
    private bool isSlowed;
    public float distanceTreshold;
    private WeaponController playerWeapon;
    public GameObject explosionVFX;
    [Space]
    public int xpGain;
    public int currencyGain;

    public float heatCapacity;
    private float currentHeat;

    public GameObject[] engines;

    private AudioSource source;

    private new void Start()
    {
        source = GetComponent<AudioSource>();

        playerWeapon = WeaponController.instance;

        base.Start();
        
        startSpeed = navmesh.speed;
    }

    

    protected override void SetDestination(Transform destination)
    {
        base.SetDestination(destination);
    }


    public override void GetHit()
    {
        //Debug.Log("enemy hit " + gameObject.name);
        health -= playerWeapon.currentWeapon.damage * playerWeapon.currentBullet.physicalDamageMultiplier * playerWeapon.overchargeMultiplier;
        currentHeat += playerWeapon.currentWeapon.damage * playerWeapon.currentBullet.heatDamageMultiplier;

        if (currentHeat >= heatCapacity)
        {
            Death();
        }

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
        weapon.Shoot(target.position);
    }

    private bool died = false;

    protected override void Death()
    {
        if (!died)
        {
            source.Play();
            navmesh.enabled = false;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(-targetDirection * 10, ForceMode.Impulse);
            //gameObject.SetActive(false);
            GameObject vfx = Instantiate(explosionVFX, GetComponent<BoxCollider>().center, Quaternion.identity);
            vfx.GetComponent<VisualEffect>().Play();
            Destroy(vfx, 2);

            ExperienceSystem.instance.Add(xpGain);
            PlayerCurrency.instance.Add(currencyGain);

            for (int i = 0; i < engines.Length; i++)
            {
                engines[i].SetActive(false);
            }

            Invoke("Disable", 5);

            died = true;

            this.enabled = false;

        }
    }

    private void Disable()
    {
        this.gameObject.SetActive(false);
    }

}
