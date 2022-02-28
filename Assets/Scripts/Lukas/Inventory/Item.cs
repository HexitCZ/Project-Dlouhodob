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
    private Color color;
    [SerializeField]
    [Header("Item color")]
    private Type type;

    public enum Type
    {
        keycard = 0,
        ammo,
        health,
        exp
    }
    
    public GameObject model;
    
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
