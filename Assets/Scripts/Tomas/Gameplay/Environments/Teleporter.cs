using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public string targetScene;

    public static Teleporter instance;

    private void Start()
    {
        instance = this;
    }

    private bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !triggered)
        {
            triggered = true;
            Debug.LogWarning("saving");
            SaveProgress.instance.Save();
            PlayerPrefs.SetInt("level2unlocked", 1);
            Invoke("TeleportTo", 0.2f);
        }
    }

    public void SetTarget(string newScene)
    {
        targetScene = newScene;
    }


    public void TeleportTo()
    {
        
        SceneManager.LoadScene(targetScene);
    }


}
