using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealthController.instance.AddHealth(-1000);
        }
    }
}
