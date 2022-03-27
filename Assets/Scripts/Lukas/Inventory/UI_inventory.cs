using System.Collections.Generic;
using TMPro;
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

    private Image itemImage;

    public Vector2 mouse_position;

    public void Awake()
    {
        inventory = (Inventory)ScriptableObject.CreateInstance("Inventory");
        GetComponent<GameObject>();
    }

    public void Start()
    {

        inventory = (Inventory)ScriptableObject.CreateInstance("Inventory");
        SwitchInventory();
        GetComponent<Image>();
        itemImage = GetComponent<Image>();

    }


    void Update()
    {

        mouse_position = Mouse.current.position.ReadValue();

    }
    public bool GetImageStatus()
    {
        return image.enabled;
    }

    private void SwitchInventory()
    {
        image = gameObject.GetComponent<Image>();
        image.enabled = !image.enabled;

        foreach (Transform child in transform)
        {
            if (child.GetComponent<Image>())
            {
                child.GetComponent<Image>().enabled = !child.GetComponent<Image>().enabled;
            }

            foreach (Transform grandchild in child.transform)
            {
                if (grandchild.GetComponent<Image>())
                {
                    grandchild.GetComponent<Image>().enabled = !grandchild.GetComponent<Image>().enabled;
                }
                if (grandchild.GetComponent<TextMeshProUGUI>())
                {
                    grandchild.GetComponent<TextMeshProUGUI>().enabled = !grandchild.GetComponent<TextMeshProUGUI>().enabled;
                } 
                else if (grandchild.name.Contains("CurrecnyDisplay"))
                {
                    
                }
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

    private void SetItemName(Transform setObject, string name)
    {
        setObject.GetComponent<TextMeshProUGUI>().text = name;
    }

    [System.Obsolete]
    public void SetItemImage(Item item, Color color, string name, Sprite sprite)
    {
        bool isSet = false;
        bool isAvailable = false;
        Transform setObject = null;

        foreach (Transform child in transform)
        {
            if (child.name.Contains("inventory_item_slot_"))
            {

                isAvailable = false;
                Transform item_color = child.GetChild(0);
                Transform item_sprite = child.GetChild(1);
                Transform item_text = child.GetChild(3);
                Debug.Log(item_color.name);
                Debug.Log(item_sprite.GetComponent<Image>().sprite.name);
                Debug.Log(item.GetType() == Item.Type.keycard);

                if (!isSet)
                {

                    if (item_sprite.GetComponent<Image>().sprite == default_image)
                    {

                        isAvailable = true;

                    }

                    if (isAvailable)
                    {
                        if (item.GetType() == Item.Type.keycard)
                        {
                            SetColor(item_color, color);
                        }
                        SetItemName(item_text, name);
                        SetItem(item_sprite, sprite);
                        isSet = true;
                    }
                }
            }
            else if (child.name.Contains("CurrencyDisplay"))
            {
                bool isSetBefore = isSet;

                if (!isSet)
                {

                    if (child.GetChild(0).name == "Border")
                    {

                        isAvailable = true;

                    }

                    if (isAvailable)
                    {
                        if (child.GetChild(1).name == "CurrencyDisplay")
                        {
                            isSet = false;
                        }
                    }
                }

                isSet = isSetBefore;

            }

        }
    }

    public void OnInteract(InputAction.CallbackContext input)
    {

        if (input.started)
        {

            SwitchInventory();
            if (image.enabled)
            {
                Cursor.lockState = CursorLockMode.Confined;

                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;

                Cursor.lockState = CursorLockMode.Locked;
            }

        }

    }
}
