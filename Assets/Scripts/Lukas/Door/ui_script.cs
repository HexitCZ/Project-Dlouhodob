using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class ui_script : MonoBehaviour
{
    [Space]
    [Header("Canvas")]
    public Text pressText;

    void Start()
    {
       
    }

    void Update()
    {
        
    }
    
    public void view_press_e()
    {
        pressText.text = "Press E";
    }
    
    public void view_none()
    {
        pressText.text = "";
    }
}
