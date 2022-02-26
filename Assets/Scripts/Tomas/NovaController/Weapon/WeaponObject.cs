using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(menuName = "Weapon object")]
public class WeaponObject : ScriptableObject
{
    [Header("Properties")]
    public string gunName;
    [Multiline]
    public string description;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
    public int ammoIndex;
    [Space]
    [Header("Settings")]
    public int damage;
    public float range;
    public float bulletSpread;
    public int bulletsPerTap;
    public float timeBetweenShots;
    //public float reloadTime;
    public int magazineSize;
    public bool fullAuto;
    public LayerMask whatCanIHit;
    public float reloadTime;
    [Space]
    [Header("Assets")]
    public Mesh mesh;
    public Material[] materials;
    public AnimatorOverrideController weaponAnimator;
    public VisualEffectAsset muzzleFlash;
    [Tooltip("Prefab with VisualEffect component")]
    public GameObject hitParticle;
    
}
