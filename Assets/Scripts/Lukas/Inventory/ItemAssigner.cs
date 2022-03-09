using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAssigner : ScriptableObject
{
    [Space]
    [Header("Ammo")]
    [SerializeField]
    private Image ammo_image;
    
    [Space]
    [Header("Exp")]
    [SerializeField]
    private Image exp_image;

    [Space]
    [Header("Health")]
    [SerializeField]
    private Image health_image;

    [Space]
    [Header("Keycard")]
    [SerializeField]
    private Image key_image;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public Image GetItemImage(Item item)
    {
        Image image = null;

        if(item.GetType() == Item.Type.ammo)
        {
            image = ammo_image;
        }
        else if (item.GetType() == Item.Type.exp)
        {
            image = exp_image;
        }
        else if (item.GetType() == Item.Type.health)
        {
            image = health_image;
        }
        else if (item.GetType() == Item.Type.keycard)
        {
            image = key_image;
        }

        return image;
    }
}
