using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour
{
    public float rotationSpeed;
    public float maxFluctuation;

    //Makes environments nicer with random fan rotation

    private void Update()
    {
        float fluctuation = Mathf.Lerp(1.0f, Random.Range(0.1f, maxFluctuation), 1f);
        transform.Rotate(0, rotationSpeed * Time.deltaTime * fluctuation, 0);
    }
}
