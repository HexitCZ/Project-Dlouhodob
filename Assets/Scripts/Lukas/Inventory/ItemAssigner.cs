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

    void Awake()
    {
        
        key_image = Resources.Load<Sprite>("keycard_image_no_color");
        Debug.Log(key_image.name);
    }

    void Update()
    {
        
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
