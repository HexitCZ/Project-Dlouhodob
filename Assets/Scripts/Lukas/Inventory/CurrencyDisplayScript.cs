using TMPro;
using UnityEngine;

public class CurrencyDisplayScript : MonoBehaviour
{

    [Space]
    [SerializeField]
    private string currency_display_text;

    [Space]
    [SerializeField]
    private string exp_display_text;

    [Space]
    [SerializeField]
    private string upgrade_points_display_text;

    [Space]
    [SerializeField]
    [Header("Image enabled status")]
    private bool image_enabled;

    [Space]
    [SerializeField]
    [Header("UI inventory reference")]
    private UI_inventory uI_Inventory;
    

    [Space]
    [SerializeField]
    [Header("Current currency")]
    private Transform currency_ui_holder;

    [Space]
    [SerializeField]
    [Header("Current currency")]
    private TextMeshProUGUI currency_text_holder;

    [Space]
    [SerializeField]
    [Header("Current currency")]
    private int currency;


    [Space]
    [SerializeField]
    [Header("Current exp")]
    private Transform exp_ui_holder;
    
    [Space]
    [SerializeField]
    [Header("Current exp holder")]
    private TextMeshProUGUI exp_text_holder;

    [Space]
    [SerializeField]
    [Header("Current experience")]
    private int exp;


    [Space]
    [SerializeField]
    [Header("Current upgrade points")]
    private Transform upgrade_points_ui_holder;
    
    [Space]
    [SerializeField]
    [Header("Current upgrade points holder")]
    private TextMeshProUGUI upgrade_points_text_holder;

    [Space]
    [SerializeField]
    [Header("Current upgrade points")]
    private int upgrade_points;

    void Start()
    {
        currency_text_holder = currency_ui_holder.GetChild(2).GetComponent<TextMeshProUGUI>();
        exp_text_holder = exp_ui_holder.GetChild(2).GetComponent<TextMeshProUGUI>();
        upgrade_points_text_holder = upgrade_points_ui_holder.GetChild(2).GetComponent<TextMeshProUGUI>();
        
        currency_display_text = "Currency: ";
        exp_display_text = "Experience: ";
        upgrade_points_display_text = "Upgrade points: ";
    }

    private void DisplayCurrencyAmount()
    {
        currency_text_holder.text = currency_display_text + currency;
    }

    private void DisplayUpgradePointsAmount()
    {
        upgrade_points_text_holder.text = upgrade_points_display_text + upgrade_points;
    }

    private void DisplayExpAmount()
    {
        exp_text_holder.text = exp_display_text + exp;
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
    }

    private void UpdateUpgradePoints()
    {
        upgrade_points = ExperienceSystem.instance.upgradePoints;
    }

    private void UpdateExp()
    {
        exp = ExperienceSystem.instance.xp;
    }

    void Update()
    {
        image_enabled = uI_Inventory.GetImageStatus();

        UpdateExp();
        UpdateUpgradePoints();

        if (image_enabled)
        {
            upgrade_points_text_holder.GetComponent<TextMeshProUGUI>().enabled = true;
            DisplayCurrencyAmount();
        }
        else
        {
            upgrade_points_text_holder.GetComponent<TextMeshProUGUI>().enabled = false;

        }
    }
}
