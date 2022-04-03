using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour
{

    public bool secretMessage;
    public GameObject secretMessageText;
    
    

    private void Start()
    {
        if (PlayerPrefs.HasKey("endgame"))
        {
            Debug.LogWarning(PlayerPrefs.GetInt("endgame"));
        }

        if (PlayerPrefs.GetInt("endgame") == 1)
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
            PlayerPrefs.Save();
        }
    }
}
