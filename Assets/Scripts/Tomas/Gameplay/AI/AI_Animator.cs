using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Animator : MonoBehaviour
{

    public AI_Leg_Controller[] legs;
    [SerializeField]
    private int legsUp;
    
    // Update is called once per frame
    void Update()
    {
        
        //int curLegsUp = 0;
        
       /* for (int i = 0; i < legs.Length; i++)
        {
            if (legs[i].legUp)
            {
                curLegsUp += 1;
            }

            if (legsUp == curLegsUp)
            {
                legs[i].canWalk = false;

            }
            else
            {
                legs[i].canWalk = true;

            }

            
            
        }*/
    }
}
