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
    }

    void Update()
    {
        healthbar.value = ai_walker.health;
    }
    /// <summary>
    /// Vraci zivoty pavouka
    /// </summary>
    /// <returns></returns>
    public float GetHealth()
    {
        float output = 0;

        if (ai_walker.health >= 0)
        {
            if(ai_walker.health >= 75f)
            {
                output = 75f;
            }
            else if (ai_walker.health >= 50f)
            {
                output = 50f;
            }
            else if (ai_walker.health >= 25f)
            {
                output = 25f;
            }

            else if (ai_walker.health >= 0f)
            {
                output = 0f;
            }
            else
            {
                output = ai_walker.health;
            }
        }
        else
        {
            output = 0;
        }
        return output;
    }
}
