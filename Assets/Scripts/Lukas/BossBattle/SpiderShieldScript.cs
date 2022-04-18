using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShieldScript : MonoBehaviour
{

    [SerializeField]
    [Space]
    private Animator shield_animator;

    private bool isActive;

    private string status;

    private SpiderMainScript spiderMainScript;

    //private AI_Walker aiWalker;

    void Start()
    {
        isActive = true;
    }

    
    void Update()
    {


        try
        {
            status = spiderMainScript.GetStatus();
            CheckStatus(status);
        }
        catch(UnityException)
        {
            isActive = false;
        }
    }

    void CheckStatus(string status)
    {
        if (status == "spawning")
        {
            shield_animator.SetBool("spawning", true);
            shield_animator.SetBool("attacking", false);
            shield_animator.SetBool("attackable", false);
            isActive = true;
        }
        else if (status == "attacking")
        {
            shield_animator.SetBool("spawning", false);
            shield_animator.SetBool("attacking", true);
            shield_animator.SetBool("attackable", false);
            isActive = true;
        }
        else if (status == "attackable")
        {
            shield_animator.SetBool("spawning", false);
            shield_animator.SetBool("attacking", false);
            shield_animator.SetBool("attackable", true);
            isActive = false;
        }
    }
}
