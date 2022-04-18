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

    private List<Transform> orbs;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (orbs.Count > 10)
        {

        }
    }

    void CleanOrbs()
    {
        
        foreach(Transform orb in orbs)
        {
            Destroy(orb);
        }
        
    }

    void AddForce()
    {
        orb_instance.GetComponent<Rigidbody>().AddForce(target.position - transform.position * speed);
    }

    public void Shoot()
    {
        try
        {
            orb_instance = Instantiate(orb, original_orb.position, Quaternion.identity);
            orb_instance.gameObject.SetActive(true);
            orb_instance.GetComponent<Rigidbody>().useGravity = false;
            AddForce();
        }
        catch (UnassignedReferenceException)
        {
            speed = 0.0f;
        }
    }
}
