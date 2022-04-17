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

    private Color keyColor;

    public Material[] displayMats;

    [Space]
    [Header("Keycard")]
    [SerializeField]
    private Item keycard;
    
    public void Start()
    {
        keyRenderer = GetComponent<Renderer>();
        keyMats = keyRenderer.materials;
        keyColor = keyMats[1].color;

        keycard = (Item)ScriptableObject.CreateInstance("Item");
        keycard.SetType(Item.Type.keycard);
        inventory = ui_inventory.GetInventory();
        //keycard.SetColor(inventory.GetKeyColor());
        
        keyRenderer = GetComponent<Renderer>();
        type = Item.Type.keycard;
        item_id = (int)type;     
    }

    public void Update()
    {

        transform.Rotate(0, 0, rotationSpeed);
    
    }

    [System.Obsolete]
    public void OnTriggerEnter(Collider other)
    {

        inventory.AddItem(keycard, keyColor);
        Destroy(gameObject);

    }
}
