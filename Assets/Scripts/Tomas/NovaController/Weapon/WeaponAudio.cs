using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : MonoBehaviour
{
    public AudioClip[] clips;

    private AudioSource source;

    public static WeaponAudio instance;
    private void Start()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void Play(BulletType type)
    {
        switch (type)
        {
            case BulletType.physic:
                source.clip = clips[0];
                source.Play();

                break;
            case BulletType.laser:
                source.clip = clips[1];
                source.Play();
                break;
            case BulletType.electro:
                source.clip = clips[2];
                source.Play();
                break;
            
        }
    }


}

public enum BulletType
{
    physic, laser, electro
}