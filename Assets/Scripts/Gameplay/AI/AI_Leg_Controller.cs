using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Leg_Controller : MonoBehaviour
{
    [SerializeField]
    private H_IK legIk;
    [SerializeField]
    private Transform legTarget;
    [SerializeField]
    private Transform legTransform;

    [HideInInspector]
    public bool canWalk;
    [HideInInspector]
    public bool legUp;

    public float max_distance;
    public float leg_anim_speed;
    public float slerp_t;
    public float min_distance;

    private float cur_distance;

    void Update()
    {
        cur_distance = (legTarget.position - legTransform.position).magnitude;
        if(cur_distance > max_distance && !IsInvoking("Animate") && canWalk)
        {

            Debug.Log("leg_move");
            InvokeRepeating("Animate", 0, leg_anim_speed);
        }
    }

    void Animate()
    {
        /*
        leg_transform.position = Vector3.Slerp(leg_transform.position, leg_target.position, slerp_t);
        */
        
        Debug.Log("leg_moved");
        Vector3 stepUp = Vector3.zero;
        legUp = false;
        if(cur_distance > max_distance / 2)
        {
            legUp = true;
            stepUp = Vector3.up;
        }
        legTransform.position = Vector3.MoveTowards(legTransform.position, legTarget.position + stepUp, slerp_t);

        if (cur_distance < min_distance)
        {
            Debug.Log("leg_stop");
            CancelInvoke("Animate");
        }
    }
}
