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

    private List<Image> item_model;

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
            Time.timeScale = image.enabled ? 0f : 1f;
            if(Time.timeScale == 0f)
            {
                for (int x = 0; x < inventory.GetCount(); x++)
                {
                    if (inventory.GetItem(x) != null)
                    {
                        Instantiate(item_model[x]);
                    }
                }
            }
        }

    }
}
