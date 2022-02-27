using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class door_script : MonoBehaviour
{

    [Space]
    [Header("Bools")]
    [SerializeField]
    private bool open;
    [SerializeField]
    private bool automatic;
    [SerializeField]
    private bool broken;
    [SerializeField]
    private bool needsKey;
    [SerializeField]
    private bool inRange;
    [SerializeField]
    private KeycardScript key;

    [Space]
    [Header("UI inventory")]
    [SerializeField]
    private UI_inventory ui_inventory;

    private Inventory inventory;

    [Space]
    [Header("Invokers")]
    public UnityEvent openInvoker;
    public UnityEvent closeInvoker;
    public UnityEvent brokenInvoker;

    [Space]
    [Header("Animator")]
    public Animator doorAnimator;

    public Renderer doorRenderer;

    public Renderer displayRenderer;

    public Material[] displayMats;

    public void Start()
    {

        inventory = ui_inventory.GetInventory();

        openInvoker = new UnityEvent();
        closeInvoker = new UnityEvent();

        doorRenderer = GetComponent<Renderer>();
        displayRenderer = GetComponent<Renderer>();

        if (broken)
        {

            doorAnimator.SetBool("broken", true);

        }
        else if (needsKey)
        {

            displayMats = displayRenderer.materials;
            displayMats[0].color = inventory.GetColor(true);
            displayRenderer.materials = displayMats;

        }
    }

    public void Update()
    {

    }

    public void OnInteract(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            this.open = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (automatic)
        {
            doorAnimator.SetBool("open", true);
        }

    }
    public void OnTriggerStay(Collider other)
    {
        if (automatic)
        {
            doorAnimator.SetBool("open", true);
        }
        else
        {
            if (GetComponent<Renderer>().isVisible)
            {

                if (broken)
                {
                    brokenInvoker.Invoke();
                }
                else
                {
                    openInvoker.Invoke();
                }
            }


            if (needsKey)
            {

                if (inventory.CheckForKey(displayMats[0].color))
                {

                    doorAnimator.SetBool("open", true);

                }

            }
            else
            {

                if (open)
                {

                    doorAnimator.SetBool("open", true);

                }

            }

        }

    }

    public void OnTriggerExit(Collider other)
    {

        doorAnimator.SetBool("open", false);
        open = false;
        closeInvoker.Invoke();

    }
}
