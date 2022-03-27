using TMPro;
using UnityEngine;

public class CurrencyDisplayScript : MonoBehaviour
{

    [Space]
    [SerializeField]
    private string display_text;

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
    private int currency;

    [Space]
    [SerializeField]
    [Header("Current experience")]
    private int exp;

    [Space]
    [SerializeField]
    [Header("Current upgrade points")]
    private int upgrade_points;


    [Space]
    [SerializeField]
    [Header("Current currency")]
    private Transform currency_ui_holder;
    
    [Space]
    [SerializeField]
    [Header("Current text holder")]
    private TextMeshProUGUI currency_text_holder;

    void Start()
    {
        currency_text_holder = currency_ui_holder.GetChild(2).GetComponent<TextMeshProUGUI>();
        display_text = "Currency: ";
    }

    private void DisplayCurrencyAmount()
    {
        currency_text_holder.text = display_text + currency;
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
    }

    void Update()
    {
        image_enabled = uI_Inventory.GetImageStatus();
        exp = ExperienceSystem.instance.xp;
        upgrade_points = ExperienceSystem.instance.upgradePoints;

        if (image_enabled)
        {
            currency_text_holder.GetComponent<TextMeshProUGUI>().enabled = true;
            DisplayCurrencyAmount();
        }
        else
        {
            currency_text_holder.GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }
}
