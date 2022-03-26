using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : PickupBase
{
    public int lifeAmount;
    protected override void Action()
    {
        PlayerHealthController.instance.AddHealth(lifeAmount);
        Destroy(gameObject);
    }
}
