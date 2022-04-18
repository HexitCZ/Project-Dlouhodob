using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public int SpawnPhase1(Transform h1, Transform h2, Transform d1, Transform d2)
    {
        int output = 1;
        
        try
        {
            h1.gameObject.SetActive(true);
            h2.gameObject.SetActive(true);

            d1.gameObject.SetActive(true);
            d2.gameObject.SetActive(true);
        }
        catch (UnassignedReferenceException)
        {
            output = 0;
        }

        return output;
    }

    public int SpawnPhase2(Transform h3, Transform h4, Transform h5, Transform d3, Transform d4, Transform d5)
    {
        int output = 2;
        
        try
        {
            h3.gameObject.SetActive(true);
            h4.gameObject.SetActive(true);
            h5.gameObject.SetActive(true);

            d3.gameObject.SetActive(true);
            d4.gameObject.SetActive(true);
            d5.gameObject.SetActive(true);
        }
        catch (UnassignedReferenceException)
        {
            output = 0;
        }
        return output;

    }

    public int SpawnPhase3(Transform h6, Transform h7, Transform h8, Transform h9, Transform d6, Transform d7, Transform d8, Transform d9)
    {
        int output = 0;
        
        try
        {
            h6.gameObject.SetActive(true);
            h7.gameObject.SetActive(true);
            h8.gameObject.SetActive(true);
            h9.gameObject.SetActive(true);

            d6.gameObject.SetActive(true);
            d7.gameObject.SetActive(true);
            d8.gameObject.SetActive(true);
            d9.gameObject.SetActive(true);
        }
        catch (UnassignedReferenceException)
        {
            output = 0;
        }
        return output;
    }

    public int SpawnPhase4(Transform h10, Transform h11, Transform h12, Transform h13, Transform h14, Transform hh, Transform d10, Transform d11, Transform d12, Transform d13, Transform d14)
    {
        int output = 0;

        try
        {
            h10.gameObject.SetActive(true);
            h11.gameObject.SetActive(true);
            h12.gameObject.SetActive(true);
            h13.gameObject.SetActive(true);
            h14.gameObject.SetActive(true);

            hh.gameObject.SetActive(true);

            d10.gameObject.SetActive(true);
            d11.gameObject.SetActive(true);
            d12.gameObject.SetActive(true);
            d13.gameObject.SetActive(true);
            d14.gameObject.SetActive(true);
        }
        catch (UnassignedReferenceException)
        {
            output = 0;
        }
        return output;
    }

    
}
