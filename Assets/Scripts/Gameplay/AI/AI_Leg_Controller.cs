using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Leg_Controller : MonoBehaviour
{
    [SerializeField]
    private H_IK leg_ik;
    [SerializeField]
    private Transform leg_target;
    [SerializeField]
    private Transform leg_transform;

    public float max_distance;
    public float leg_anim_speed;
    public float slerp_t;
    public float min_distance;

    private float cur_distance;

    void Update()
    {
        cur_distance = (leg_target.position - leg_transform.position).magnitude;
        if(cur_distance > max_distance && !IsInvoking("Animate"))
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
        if(cur_distance > max_distance / 2)
        {
            stepUp = Vector3.up;
        }
        leg_transform.position = Vector3.MoveTowards(leg_transform.position, leg_target.position + stepUp, slerp_t);

        if (cur_distance < min_distance)
        {
            Debug.Log("leg_stop");
            CancelInvoke("Animate");
        }
    }
}
