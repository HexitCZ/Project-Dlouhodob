using UnityEngine;
using UnityEngine.Events;

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

    [Space]
    [Header("UI inventory")]
    [SerializeField]
    private UI_inventory ui_inventory;

    [Space]
    [Header("UI script")]
    [SerializeField]
    private ui_script ui_script;

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

        inventory = ui_inventory.GetInventory();

        openInvoker = new UnityEvent();
        closeInvoker = new UnityEvent();

        doorRenderer = GetComponent<Renderer>();
        displayMats = displayRenderer.materials;
        displayColor = displayMats[0].color;


        if (broken)
        {

            doorAnimator.SetBool("broken", true);

        }

    }

    public void Update()
    {



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
        open = ui_script.GetInput();

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


            if (needsKey && open)
            {
                
                
                if (inventory.CheckForKey(displayColor))
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
        ui_script.ResetOpen();
        open = ui_script.GetInput();
        closeInvoker.Invoke();

    }
}
