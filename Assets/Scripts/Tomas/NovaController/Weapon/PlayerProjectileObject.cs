using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(menuName = "Scriptables/Player projectile object")]
public class PlayerProjectileObject : ScriptableObject
{
    [Header("Visual properties")]
    public VisualEffectAsset muzzleFlashEffect;
    public GameObject hitEffect;
    [Space]
    [Header("Gameplay properties")]
    [Tooltip("Damage that affects shields the most")]
    public float shieldDamageMultiplier;
    [Tooltip("Damage that affects enemies with low heat resistance the most")]
    public float heatDamageMultiplier;
    [Tooltip("Damage that affects all enemies the same.")]
    public float physicalDamageMultiplier;

    public string type;

}
