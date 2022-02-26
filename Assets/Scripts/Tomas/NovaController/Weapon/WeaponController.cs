using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.VFX;

public class WeaponController : MonoBehaviour
{

    public AmmoData ammoData;

    public GameObject weaponRenderer;
    
    public WeaponObject weapon;

    public bool animate;

    public bool shootWhileRunning;
    public bool reloadWhileRunning;

    private BodyData bodyData;

    public AnimatorOverrideController animatorOverride;

    public HitEvent[] hitEvents;

    public VisualEffect muzzleFlashObject;

    [Space]
    private bool shoot;
    private double shoot_charge;
    private bool shooting;
    private bool reloading;
    private RaycastHit hit;
    private Transform source;

    [Space]
    private bool reload;
    
    [Space]
    private AmmoData.AmmoPack ammoPack;

    private MeshFilter meshFilter;
    private Animator animator;
    private AudioSource audioSource;

    private bool readyToShoot = true;
    //private bool shooting;

    private void Awake()
    {
        animator = weaponRenderer.GetComponent<Animator>();
        animator.runtimeAnimatorController = animatorOverride;
        meshFilter = weaponRenderer.GetComponent<MeshFilter>();
        audioSource = GetComponent<AudioSource>();
        source = weaponRenderer.transform.parent.transform;
        ammoPack = GetAmmoPack();

        muzzleFlashObject.visualEffectAsset = weapon.muzzleFlash;

        if (animate)
        {
            bodyData = GetComponent<BodyData>();
        }
    }

    private void Update()
    {
        InputResolver();   
        if (animate)
        {
            AnimationResolver();
        }
    }
    public void SetWeaponObject(WeaponObject newWO)
    {
        weapon = newWO;
    }

    private AmmoData.AmmoPack GetAmmoPack()
    {
        return ammoData.GetAmmoPack(weapon.ammoIndex);
    }


    public void InputResolver()
    {
        if (bodyData.physicState != BodyData.EPhysicState.RUNNING ||
            bodyData.physicState == BodyData.EPhysicState.RUNNING && shootWhileRunning)
        {
            if (shoot && readyToShoot && ammoPack.bullets_in_magazine > 0 && !reloading)
            {
                shooting = true;
                if (weapon.fullAuto)
                {
                    Shoot();
                }
                else
                {
                    Shoot();
                    shoot = false;

                }

            }
        }

        //Debug.Log(ammoPack.magazine_size - ammoPack.bullets_in_magazine + " " + (ammoPack.bullets_left >= (ammoPack.magazine_size - ammoPack.bullets_in_magazine)) + " " + !reloading);
        if (bodyData.physicState != BodyData.EPhysicState.RUNNING ||
            bodyData.physicState == BodyData.EPhysicState.RUNNING && reloadWhileRunning)
        {
            if (reload && !reloading && ammoPack.bullets_left >= (ammoPack.magazine_size - ammoPack.bullets_in_magazine))
            {
                Reload();
            }
        }
        
    }

    private void AnimationResolver()
    {
        switch (bodyData.physicState)
        {
            case BodyData.EPhysicState.STANDING:        //IDLE
            case BodyData.EPhysicState.FALLING_SHORT:
            case BodyData.EPhysicState.FALLING_LONG:
                animator.SetBool("Walk", false);
                animator.SetBool("Run", false);
                break;
            case BodyData.EPhysicState.WALKING:         //WALK
                animator.SetBool("Walk", true);
                animator.SetBool("Run", false);
                break;
            case BodyData.EPhysicState.RUNNING:         //RUN
                animator.SetBool("Run", true);
                animator.SetBool("Walk", false);

                if (!reloadWhileRunning)
                {
                    ReloadInterrupted();
                }

                break;
            case BodyData.EPhysicState.CROUCHING:       //IDLE
                animator.SetBool("Walk", false);
                animator.SetBool("Run", false);
                break;
            case BodyData.EPhysicState.LAYING:
                break;
        }


        animator.SetBool("Reload", reloading);

    }
    private void Shoot()
    {
        readyToShoot = false;

        //Debug.Log("shoot");
        
        Vector3 direction = weaponRenderer.transform.forward;

        muzzleFlashObject.Play();

        animator.SetBool("Shoot", true);


        if (Physics.Raycast(source.position, direction, out hit, weapon.range, weapon.whatCanIHit))
        {
            for (int i = 0; i < hitEvents.Length; i++)
            {
                if (hit.transform.gameObject.CompareTag(hitEvents[i].tag))
                {
                    hitEvents[i].events.Invoke();

                }
            }
            GameObject hitEffect = Instantiate(weapon.hitParticle, hit.point, Quaternion.LookRotation(hit.normal,transform.up));
            hitEffect.GetComponent<VisualEffect>().Play();
            hitEffect.transform.SetParent(hit.collider.transform);
            Destroy(hitEffect, 10);
        }
        else
        {
            direction.Scale(Vector3.one * 10);
        }
        ammoPack.bullets_in_magazine--;
        Invoke("ResetShot", weapon.timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
        shooting = false;
        animator.SetBool("Shoot", false);

        UpdateAmmoData();
    }

    private void Reload()
    {
        //Debug.Log("Reloading");
        reloading = true;

        
        Invoke("ReloadFinished", weapon.reloadTime);
    }

    private void ReloadFinished()
    {
        if (reloading)
        {
            ammoPack.bullets_left -= ammoPack.magazine_size - ammoPack.bullets_in_magazine;
            ammoPack.bullets_in_magazine = ammoPack.magazine_size;

            UpdateAmmoData();
        }
        
        reloading = false;

    }

    private void ReloadInterrupted()
    {
        reloading = false;
    }


    private void UpdateAmmoData()
    {
        ammoData.SetAmmoPack(weapon.ammoIndex, ammoPack);
    }

    public void OnShoot(InputAction.CallbackContext press)
    {
        if (press.started)
        {
            shoot = true;
        }
        if (press.canceled)
        {
            shoot = false;
            shoot_charge = press.duration;
        }
    }

    public void OnReload(InputAction.CallbackContext press)
    {
        reload = press.performed;
    }


    [System.Serializable]
    public class HitEvent
    {
        public string tag;
        public UnityEvent events;
    }
}
