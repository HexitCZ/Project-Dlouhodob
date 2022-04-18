using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMainScript : MonoBehaviour
{

    [SerializeField]
    [Space]
    private bool spawning = true;

    [SerializeField]
    [Space]
    private bool attacking = false;

    [SerializeField]
    [Space]
    private bool attackable = false;

    //first wave

    private Transform hover1;
    
    private Transform hover2;

    private Transform drone1;

    private Transform drone2;

    //second wave

    private Transform hover3;
    
    private Transform hover4;
    
    private Transform hover5;

    private Transform drone3;

    private Transform drone4; 

    private Transform drone5;

    //third wave

    private Transform hover6;

    private Transform hover7;

    private Transform hover8;

    private Transform hover9;

    private Transform drone6;

    private Transform drone7;

    private Transform drone8;

    private Transform drone9;

    //fourth wave

    private Transform hover10;

    private Transform hover11;

    private Transform hover12;

    private Transform hover13;

    private Transform hover14;

    private Transform hover_heavy;

    private Transform drone10;

    private Transform drone11;

    private Transform drone12;

    private Transform drone13;

    private Transform drone14;

    private int spawnPhase_counter;

    void Start()
    {
        spawning = true;
        attacking = false;
        attackable = false;
        spawnPhase_counter = 1;
    }

    void Update()
    {
        if (spawning)
        {
            if(spawnPhase_counter == 1)
            {
                SpawnPhase1();
            }
            else if(spawnPhase_counter == 2)
            {
                SpawnPhase2();
            }
            else if(spawnPhase_counter == 3)
            {
                SpawnPhase3();
            }
            else if(spawnPhase_counter == 4)
            {
                SpawnPhase4();
            }
        }
        else if (attacking)
        {

        }
        else if (attackable)
        {

        }
    }

    void SpawnPhase1()
    {
        hover1.gameObject.SetActive(true);
        hover2.gameObject.SetActive(true);
        
        drone1.gameObject.SetActive(true);
        drone2.gameObject.SetActive(true);

        spawnPhase_counter = 2;
    }

    void SpawnPhase2()
    {
        hover3.gameObject.SetActive(true);
        hover4.gameObject.SetActive(true);
        hover5.gameObject.SetActive(true);

        drone3.gameObject.SetActive(true);
        drone4.gameObject.SetActive(true);
        drone5.gameObject.SetActive(true);

        spawnPhase_counter = 3;

    }

    void SpawnPhase3()
    {
        hover6.gameObject.SetActive(true);
        hover7.gameObject.SetActive(true);
        hover8.gameObject.SetActive(true);
        hover9.gameObject.SetActive(true);

        drone6.gameObject.SetActive(true);
        drone7.gameObject.SetActive(true);
        drone8.gameObject.SetActive(true);
        drone9.gameObject.SetActive(true);
    
        spawnPhase_counter = 4;
    }

    void SpawnPhase4()
    {
        hover10.gameObject.SetActive(true);
        hover11.gameObject.SetActive(true);
        hover12.gameObject.SetActive(true);
        hover13.gameObject.SetActive(true);
        hover14.gameObject.SetActive(true);

        hover_heavy.gameObject.SetActive(true);

        drone10.gameObject.SetActive(true);
        drone11.gameObject.SetActive(true);
        drone12.gameObject.SetActive(true);
        drone13.gameObject.SetActive(true);
        drone14.gameObject.SetActive(true);
    }
}
