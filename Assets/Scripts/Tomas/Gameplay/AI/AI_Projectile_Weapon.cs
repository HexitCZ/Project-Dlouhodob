using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Projectile_Weapon : MonoBehaviour
{
    [Header("Spawning Settings")]
    public GameObject spawnPoint;
    public float cooldown;
    [Space]
    [Header("Projectile Properties")]
    public GameObject bulletPrefab;
    public BulletObject bulletObject;

    
    //[Header("Orientation Options")]
    private bool canShoot = true;


    
    private void Start()
    {
        canShoot = true;
    }

    public void Shoot(Vector3 direction)
    {
        //Instantiate
        //Set bullet object
        if (canShoot)
        {
            canShoot = false;

            GameObject bulletTemp = Instantiate(bulletPrefab, spawnPoint.transform.position, Quaternion.identity);
            Bullet bullet = bulletTemp.GetComponent<Bullet>();
            bullet.bulletObject = bulletObject;
            bullet.Setup(-(spawnPoint.transform.position - direction).normalized);
            Destroy(bulletTemp, 5);

            Invoke("Cooldown", cooldown);
        }

    }
    public void Cooldown()
    {
        canShoot = true;
    }

    
}
