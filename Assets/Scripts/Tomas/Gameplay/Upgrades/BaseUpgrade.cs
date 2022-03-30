using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;


public class BaseUpgrade : MonoBehaviour
{

    public Volume post;
    public Image icon;
    public int cooldown;

    public AudioClip readySound;
    public AudioClip activateSound;
    public AudioSource readySoundSource;

    protected bool activated;

    public virtual void Activate()
    {
        
    }

    protected void Update()
    {
        if (activated)
        {
            icon.color = Color.red;
        }
    }

}
