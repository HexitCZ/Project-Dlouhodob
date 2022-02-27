using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Leg_Controller : MonoBehaviour
{
    [HideInInspector]
    public IK_Data ikdata;
    [HideInInspector]
    public int ikindex;
    [HideInInspector]
    public H_IK ikSolver;
    private Transform legTarget;
    private Transform legTransform;

    [HideInInspector]
    public bool legUp;

    private float max_distance;
    private float leg_anim_speed;
    private float slerp_t;
    private float min_distance;

    private float stepUpAmount;

    private float cur_distance;

    private void Awake()
    {
        ikindex = transform.GetSiblingIndex();
        ikdata = transform.parent.parent.GetComponent<IK_Data>();
        
        legTarget = ikdata.legs[ikindex].legTarget;
        legTransform = ikdata.legs[ikindex].legTransform;
        
        max_distance = ikdata.max_distance;
        leg_anim_speed = ikdata.leg_anim_speed;
        slerp_t = ikdata.slerp_t;
        min_distance = ikdata.min_distance;
        stepUpAmount = ikdata.stepUpAmount;

        ikSolver = transform.GetChild(0).GetComponent<H_IK>();
        ikSolver.Target = legTransform;
        ikSolver.Pole = ikdata.legs[ikindex].pole;
        ikSolver.ChainLength = ikdata.legs[ikindex].chainLength;
        ikSolver.Iterations = ikdata.iterations;
    }

    void Update()
    {
        //Debug.Log(cur_distance);
        cur_distance = (ikdata.legs[ikindex].legTarget.position - ikdata.legs[ikindex].legTransform.position).magnitude;
        if(cur_distance > max_distance)
        {

            //Debug.Log("leg_move");
            InvokeRepeating("Animate", 0, leg_anim_speed);
        }
    }

    void Animate()
    {
        
        //Debug.Log("leg_moved");
        Vector3 stepUp = Vector3.zero;
        legUp = false;
        if(cur_distance > max_distance / 2)
        {
            legUp = true;
            stepUp = Vector3.up * stepUpAmount;
        }
        legTransform.position = 
            Vector3.MoveTowards(
            legTransform.position, 
            legTarget.position + 
            stepUp, slerp_t);

        if (cur_distance < min_distance)
        {
            //Debug.Log("leg_stop");
            CancelInvoke("Animate");
        }
    }
}
