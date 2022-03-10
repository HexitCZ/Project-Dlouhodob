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

    public WeaponObject currentWeapon;
    public WeaponObject[] weapons;

    public bool animate;

    public bool shootWhileRunning;
    public bool reloadWhileRunning;

    private BodyData bodyData;

    public HitEvent[] hitEvents;

    public VisualEffect muzzleFlashObject;

    [Space]
    private bool shoot;
    private double shoot_charge;
    private bool shooting;
    private bool reloading;
    private RaycastHit hit;
    private Transform source;
    private int ammoIndex;
    [Space]
    private bool reload;

    [Space]
    private AmmoData.AmmoPack ammoPack;

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private Animator animator;
    private AnimatorOverrideController animatorOverride;
    private AudioSource audioSource;

    private bool readyToShoot = true;

    #region Singleton
    public static WeaponController instance;
    #endregion


    private void Awake()
    {
        instance = this;

        animator = weaponRenderer.GetComponent<Animator>();
        meshFilter = weaponRenderer.GetComponent<MeshFilter>();
        meshRenderer = weaponRenderer.GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        source = weaponRenderer.transform.parent.transform;


        SetWeaponObject(currentWeapon);

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

    private void FixedUpdate()
    {
        if (ammoIndex != currentWeapon.ammoIndex) //PLACEHOLDER, MUST CHANGE <------------------------------------------------------
        {
            Debug.LogWarning(":O weapon has CHANGED");
            SetWeaponObject(currentWeapon);

        }
    }

    public void SetWeaponObject(WeaponObject newWO)
    {
        currentWeapon = newWO;
        meshFilter.mesh = currentWeapon.mesh;
        animator.runtimeAnimatorController = currentWeapon.weaponAnimator;
        meshRenderer.materials = currentWeapon.materials;
        muzzleFlashObject.visualEffectAsset = currentWeapon.muzzleFlash;
        ammoIndex = currentWeapon.ammoIndex;
        ammoPack = GetAmmoPack();
    }

    private AmmoData.AmmoPack GetAmmoPack()
    {
        return ammoData.GetAmmoPack(ammoIndex);
    }

    public void InputResolver()
    {
        if (bodyData.physicState != BodyData.EPhysicState.RUNNING ||
            bodyData.physicState == BodyData.EPhysicState.RUNNING && shootWhileRunning)
        {
            if (shoot && readyToShoot && ammoPack.bullets_in_magazine > 0 && !reloading)
            {
                shooting = true;
                if (currentWeapon.fullAuto)
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


        if (Physics.Raycast(source.position, direction, out hit, currentWeapon.range, currentWeapon.whatCanIHit))
        {
            IHittable ihit = hit.collider.gameObject.GetComponent<IHittable>();
            Debug.Log(hit.transform.gameObject.tag + " ass " + ihit == null);
            if (ihit != null)
            {
                for (int i = 0; i < hitEvents.Length; i++)
                {
                    if (hit.transform.gameObject.CompareTag(hitEvents[i].tag))
                    {
                        print("trying to hit " + hit.collider.gameObject.name);
                        ihit.GetHit();
                        hitEvents[i].events.Invoke();

                    }
                }
            }
            GameObject hitEffect = Instantiate(currentWeapon.hitParticle, hit.point, Quaternion.LookRotation(hit.normal, transform.up));
            hitEffect.GetComponent<VisualEffect>().Play();
            hitEffect.transform.SetParent(hit.collider.transform);
            Destroy(hitEffect, 10);
        }
        else
        {
            direction.Scale(Vector3.one * 10);
        }
        ammoPack.bullets_in_magazine--;
        Invoke("ResetShot", currentWeapon.timeBetweenShots);
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


        Invoke("ReloadFinished", currentWeapon.reloadTime);
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
        ammoData.SetAmmoPack(ammoIndex, ammoPack);
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
