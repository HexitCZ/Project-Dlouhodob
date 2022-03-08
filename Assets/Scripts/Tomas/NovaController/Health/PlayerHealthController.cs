using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    #region Singleton
    public static PlayerHealthController instance;
    #endregion

    private PlayerHealthData data;

    private void Start()
    {
        instance = this;
        data = this.transform.parent.GetComponent<PlayerHealthData>();
        data.actualHealth = data.visibleHealth;
    }

    public void GetHit(float damage)
    {
        if (data.canBeDamaged)
        {
            data.actualHealth -= damage;
            data.visibleHealth = (int)Mathf.Clamp(data.actualHealth, 0.0f, float.MaxValue);
        }
        CheckHealth();
    }

    public void CheckHealth()
    {
        if (data.actualHealth <= 0.01f)
        {
            Debug.Log("Player died");
        }
    }
}
