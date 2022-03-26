using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTest : MonoBehaviour
{
    public GameObject to;
    public GameObject from;
    public float localDistance;
    public float distance;



    // Update is called once per frame
    void Update()
    {
        localDistance = (from.transform.localPosition - to.transform.localPosition).magnitude;
        distance = (from.transform.position - to.transform.position).magnitude;
    }
}
