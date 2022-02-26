using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class easterEggPlayerScript : MonoBehaviour
{
    [Space]
    [Header("Video Player")]
    [SerializeField]
    private VideoPlayer vp;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        vp.Play();
    }
}
