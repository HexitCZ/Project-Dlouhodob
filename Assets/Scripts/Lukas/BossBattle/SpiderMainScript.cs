using UnityEngine;

public class SpiderMainScript : MonoBehaviour
{

    [SerializeField]
    [Space]
    private bool spawning = true;

    [SerializeField]
    [Space]
    public bool attacking = false;

    [SerializeField]
    [Space]
    public bool attackable = false;
    [Space]
    //objekty v prvni vlne

    [SerializeField]
    private Transform hover1;

    [SerializeField]
    private Transform hover2;

    [SerializeField]
    private Transform drone1;

    [SerializeField]
    private Transform drone2;

    [Space]

    //objekty ve druhe vlne

    [SerializeField]

    private Transform hover3;

    [SerializeField]
    private Transform hover4;

    [SerializeField]
    private Transform hover5;

    [SerializeField]
    private Transform drone3;

    [SerializeField]
    private Transform drone4;

    [SerializeField]
    private Transform drone5;

    [Space]

    //objekty ve treti vlne

    [SerializeField]

    private Transform hover6;
    [SerializeField]

    private Transform hover7;
    [SerializeField]

    private Transform hover8;
    [SerializeField]

    private Transform hover9;
    [SerializeField]

    private Transform drone6;
    [SerializeField]

    private Transform drone7;
    [SerializeField]

    private Transform drone8;
    [SerializeField]

    private Transform drone9;

    [Space]
    //objekty ve ctvrte vlne
    [SerializeField]
    private Transform hover10;
    [SerializeField]

    private Transform hover11;
    [SerializeField]

    private Transform hover12;
    [SerializeField]

    private Transform hover13;
    [SerializeField]

    private Transform hover14;
    [SerializeField]

    private Transform hover_heavy;
    [SerializeField]

    private Transform drone10;

    [SerializeField]
    private Transform drone11;
    [SerializeField]

    private Transform drone12;
    [SerializeField]

    private Transform drone13;
    [SerializeField]

    private Transform drone14;
    [SerializeField]

    private int spawnPhase_counter;

    [SerializeField]
    [Space]
    private CannonScript cannonScript;

    [SerializeField]
    [Space]
    private int round;

    [SerializeField]
    [Space]
    private WaveController waveController;

    [SerializeField]
    [Space]
    private WaveChecker waveChecker;

    [SerializeField]
    [Space]
    private PillarScript[] pillars;

    public SpiderHealthBarScript spiderHealthBarScript;

    private bool firstTime;

    private bool firstTimeInvoke;

    private float health;

    private int pillar_broken_count;
    void Start()
    {
        spawning = true;
        attacking = false;
        attackable = false;
        spawnPhase_counter = 1;
        round = 1;
        pillar_broken_count = 0;
    }
    /// <summary>
    /// Hlavni misto pro logiku boje s pavoukem
    /// </summary>
    void Update()
    {
        if (spawning)
        {
            firstTime = true;
            Debug.Log("spawning");
            if (spawnPhase_counter == 1 && round == 1)
            {
                waveController.SpawnPhase1(hover1, hover2, drone1, drone2);

                if (waveChecker.Wave1Complete(hover1, hover2, drone1, drone2))
                {
                    attacking = true;
                    spawning = false;
                    firstTimeInvoke = true;
                }
            }
            else if (spawnPhase_counter == 2 && round == 2)
            {
                waveController.SpawnPhase2(hover3, hover4, hover5, drone3, drone4, drone5);

                if (waveChecker.Wave2Complete(hover3, hover4, hover5, drone3, drone4, drone5))
                {
                    attacking = true;
                    spawning = false;
                    firstTimeInvoke = true;
                }
            }
            else if (spawnPhase_counter == 3 && round == 3)
            {
                waveController.SpawnPhase3(hover6, hover7, hover8, hover9, drone6, drone7, drone8, drone9);

                if (waveChecker.Wave3Complete(hover6, hover7, hover8, hover9, drone6, drone7, drone8, drone9))
                {
                    attacking = true;
                    spawning = false;
                    firstTimeInvoke = true;
                }
            }
            else if (spawnPhase_counter == 4 && round == 4)
            {
                waveController.SpawnPhase4(hover10, hover11, hover12, hover13, hover14, hover_heavy, drone10, drone11, drone12, drone13, drone14);

                if (waveChecker.Wave4Complete(hover10, hover11, hover12, hover13, hover14, hover_heavy, drone10, drone11, drone12, drone13, drone14))
                {
                    attacking = true;
                    spawning = false;
                    firstTimeInvoke = true;
                }
            }
        }
        else if (attacking)
        {
            Debug.Log("attacking");

            if (firstTimeInvoke)
            {
                InvokeRepeating("ShootCannon", 3, 3);
                firstTimeInvoke = false;
            }
            bool new_broken_pillar = NewBrokenPillar();

            if (new_broken_pillar)
            {
                attackable = true;
                attacking = false;
            }
            health = spiderHealthBarScript.GetHealth();
        }
        else if (attackable)
        {
            Debug.Log("attackable");
            CancelInvoke();
            
            if (firstTime)
            {
                round++;
                firstTime = false;
                spawnPhase_counter++;
            }


            /*if (Mathf.Ceil(spiderHealthBarScript.GetHealth()) == Mathf.Ceil(100f - ((round - 1)  * 25f)))
            {*/
                attackable = false;
                spawning = true;
            //}
        }
    }

    /// <summary>
    /// Prohledani kolekce piliru pro potencialni nalezeni nove zniceneho sloupu
    /// </summary>
    /// <returns></returns>

    bool NewBrokenPillar()
    {
        int count = 0;
        bool output;

        foreach (PillarScript pillar in pillars)
        {
            if (pillar.IsBroken() == true)
            {
                count++;
            }
        }
        if (count > pillar_broken_count)
        {
            pillar_broken_count = count;
            output = true;
        }
        else
        {
            output = false;
        }
        return output;
    }

    /// <summary>
    /// Strili z kanonu
    /// </summary>

    void ShootCannon()
    {
        cannonScript.Shoot();
    }

    /// <summary>
    /// Vraci hodnotu promenne round
    /// </summary>
    /// <returns></returns>
    public int GetRound()
    {
        Debug.Log(round);
        return round;
    }

    /// <summary>
    /// Vraci akci, kterou provadi pavouk
    /// </summary>
    /// <returns></returns>
    public string GetStatus()
    {
        string status = "";

        if (spawning)
        {
            status = "spawning";
        }
        else if (attacking)
        {
            status = "attacking";
        }
        else if (attackable)
        {
            status = "attackable";
        }
        return status;
    }
}