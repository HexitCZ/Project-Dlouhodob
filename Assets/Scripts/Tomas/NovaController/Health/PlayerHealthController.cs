using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    #region Singleton
    public static PlayerHealthController instance;
    #endregion

    private PlayerHealthData data;

    private float hue;

    private void Start()
    {
        instance = this;
        data = this.transform.parent.GetComponent<PlayerHealthData>();
        data.actualHealth = data.visibleHealth;
    }

    public void AddHealth(float amount)
    {
        data.actualHealth += amount;
        updateVisibleHealth();
        CheckHealth();
    }

    public void GetHit(float damage)
    {
        if (data.canBeDamaged)
        {
            data.actualHealth -= damage;
            updateVisibleHealth();
        }
        CheckHealth();
    }

    public void updateVisibleHealth()
    {
        data.visibleHealth = (int)Mathf.Clamp(data.actualHealth, 0.0f, data.maxHealth);
    }

    public void CheckHealth()
    {
        if (data.actualHealth <= 0.01f)
        {
            Debug.Log("Player died");
            
        }
    }

    private void Update()
    {
        SetUI();
    }

    public void SetUI()
    {
        hue = (data.actualHealth / data.maxHealth);

        
        float normal = Mathf.InverseLerp(0.0f, 1.0f, hue);
        float outhue = Mathf.Lerp(0.0f, 0.28f, normal);

        data.colorImage.color = Color.Lerp(data.colorImage.color, Color.HSVToRGB(outhue, 1, 0.8f), 0.05f);
        data.healthText.text = data.visibleHealth.ToString();
    }

}
