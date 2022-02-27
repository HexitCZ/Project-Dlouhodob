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
    [Space]
    [Header("Streaming Surface")]
    [SerializeField]
    private Renderer platnoRenderer;
    void Start()
    {
        platnoRenderer = GetComponent<Renderer>();
        platnoRenderer.enabled = false;
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        platnoRenderer.enabled = true;
        vp.Play();
    }

    public void OnTriggerExit(Collider other)
    {
        platnoRenderer.enabled = false;
        vp.Stop();
    }
}
