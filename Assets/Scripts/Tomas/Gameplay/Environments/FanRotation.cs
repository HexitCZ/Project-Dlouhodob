using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour
{
    public float rotationSpeed;


    private void Update()
    {
        float fluctuation = Mathf.Lerp(1.0f, Random.Range(0.1f,3f), 1f);
        transform.Rotate(0, rotationSpeed * Time.deltaTime * fluctuation, 0);
    }
}
