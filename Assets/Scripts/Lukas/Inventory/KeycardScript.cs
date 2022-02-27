using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardScript : MonoBehaviour
{
    [Space]
    [Header("Type")]
    [SerializeField]
    private Item.Type type;
    
    [Space]
    [Header("UI inventory")]
    [SerializeField]
    private UI_inventory ui_inventory;

    [Space]
    [Header("Key Item")]
    [SerializeField]
    private Item item;

    [Space]
    [Header("Key Rotation Speed")]
    [SerializeField]
    private float rotationSpeed = 1.0f;

    [Space]
    [Header("Item id")]
    [SerializeField]
    private int item_id;

    private Inventory inventory;

    private Renderer keyRenderer;

    public Material[] keyMats;

    public void Start()
    {
        Item keycard = (Item)ScriptableObject.CreateInstance("Item");
        inventory = ui_inventory.GetInventory();
        keycard.SetColor(inventory.GetColor(false));
        keyRenderer = GetComponent<Renderer>();
        keyMats = keyRenderer.materials;
        keyMats[1].color = keycard.GetColor();
        keyRenderer.materials = keyMats;
        type = Item.Type.keycard;
        item_id = (int)type;

    }

    public void Update()
    {

        transform.Rotate(0, 0, rotationSpeed);
    
    }

    public void OnTriggerEnter(Collider other)
    {

        inventory.AddItem(item, this);
        Destroy(gameObject);

    }
}
