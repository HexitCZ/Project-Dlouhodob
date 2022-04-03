using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour
{

    public bool secretMessage;
    public GameObject secretMessageText;
    
    private void Awake()
    {
        PlayerPrefs.SetInt("endgame", 0);
    }



    private void Start()
    {
        if (PlayerPrefs.GetInt("endgame") != 0)
        {
            if (secretMessage)
            {
                secretMessageText.SetActive(true);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("endgame", 1);
        }
    }
}
