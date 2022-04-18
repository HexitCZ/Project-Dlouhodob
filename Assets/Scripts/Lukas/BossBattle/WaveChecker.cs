using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveChecker : MonoBehaviour
{

    [SerializeField]
    [Space]
    private int wave1_count;

    [SerializeField]
    [Space]
    private int wave2_count;

    [SerializeField]
    [Space]
    private int wave3_count;

    [SerializeField]
    [Space]
    private int wave4_count;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public bool Wave1Complete(Transform h1, Transform h2, Transform d1, Transform d2)
    {

        bool output = false;
        int destroyed_count = 0;

        Rigidbody rb1 = h1.GetComponent<Rigidbody>();
        Rigidbody rb2 = h2.GetComponent<Rigidbody>();
        Rigidbody rb3 = d1.GetComponent<Rigidbody>();
        Rigidbody rb4 = d2.GetComponent<Rigidbody>();


        if (!rb1.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb2.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb3.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb4.isKinematic)
        {
            destroyed_count++;
        }

        if (destroyed_count == wave1_count)
        {
            output = true;
        }
        else
        {
            output = false;
        }

        return output;
    }

    public bool Wave2Complete(Transform h3, Transform h4, Transform h5, Transform d3, Transform d4, Transform d5)
    {
        bool output = false;
        int destroyed_count = 0;

        Rigidbody rb1 = h3.GetComponent<Rigidbody>();
        Rigidbody rb2 = h4.GetComponent<Rigidbody>();
        Rigidbody rb3 = h5.GetComponent<Rigidbody>();
        Rigidbody rb4 = d3.GetComponent<Rigidbody>();
        Rigidbody rb5 = d4.GetComponent<Rigidbody>();
        Rigidbody rb6 = d5.GetComponent<Rigidbody>();


        if (!rb1.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb2.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb3.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb4.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb5.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb6.isKinematic)
        {
            destroyed_count++;
        }

        if (destroyed_count == wave2_count)
        {
            output = true;
        }
        else
        {
            output = false;
        }

        return output;
    }

    public bool Wave3Complete(Transform h6, Transform h7, Transform h8, Transform h9, Transform d6, Transform d7, Transform d8, Transform d9)
    {
        bool output = false;
        int destroyed_count = 0;

        Rigidbody rb1 = h6.GetComponent<Rigidbody>();
        Rigidbody rb2 = h7.GetComponent<Rigidbody>();
        Rigidbody rb3 = h8.GetComponent<Rigidbody>();
        Rigidbody rb4 = h9.GetComponent<Rigidbody>();
        Rigidbody rb5 = d6.GetComponent<Rigidbody>();
        Rigidbody rb6 = d7.GetComponent<Rigidbody>();
        Rigidbody rb7 = d8.GetComponent<Rigidbody>();
        Rigidbody rb8 = d9.GetComponent<Rigidbody>();


        if (!rb1.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb2.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb3.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb4.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb5.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb6.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb7.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb8.isKinematic)
        {
            destroyed_count++;
        }

        if (destroyed_count == wave3_count)
        {
            output = true;
        }
        else
        {
            output = false;
        }

        return output;
    }

    public bool Wave4Complete(Transform h10, Transform h11, Transform h12, Transform h13, Transform h14, Transform hh, Transform d10, Transform d11, Transform d12, Transform d13, Transform d14)
    {
        bool output = false;
        int destroyed_count = 0;

        Rigidbody rb1 = h10.GetComponent<Rigidbody>();
        Rigidbody rb2 = h11.GetComponent<Rigidbody>();
        Rigidbody rb3 = h12.GetComponent<Rigidbody>();
        Rigidbody rb4 = h13.GetComponent<Rigidbody>();
        Rigidbody rb5 = h14.GetComponent<Rigidbody>();
        Rigidbody rb6 = hh.GetComponent<Rigidbody>();
        Rigidbody rb7 = d10.GetComponent<Rigidbody>();
        Rigidbody rb8 = d11.GetComponent<Rigidbody>();
        Rigidbody rb9 = d12.GetComponent<Rigidbody>();
        Rigidbody rb10 = d13.GetComponent<Rigidbody>();
        Rigidbody rb11 = d14.GetComponent<Rigidbody>();


        if (!rb1.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb2.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb3.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb4.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb5.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb6.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb7.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb8.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb9.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb10.isKinematic)
        {
            destroyed_count++;
        }

        if (!rb11.isKinematic)
        {
            destroyed_count++;
        }

        if (destroyed_count == wave3_count)
        {
            output = true;
        }
        else
        {
            output = false;
        }

        return output;
    }
}
