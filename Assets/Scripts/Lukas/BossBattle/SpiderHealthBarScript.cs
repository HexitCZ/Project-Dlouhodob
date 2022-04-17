using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiderHealthBarScript : MonoBehaviour
{
    [SerializeField]
    [Space]
    private AI_Walker ai_walker;

    [SerializeField]
    [Space]
    private Slider healthbar;

    void Start()
    {
        //Debug.Log(ai_walker.health);
    }

    void Update()
    {
        healthbar.value = ai_walker.health;
    }
}
