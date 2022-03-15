using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAssigner : ScriptableObject
{
    [Space]
    [Header("Ammo")]
    [SerializeField]
    private Sprite ammo_image;
    
    [Space]
    [Header("Exp")]
    [SerializeField]
    private Sprite exp_image;

    [Space]
    [Header("Health")]
    [SerializeField]
    private Sprite health_image;

    [Space]
    [Header("Keycard")]
    [SerializeField]
    private Sprite key_image;

    [Space]
    [Header("Ammunition")]
    [SerializeField]

    private string ammo_name;

    [Space]
    [Header("Experience")]
    [SerializeField]
    private string exp_name;

    [Space]
    [Header("Health")]
    [SerializeField]
    private string health_name;

    [Space]
    [Header("Keycard")]
    [SerializeField]
    private string key_name;
    void Awake()
    {
        ammo_name = "Ammo";
        exp_name = "Experience";
        health_name = "Health";
        key_name = "Keycard";
        key_image = Resources.Load<Sprite>("keycard_image_no_color");
    }

    void Update()
    {
        
    }

    public string GetItemName(Item item)
    {
        string name = null;

        if (item.GetType() == Item.Type.ammo)
        {
            name = ammo_name;
        }
        else if (item.GetType() == Item.Type.exp)
        {
            name = exp_name;
        }
        else if (item.GetType() == Item.Type.health)
        {
            name = health_name;
        }
        else if (item.GetType() == Item.Type.keycard)
        {
            name = key_name;
        }

        return name;
    }

    public Sprite GetItemImage(Item item)
    {
        Sprite sprite = null;

        if(item.GetType() == Item.Type.ammo)
        {
            sprite = ammo_image;
        }
        else if (item.GetType() == Item.Type.exp)
        {
            sprite = exp_image;
        }
        else if (item.GetType() == Item.Type.health)
        {
            sprite = health_image;
        }
        else if (item.GetType() == Item.Type.keycard)
        {
            sprite = key_image;
        }

        return sprite;
    }
}
