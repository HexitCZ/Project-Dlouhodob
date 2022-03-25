using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCyclerScript : MonoBehaviour
{

    [Space]
    [SerializeField]
    [Header("Camera referecne")]
    private Camera cam;

    void Start()
    {
        
    }

    void Update()
    {
        if(cam.clearFlags == CameraClearFlags.SolidColor)
        {

        }
    }
}
