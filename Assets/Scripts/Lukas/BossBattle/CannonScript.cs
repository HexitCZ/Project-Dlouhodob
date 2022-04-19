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

    private int numberOfOrbs;

    private List<Transform> orbs;
    void Start()
    {
        orbs = new List<Transform>();
    }
    
    void Update()
    {
        if (orbs != null)
        {
            int numberOfOrbs = orbs.Count;
        }

        if (numberOfOrbs > 0)
        {
            if (numberOfOrbs > 10)
            {
                CleanOrbs();
                numberOfOrbs = 0;
            }
        }
    }
    /// <summary>
    /// Zbavi se orbu
    /// </summary>
    void CleanOrbs()
    {
        foreach(Transform orb in orbs)
        {
            Destroy(orb);
        }
        
    }
    /// <summary>
    /// Prida force pro pohyb telesa
    /// </summary>
    void AddForce()
    {
        orb_instance.GetComponent<Rigidbody>().AddForce((target.position - transform.position) * speed);
    }

    /// <summary>
    /// Kanon vystreli orb(projektil)
    /// </summary>
    public void Shoot()
    {
        try
        {
            orb_instance = Instantiate(orb, original_orb.position, Quaternion.identity);
            orb_instance.gameObject.SetActive(true);
            orb_instance.GetComponent<Rigidbody>().useGravity = false;
            AddForce();

            orbs.Add(orb_instance);

        }
        catch (UnassignedReferenceException)
        {
            speed = 0.0f;
        }
    }
}
