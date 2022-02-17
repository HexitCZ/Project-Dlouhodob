using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public GameObject otherCube;
    public Vector3 thisRotation;
    public Vector3 otherRotation;

    public float angle;
    public float myAngle;
    public float myAngleInverse;
    public float myAngleAbs;


    public void Update()
    {
        thisRotation = transform.rotation.eulerAngles;
        thisRotation.x += 360;
        thisRotation.y += 360;
        thisRotation.z += 360;
        otherRotation = otherCube.transform.rotation.eulerAngles;
        otherRotation.x += 360;
        otherRotation.y += 360;
        otherRotation.z += 360;
        angle = Quaternion.Angle(Quaternion.Euler(thisRotation), Quaternion.Euler(otherRotation));
        myAngle = otherRotation.y - thisRotation.y; 
        myAngleInverse = thisRotation.y - otherRotation.y; 
        myAngleAbs = Mathf.Abs(thisRotation.y - otherRotation.y); 
    }

}
