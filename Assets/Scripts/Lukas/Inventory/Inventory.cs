using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : ScriptableObject
{

    [Space]
    [Header("Inventory reference")]
    [SerializeField]
    private UI_inventory ui_inv;

    [Space]
    [Header("Item assigner reference")]
    [SerializeField]
    private ItemAssigner item_assigner;

    [Space]
    [Header("Inventory reference")]
    [SerializeField]
    private List<Item> inventory_list;
    private int keyColorCount = 0;
    private int doorColorCount = 0;
    private Inventory inventory;
    public List<Color> Colors;

    public void Awake()
    {

        inventory_list = new List<Item>();
        Colors = new List<Color> { Color.red, Color.green, Color.blue, Color.yellow, Color.magenta };

    }

    public void Update()
    {

    }

    public void AddItem(Item item)
    {
        Image image = null;
        Color item_color = new();

        if (item.GetType() == Item.Type.keycard)
        {
            item_color = item.GetColor();
        }

        image = item_assigner.GetItemImage(item);
        ui_inv.SetItemImage(item, image);
        inventory_list.Add(item);

    }

    public void UseItemConsumable(Item item)
    {

        inventory_list.Remove(item);

    }

    public int GetCount()
    {

        return inventory_list.Count;

    }

    public Color GetDoorColor()
    {

        if (doorColorCount < Colors.Count)
        {

            Color c = Colors[doorColorCount];
            Colors[doorColorCount] = Colors[doorColorCount];
            doorColorCount++;

            return c;

        }
        else
        {

            doorColorCount = ResetCounter();

        }

        return Color.gray;

    }
    public Color GetKeyColor()
    {

        if (keyColorCount < Colors.Count)
        {

            Color c = Colors[keyColorCount];
            Colors[keyColorCount] = Colors[keyColorCount];
            keyColorCount++;

            return c;

        }
        else
        {

            keyColorCount = ResetCounter();

        }

        return Color.gray;

    }
    private int ResetCounter()
    {

        return 0;

    }

    public Item GetItem(int index)
    {
        if(index < inventory_list.Count)
        {
            return inventory_list[index];
        }
        else
        {
            return null;
        }
    }

    public bool CheckForKey(Color color)
    {
        
        Debug.Log(inventory_list.Count);

        int index = inventory_list.FindIndex(item => item.GetColor() == color);

        if (index > -1)
        {

            return true;

        }
        else
        {

            return false;

        }

    }
}
