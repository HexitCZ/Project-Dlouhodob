using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour
{

    public bool secretMessage;
    public GameObject secretMessageText;
    
    
    /// <summary>
    /// Loads endgame variable for showing secretMessageText in hub scene
    /// </summary>
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

    /// <summary>
    ///  Saves endgame variable for showing secretMessageText in hub scene when player enters
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("endgame", 1);
            PlayerPrefs.Save();
        }
    }
}
