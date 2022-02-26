using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_Data : MonoBehaviour
{
    [Header("IK paramateres")]
    public int ikIterations = 10;

    [Header("Leg configuration")]
    public IK_Leg[] legs;

}

[System.Serializable]
public class IK_Leg
{
    public string name;
    public Transform Target;
    public Transform Pole;
    public int ChainLength = 2;
}