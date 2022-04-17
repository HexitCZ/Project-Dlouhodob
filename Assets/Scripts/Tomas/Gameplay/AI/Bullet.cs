using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Bullet : MonoBehaviour
{
    public BulletObject bulletObject;
    [Header("Visual properties")]
    public VisualEffectAsset projectileEffect;
    public VisualEffectAsset hitEffect;
    public float speed;
    public Vector3 direction;
    [Space]
    [Header("Gameplay properties")]
    public float damage;

    //There was a plan for splash damage.
    /*[Space]
    [Header("Splash damage")]
    public bool splash;
    public float splashRange;
    public float splashDamage;
    public AnimationCurve splashDamageFallOff;*/

    /// <summary>
    /// Sets up a new bullet by setting needed settings.
    /// Movement, direction, rotation and damage.
    /// </summary>
    /// <param name="dir"></param>
    public void Setup(Vector3 dir)
    {
        transform.rotation = Quaternion.LookRotation(dir, transform.up);
        speed = bulletObject.speed;
        direction = dir;
        damage = bulletObject.damage;
        //Set vfx
        //start projectile vfx
    }
    public void Update()
    {
        transform.position += direction * speed * Time.deltaTime; 
    }

    /// <summary>
    /// If it hits a player. It deals damage. It destroys itself.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthController.instance.GetHit(damage);
        }
        Destroy(gameObject);
    }

}
