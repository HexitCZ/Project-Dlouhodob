using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public PillarScript[] pillars;


    void Start()
    {
        
    }

    
    void Update()
    {
        Debug.Log(pillars[0].IsBroken());
        Debug.Log(pillars[1].IsBroken());
        Debug.Log(pillars[2].IsBroken());
        Debug.Log(pillars[3].IsBroken());
    }
}
