using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBase : MonoBehaviour
{

    [SerializeField]
    public string playerTag;

    [SerializeField]
    protected int lifetime;

    private AudioSource pickupSound;


    private void Start()
    {
        pickupSound = GetComponent<AudioSource>();    

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
            if (!pickupSound.isPlaying)
            {
                pickupSound.enabled = true;
                pickupSound.Play();

            }
            if (pickupSound.clip == null)
            {
                Debug.LogWarning("NOSOUND");
            }
            Action();
            transform.Translate(1000, 0, 0);
            Destroy(this.gameObject, 5);
        }
    }
}
