using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpWindow : MonoBehaviour
{
    public GameObject help;
    public void ShowHelp()
    {
        help.SetActive(true);
    }

    public void HideHelp()
    {
        help.SetActive(false);
    }
}
