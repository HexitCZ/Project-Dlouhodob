using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraData : MonoBehaviour
{
    [Tooltip("Maximum head / camera angle when rotating upwards.")]
    public float maxX;
    
    [Tooltip("Minimum head / camera angle when rotating downwards.")]
    public float minX;
    
    [Tooltip("Sensitivity of camera movement.")]
    public float sensitivity;

    [Tooltip("How big the effect will be.")]
    [Range(0,1)]
    public float effectAmount;
    public ECameraEffect cameraEffect;

    public enum ECameraEffect
    {
        NO_EFFECT,
        DRUNK_CAMERA
    }
}