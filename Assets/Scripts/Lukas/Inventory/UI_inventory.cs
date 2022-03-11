using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI_inventory : MonoBehaviour
{

    private Inventory inventory;

    [Space]
    [Header("Object image")]
    [SerializeField]
    private Image image;

    [Space]
    [Header("Holder reference")]
    [SerializeField]
    private Image image_holder;

    [Space]
    [Header("X position")]
    [SerializeField]
    private float x_value;

    [Space]
    [Header("Y position")]
    [SerializeField]
    private float y_value;

    [Space]
    [Header("inventory container reference")]
    [SerializeField]
    private GameObject inventory_container;

    [Space]
    [Header("UI inventory item container")]
    [SerializeField]
    private Transform item_container;
    
    [Space]
    [Header("Default image")]
    [SerializeField]
    private Sprite default_image;

    private List<Image> item_model;

    public void Awake()
    {
        inventory = (Inventory)ScriptableObject.CreateInstance("Inventory");
    }

    public void Start()
    {

        inventory = (Inventory)ScriptableObject.CreateInstance("Inventory");
        SwitchInventory();

    }


    void Update()
    {

    }

    private void SwitchInventory()
    {
        image = gameObject.GetComponent<Image>();
        image.enabled = !image.enabled;

        foreach (Transform child in transform)
        {
            child.GetComponent<Image>().enabled = !child.GetComponent<Image>().enabled;

            foreach (Transform grandchild in child.transform)
            {
                grandchild.GetComponent<Image>().enabled = !grandchild.GetComponent<Image>().enabled;
            }
        }
    }

    public Inventory GetInventory()
    {

        return inventory;

    }

    private void SetColor(Transform setObject, Color color)
    {
        setObject.GetComponent<Image>().color = color;
    }
    private void SetItem(Transform setObject, Sprite sprite)
    {
        
        setObject.GetComponent<Image>().sprite = sprite;

    }

    public void SetItemImage(Item item, Color color, Sprite sprite)
    {
        bool isSet = false;
        bool isAvailable = false;
        Transform setObject = null;

        foreach (Transform child in transform)
        {
            isAvailable = false;
            Transform item_color = child.GetChild(0);
            Transform item_sprite = child.GetChild(1);
            Debug.Log(item_color.name);
            Debug.Log(item_sprite.GetComponent<Image>().sprite.name);
            Debug.Log(item.GetType() == Item.Type.keycard);
            SetColor(item_color, color);
        
            SetItem(item_sprite, sprite);
        /*if (!isSet)
            {

                if (item_sprite.GetComponent<Image>().sprite == default_image)
                {

                    isAvailable = true;

                }

                if (isAvailable)
                {
                    if(item.GetType() == Item.Type.keycard)
                    {
                        SetColor(item_color, color);
                    }
                    SetItem(item_sprite, sprite);
                    isSet = true;
                }
            }*/

        }
    }

    public void OnInteract(InputAction.CallbackContext input)
    {

        if (input.started)
        {

            SwitchInventory();

            Time.timeScale = image.enabled ? 0f : 1f;

        }

    }
}
