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
    /*[Space]
    [Header("Splash damage")]
    public bool splash;
    public float splashRange;
    public float splashDamage;
    public AnimationCurve splashDamageFallOff;*/
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthController.instance.GetHit(damage);
        }
        Destroy(gameObject);
    }

}
