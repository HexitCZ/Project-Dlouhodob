using System.Collections;
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

    public void SetColor(Transform setObject, Color color)
    {
        setObject.GetComponent<Image>().color = color;
    }

    public void SetItemImage(Item item, Image image)
    {
        bool isSet = false;

        foreach (Transform child in transform)
        {
            if (child.name.Contains("inventory_item_slot")  && !isSet)
            { 
                foreach (Transform grandchild in child.transform)
                {
                    try
                    {
                        if (grandchild.GetComponent<Image>().name != "Image")
                        {
                            if (grandchild.GetComponent<Image>().sprite.name == "default_image")
                            {
                                grandchild.GetComponent<Image>().sprite = image.sprite;
                                isSet = true;

                                if(item.GetType() == Item.Type.keycard)
                                {
                                    Transform setObject = grandchild;
                                    SetColor(setObject, item.GetColor());
                                }
                            }
                        }

                    }
                    catch
                    {


                    }
                }

            }
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
