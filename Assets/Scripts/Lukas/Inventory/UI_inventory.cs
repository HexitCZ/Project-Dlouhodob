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

    public void Awake()
    {
        inventory = (Inventory)ScriptableObject.CreateInstance("Inventory");
    }

    public void Start()
    {

        image = gameObject.GetComponent<Image>();
        image.enabled = false;

    }

    void Update()
    {
        for(int x = 0;  x < inventory.GetCount(); x++)
        {
            
        }
    }

    public Inventory GetInventory()
    {

        return inventory;

    }

    public void OnInteract(InputAction.CallbackContext input)
    {

        if (input.started)
        {

            image.enabled = !image.enabled;

        }

    }
}
