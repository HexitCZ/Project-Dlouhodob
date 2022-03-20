using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHealthData : MonoBehaviour
{

    public bool canBeDamaged;


    public int maxHealth;
    public int visibleHealth;
    public float actualHealth;

    [Tooltip("0 -> No regen, higher value, higher regeneration")]
    public float regenerationSpeed;

    [Space]
    public Image colorImage;
    public TMP_Text healthText;
}
