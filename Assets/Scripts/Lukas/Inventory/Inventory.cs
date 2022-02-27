using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject
{

    [Space]
    [Header("Inventory reference")]
    [SerializeField]
    private List<Item> inventory_list;
    private int colorCount = 0;
    private Inventory inventory;
    public List<(Color, bool, bool)> keyColors;

    public void Awake()
    {

        inventory_list = new List<Item>();
        keyColors = new List<(Color, bool, bool)> { (Color.red, false, false), (Color.green, false, false), (Color.blue, false, false), (Color.yellow, false, false), (Color.magenta, false, false) };

    }

    public void Update()
    {

    }

    public void AddItem(Item item, KeycardScript keycardScript)
    {

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

    public Color GetColor(bool isDoor)
    {

        if (colorCount < keyColors.Count)
        {
            Debug.Log("bad");


            if (!(keyColors[colorCount].Item2) && isDoor)
            {
                Debug.Log("bada");

                Color c = keyColors[colorCount].Item1;
                keyColors[colorCount] = (keyColors[colorCount].Item1, true, keyColors[colorCount].Item3);
                return c;

            }
            else if (!(keyColors[colorCount].Item3) && !isDoor)
            {
                Debug.Log("badaa");

                Color c = keyColors[colorCount].Item1;
                keyColors[colorCount] = (keyColors[colorCount].Item1, keyColors[colorCount].Item2, true);
                return c;

            }

            if (isDoor && keyColors[colorCount].Item3)
            {
                colorCount++;
            }

        }
        else
        {

            ResetCounter();

        }

        return Color.gray;

    }

    private void ResetCounter()
    {

        colorCount = 0;

    }

    public bool CheckForKey(Color color)
    {

        int index = inventory_list.FindIndex(item => item.GetColor() == color);

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
