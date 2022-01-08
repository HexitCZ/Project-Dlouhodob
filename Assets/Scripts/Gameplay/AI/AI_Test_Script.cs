using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Test_Script : AI_Base
{
    public bool removeHealth;

    

    private new void Start()
    {
        base.Start();
        preUpdateAction += RemoveHealth;
    }

    private void RemoveHealth()
    {
        if (removeHealth)
        {
            health--;
            removeHealth = !removeHealth;
        }
    }

    protected override void SetDestination(Transform destination)
    {
        base.SetDestination(destination);
    }

    protected override bool CheckHealth()
    {
        Debug.Log("CheckHealth");
        
        if (health > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    protected override bool CheckVisibility()
    {
        Debug.Log("CheckVisibility");
        return true;
    }

    protected override bool CheckRange()
    {
        Debug.Log("CheckRange");
        return true;
    }

    protected override void Attack()
    {
        Debug.Log("Attack");
    }

    protected override void Death()
    {
        
        Debug.Log("Death");
        gameObject.SetActive(false);

        
    }
}
