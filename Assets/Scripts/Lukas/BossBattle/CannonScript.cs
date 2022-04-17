using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{

    [SerializeField]
    [Space]
    private Transform orb;

    [SerializeField]
    [Space]
    private Transform original_orb;

    private Transform orb_instance;

    [SerializeField]
    [Space]
    private Transform target;

    [SerializeField]
    [Space]
    [Range(0.0f, 100.0f)]
    private float speed = 20.0f;

    void Start()
    {
        Shoot();
    }

    
    void Update()
    {
        
    }

    void AddStartForce()
    {
        orb_instance.GetComponent<Rigidbody>().AddForce(target.position - transform.position * speed);
    }

    public void Shoot()
    {
        orb_instance = Instantiate(orb, original_orb.position, Quaternion.identity);
        orb_instance.gameObject.SetActive(true);
        orb_instance.GetComponent<Rigidbody>().useGravity = false;
        AddStartForce();
    }
}
