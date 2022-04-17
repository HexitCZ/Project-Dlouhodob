using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{
    [SerializeField]
    [Space]
    private Transform target;

    private Rigidbody rb;

    [SerializeField]
    [Space]
    [Range(0.0f, 100.0f)]
    private float orb_speed = 10.0f;

    //private float constant_orb_speed = 10.0f;
#pragma warning disable IDE0052
    private int partIndex;
#pragma warning restore IDE0052
    public OrbScript(int partIndex)
    {
        this.partIndex = partIndex;
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        AddRandomForceToOrb();
    }

    void Update()
    {
         
    }

    public void OnCollisionEnter(Collision collision)
    {   
        if(collision.transform.name == "Body")
        {
            PlayerHealthController.instance.GetHit(5.0f);
        } 
        else if(collision.transform.name == "Head")
        {
            PlayerHealthController.instance.GetHit(5.0f);
        }
        else if (collision.transform.name == "MidBody")
        {
            PlayerHealthController.instance.GetHit(5.0f);
        }
        if (collision.transform.name == "pillar")
        {
            DestroyOrb();
            collision.transform.GetComponent<PillarScript>().Destruct();
        }
        else if(collision.transform.name == "PillarPiece1")           
        {
            DestroyOrb();
            collision.transform.parent.GetComponent<PillarScript>().Destruct();
            partIndex = 0;
        }
        else if (collision.transform.name == "PillarPiece2")
        {
            DestroyOrb();
            collision.transform.parent.GetComponent<PillarScript>().Destruct();
            partIndex = 1;
        }
        else if (collision.transform.name == "PillarPiece3")
        {
            DestroyOrb();
            collision.transform.parent.GetComponent<PillarScript>().Destruct();
            partIndex = 2;
        }
        else if (collision.transform.name == "orb")
        {
            DestroyOrb();
            collision.transform.parent.GetComponent<PillarScript>().Destruct();
            partIndex = 3;
        }
        else if (collision.transform.name == "orb_broken")
        {
            DestroyOrb();
            collision.transform.parent.GetComponent<PillarScript>().Destruct();
            partIndex = 4;
        }
        else
        {
            AddRandomForceToOrb();
        }
    }

    private void DestroyOrb()
    {
        Destroy(this);
    }

    void AddRandomForceToOrb()
    {
        float x_value = Random.Range(0, 100);
        float y_value = Random.Range(0, 100);
        float z_value = Random.Range(0, 100);

        if (x_value < 5.0f)
        {
            x_value *= orb_speed;
        }
        else if (y_value < 5.0f)
        {
            y_value *= orb_speed;
        }
        else if (z_value < 5.0f)
        {
            z_value *= orb_speed;
        }
        Vector3 forceToAdd = new Vector3(x_value, y_value, z_value);

        Debug.Log(forceToAdd);
        rb.AddForce(Vector3.Reflect(transform.position, Vector3.right));
    }
}
