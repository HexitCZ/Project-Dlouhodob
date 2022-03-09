using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthData : MonoBehaviour
{

    public bool canBeDamaged;


    public int visibleHealth;
    public float actualHealth;

    [Tooltip("0 -> No regen, higher value, higher regeneration")]
    public float regenerationSpeed;

}
