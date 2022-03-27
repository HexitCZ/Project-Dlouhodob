using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{
    #region Singleton
    public static PlayerCurrency instance;
    #endregion  

    public int amount;

    private void Awake()
    {
        instance = this;
    }

    public bool TryPay(int price)
    {
        if (price <= amount)
        {
            amount -= price;
            return true;
        }
        else
        {
            return false;
        }
    }


    public void Add(int n)
    {
        amount += n;
    }

}
