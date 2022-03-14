using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject
{

    [Space]
    [Header("Inventory reference")]
    [SerializeField]
    private List<(Item, Color)> inventory_list;
    private int keyColorCount = 0;
    private int doorColorCount = 0;
    private Inventory inventory;
    public List<Color> Colors;

    [Space]
    [Header("UI inventory reference")]
    [SerializeField]
    private UI_inventory ui_Inventory;

    [Space]
    [Header("Item assigner reference")]
    [SerializeField]
    private ItemAssigner itemAssigner;

    public void Awake()
    {
        ui_Inventory = GameObject.Find("inventory_container").GetComponent<UI_inventory>();
        itemAssigner = (ItemAssigner)ScriptableObject.CreateInstance("ItemAssigner");
        inventory_list = new List<(Item, Color)>();
        Colors = new List<Color> { Color.red, Color.green, Color.blue, Color.yellow, Color.magenta };

    }

    public void Update()
    {

    }

    public void AddItem(Item item, Color color)
    {
        Sprite sprite = itemAssigner.GetItemImage(item);
        Debug.Log(sprite.name);
        ui_Inventory.SetItemImage(item, color, sprite);
        inventory_list.Add((item, color));

    }

    public void UseItemConsumable(Item item, Color color)
    {

        inventory_list.Remove((item, color));

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
            return inventory_list[index].Item1;
        }
        else
        {
            return null;
        }
    }

    public bool CheckForKey(Color color)
    {

        int index = 0;

        foreach((Item, Color) item in inventory_list)
        {
            if(item.Item1.GetType() == Item.Type.keycard && item.Item2 == color)
            {
                index++;
            }
        }

        if (index > 0)
        {

            return true;

        }
        else
        {

            return false;

        }

    }
}
