using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class WaveSystem : MonoBehaviour
{
    public door_script door;
    public GameObject spawnVFX;
    public float spawnSlowDown;
    public Wave[] waves;
    private int currentWave;

    /// <summary>
    /// Starting point of a wave system. Call it to start WaveSystem.
    /// </summary>
    public void StartWaves()
    {
        InvokeRepeating("CheckStatus", 0.2f, 0.2f);
    }

    /// <summary>
    /// It calls NextWave if all enemies are dead.
    /// </summary>
    private void CheckAIStatus()
    {
        if (currentWave == 0)
        {
            NextWave();
        }

        for (int i = 0; i < waves.Length; i++)
        {
            for (int j = 0; j < waves[i].enemies.Length; j++)
            {
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
        if (currentWave > waves.Length)
        {
            // door.Open();
            Debug.Log("Door OPEN");
            EndWaves();
            return ;
        }
        for (int i = 0; i < waves[currentWave].enemies.Length; i++)
        {
            SpawnEnemy(waves[currentWave].enemies[i]);
        }
    }

    

    private IEnumerator SpawnEnemy(GameObject enemy)
    {
        GameObject vfx = Instantiate(spawnVFX, enemy.transform.position, Quaternion.identity);
        vfx.GetComponent<VisualEffect>().Play();
        Destroy(vfx,5);

        yield return new WaitForSeconds(spawnSlowDown);
        enemy.SetActive(true);
        
        //enemy.GetComponent<AI_Base>().enabled = true;
    }

    private void EndWaves()
    {

        CancelInvoke();
    }

    public class Wave
    {
        public string name;
        public GameObject[] enemies;
    }
}
