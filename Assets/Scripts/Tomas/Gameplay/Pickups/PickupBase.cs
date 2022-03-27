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

        transform.Rotate(0, Random.Range(0,360), 0);

    }

    private void Update()
    {
        transform.Rotate(0, 30 * Time.deltaTime , 0);
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
