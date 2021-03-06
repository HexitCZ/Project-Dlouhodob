using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item data")]
public class Item : ScriptableObject
{

    [SerializeField]
    [Header("Inventory reference")]
    private Inventory inventory;
    [SerializeField]
    [Header("Item color")]
    public Color color;
    [SerializeField]
    [Header("Item color")]
    private Type type;

    public GameObject model;

    public enum Type
    {
        keycard = 0,
        ammo,
        health,
        exp,
        currency
    }
    
    
    
    public Item(Type type, Color color)
    {
        this.type = type;
        this.color = color;
    }


    public void SetType(Type type)
    {
        this.type = type;
    }

    public new Type GetType()
    {
        return this.type;
    }

    public void SetColor(Color color)
    {
        this.color = color;
    }

    public Color GetColor()
    {
        return this.color;
    }

}
