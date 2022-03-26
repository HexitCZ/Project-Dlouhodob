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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TeleportTo();
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
