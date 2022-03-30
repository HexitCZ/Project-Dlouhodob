using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : MonoBehaviour
{
    public AudioClip[] clips;

    public AudioSource source;

    public static WeaponAudio instance;
    private void Start()
    {
        instance = this;
    }

    public void Play()
    {

        switch (WeaponController.instance.currentBullet.type)
        {
            case "physical":
                source.clip = clips[0];
                source.Play();

                break;
            case "laser":
                source.clip = clips[1];
                source.Play();
                break;
            case "electro":
                source.clip = clips[2];
                source.Play();
                break;
            
        }
    }


}
