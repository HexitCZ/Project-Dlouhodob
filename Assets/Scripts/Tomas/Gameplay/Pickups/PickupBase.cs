using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBase : MonoBehaviour
{

    [SerializeField]
    public string playerTag;

    [SerializeField]
    protected int lifetime;


    private void Start()
    {
        if (lifetime != 0)
        {
            Destroy(this.gameObject, lifetime);
        }
    }

   

    protected virtual void Action()
    {
        
    }


    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            Action();
            Destroy(this.gameObject);
        }
    }
}
