using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class WaveSystem : MonoBehaviour
{
    public bool DEBUG_START;
    public Door_script door;
    public GameObject spawnVFX;
    public float spawnSlowDown;
    public GameObject[] waveObjects;
    private List<Wave> waves;
    private int currentWave;

    private void Awake()
    {
        

        waves = new List<Wave>();

        for (int i = 0; i < waveObjects.Length; i++)
        {
            //print("wave " + i + "  " + waveObjects[i].transform.childCount);
            waves.Add(new Wave());
            waves[i].enemies = new List<GameObject>();

            for (int j = 0; j < waveObjects[i].transform.childCount; j++)
            {
                //print("enemy " + j);
                waves[i].enemies.Add(waveObjects[i].transform.GetChild(j).gameObject);

            }
            
        }


        if (DEBUG_START)
        {
            StartWaves();
            DEBUG_START = false;
        }
    }



    /// <summary>
    /// Starting point of a wave system. Call it to start WaveSystem.
    /// </summary>
    public void StartWaves()
    {
        //print("start");
        NextWave();
        InvokeRepeating("CheckAIStatus", 0.3f, 0.3f);
    }

    /// <summary>
    /// It calls NextWave if all enemies are dead.
    /// </summary>
    private void CheckAIStatus()
    {
        
        for (int i = 0; i < waves.Count; i++)
        {
            for (int j = 0; j < waves[i].enemies.Count; j++)
            {
                if (waves[i].enemies[j] == null)
                {
                    continue;
                }

                if (waves[i].enemies[j].activeSelf)
                {
                    return;
                }
            }
        }
        currentWave += 1;
        NextWave();
    }

    /// <summary>
    /// Starts next wave.
    /// </summary>
    private void NextWave()
    {
        //print("nextwave");
        if (currentWave >= waves.Count)
        {
            
            PlayerPrefs.SetInt("level2unlocked", 1);
            PlayerPrefs.Save();
            //Debug.Log("Door OPEN");
            EndWaves();
            return;
        }

        for (int i = 0; i < waves[currentWave].enemies.Count; i++)
        {
            //print("spawncall");
            StartCoroutine(SpawnEnemy(waves[currentWave].enemies[i]));
            //SpawnEnemy(waves[currentWave].enemies[i]);
        }

    }

    

    private IEnumerator SpawnEnemy(GameObject enemy)
    {
        //print("spawn");
        GameObject vfx = Instantiate(spawnVFX, enemy.transform.position, Quaternion.identity);
        //vfx.GetComponent<VisualEffect>().Play();
        Destroy(vfx,5);

        yield return new WaitForSeconds(spawnSlowDown);
        enemy.SetActive(true);
        
        //enemy.GetComponent<AI_Base>().enabled = true;
    }

    

    private void EndWaves()
    {
        CancelInvoke();
    }

    [System.Serializable]
    public class Wave
    {
        public List<GameObject> enemies;
    }
}
