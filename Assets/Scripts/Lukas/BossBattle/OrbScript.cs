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

    [SerializeField]
    [Space]
    private MeshRenderer m_renderer;

    [SerializeField]
    [Space]
    private MeshCollider m_collider;

    //private float constant_orb_speed = 10.0f;
#pragma warning disable IDE0052
    private int partIndex;
#pragma warning restore IDE0052

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //AddRandomForceToOrb();
        //Invoke("DestroyOrb", 10000);
    }

    void Update()
    {
         
    }
    /// <summary>
    /// Interakce s objekty podle toho, na ktery projektil narazil
    /// </summary>
    /// <param name="collision"></param>
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
        else if (collision.transform.name == "orbbab")
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

    /// <summary>
    /// Zniceni projektilu potom, co uz neni uzitecny
    /// </summary>
    private void DestroyOrb()
    {
        m_renderer = this.GetComponent<MeshRenderer>();
        m_renderer.enabled = false;

        m_collider = this.GetComponent<MeshCollider>();
        m_collider.enabled = false;

        Destroy(this.gameObject);
    }

    /// <summary>
    /// Pridani sily k objektu pri odrazu od objektu
    /// </summary>
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
        Vector3 reflectedVector = Vector3.Reflect(transform.position, Vector3.right);
        rb.AddForce(reflectedVector);
    }
}