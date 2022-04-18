using UnityEngine;

public class SpiderShieldScript : MonoBehaviour
{

    [SerializeField]
    [Space]
    private Animator shield_animator;

    private bool isActive;

    private string status;

    [SerializeField]
    [Space]
    private SpiderMainScript spiderMainScript;

    [SerializeField]
    [Space]
    private AI_Walker aiWalker;

    private int round;

    [SerializeField]
    [Space]
    private bool spiderMeshIsAssignable;

    void Start()
    {
        isActive = true;
        round = 1;
        spiderMeshIsAssignable = true;
    }
    /// <summary>
    /// Kontrola stavu stitu a mozne blokovani poskozeni od hrace v pripade, ze je stit zapnuty
    /// </summary>
    void Update()
    {
        round = spiderMainScript.GetRound();
        if (spiderMeshIsAssignable)
        {

            try
            {

                if (spiderMainScript.attacking)
                {
                    this.GetComponent<MeshCollider>().enabled = false;
                }
            }
            catch (UnassignedReferenceException)
            {
                spiderMeshIsAssignable = false;
            }
        }

        if (isActive && !spiderMainScript.attackable)
        {
            if (round == 1)
            {
                aiWalker.health = 100.0f;
            }
            else if (round == 2)
            {
                aiWalker.health = 75.0f;
            }
            else if (round == 3)
            {
                aiWalker.health = 50.0f;
            }
            else if (round == 4)
            {
                aiWalker.health = 25.0f;
            }
            aiWalker.health = 100.0f;
        }

        try
        {
            status = spiderMainScript.GetStatus();
            CheckStatus(status);
        }
        catch (UnityException)
        {
            isActive = false;
        }
    }
    /// <summary>
    /// Kontroluje nynejsi akci pavouka a podle toho nastavuje animator
    /// </summary>
    /// <param name="status"></param>
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
        else
        {
            isActive = true;
        }
    }
}
