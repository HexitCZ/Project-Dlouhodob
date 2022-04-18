using UnityEngine;
using UnityEngine.Events;

public class door_script : MonoBehaviour
{

    [Space]
    [Header("Bools")]
    [SerializeField]
    public bool open;
    [SerializeField]
    public bool automatic;
    [SerializeField]
    private bool broken;
    [SerializeField]
    public bool needsKey;
    [SerializeField]
    private bool inRange;

    [Space]
    [Header("UI inventory")]
    [SerializeField]
    private UI_inventory ui_inventory;

    [Space]
    [Header("UI script")]
    [SerializeField]
    private UI_script ui_script;

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

    private Color displayColor;

    public void Start()
    {
        try
        {
            inventory = ui_inventory?.GetInventory();

            openInvoker = new UnityEvent();
            closeInvoker = new UnityEvent();

            doorRenderer = GetComponent<Renderer>();
            displayMats = displayRenderer.materials;
            displayColor = displayMats[0].color;

        }
        catch (UnassignedReferenceException)
        {

        }
        if (broken)
        {

            Break();

        }

    }

    public void Update()
    {


    }

    public void OnTriggerEnter(Collider other)
    {

        if (automatic)
        {
            Open();
        }

    }
    public void Break()
    {
        doorAnimator.SetBool("broken", true);
    }

    public void Open()
    {
        doorAnimator.SetBool("open", true);
    }

    public void Close()
    {
        doorAnimator.SetBool("open", false);
    }

    public void InvokeBroken()
    {
        brokenInvoker.Invoke();
    }

    public void InvokeOpen()
    {
        openInvoker.Invoke();
    }

    public void InvokeClose()
    {
        closeInvoker.Invoke();
    }

    public void OnTriggerStay(Collider other)
    {
        try
        {


            if (other.name == "Head" || other.name == "Body")
            {


                if (!broken && ui_script != null)
                {
                    open = ui_script.GetInput();

                }
                else
                {
                    Break();
                }

                if (automatic)
                {
                    Open();
                }
                else
                {
                    if (GetComponent<Renderer>().isVisible)
                    {

                        if (broken)
                        {
                            InvokeBroken();
                        }
                        else
                        {
                            InvokeOpen();
                        }
                    }


                    if (needsKey && open)
                    {


                        if (inventory.CheckForKey(displayColor))
                        {

                            Open();

                        }

                    }
                    else
                    {

                        if (open)
                        {

                            Open();

                        }

                    }

                }
            }
        }
        catch (UnassignedReferenceException)
        {

        }
    }

    public void OnTriggerExit(Collider other)
    {
        try
        {
            if (other.name == "Head" || other.name == "Body")
            {
                Close();
                ui_script.ResetOpen();
                open = ui_script.GetInput();
                InvokeClose();
            }
        }
        catch (UnassignedReferenceException)
        {

        }
    }
}
