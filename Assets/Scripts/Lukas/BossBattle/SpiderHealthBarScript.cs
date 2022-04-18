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

    [SerializeField]
    [Space]
    private SpiderMainScript spiderMainScript;

    void Start()
    {
        healthbar.maxValue = ai_walker.health;
        //Debug.Log(ai_walker.health);
    }

    void Update()
    {
        healthbar.value = ai_walker.health;
    }

    float GetHealth()
    {
        float output = 0;

        if (ai_walker.health >= 0)
        {
            output = ai_walker.health;
        }
        else
        {
            output = 0;
        }
        return output;
    }
}
