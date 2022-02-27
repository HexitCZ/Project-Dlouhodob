using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_Data : MonoBehaviour
{
    [Header("IK paramateres")]
    public int iterations = 10;

    [Space]
    [Header("Animation settings")]

    [SerializeField]
    private float max_distance_value;
    public float max_distance { get { return max_distance_value * transform.localScale.x; } }
    
    [SerializeField]
    private float min_distance_value;
    public float min_distance { get { return min_distance_value * transform.localScale.x; } }
    
    [SerializeField]
    private float leg_anim_speed_value;
    public float leg_anim_speed { get { return leg_anim_speed_value * transform.localScale.x; } }
    
    [SerializeField]
    private float slerp_t_value;
    public float slerp_t { get { return slerp_t_value * transform.localScale.x; } }

    public float stepUpAmount;
    
    [Space]
    [Header("Leg configuration")]
    public IK_Leg[] legs;

    

}

[System.Serializable]
public class IK_Leg
{
    public string name;
    [Space]
    public H_IK legIK;
    [Space]
    public Transform legTransform;
    public Transform legTarget;
    public Transform pole;
    public int chainLength = 2;
}