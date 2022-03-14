using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(menuName = "Scriptables/Bullet object")]
public class BulletObject : ScriptableObject
{
    [Header("Visual properties")]
    public VisualEffectAsset projectileEffect;
    public VisualEffectAsset hitEffect;
    public float speed;
    [Space]
    [Header("Gameplay properties")]
    public float damage;
    [Space]
    [Header("Splash damage")]
    public bool splash;
    public float splashRange;
    public float splashDamage;
    public AnimationCurve splashDamageFallOff;
}
