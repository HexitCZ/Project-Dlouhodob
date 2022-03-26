using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerUI : MonoBehaviour
{
    public GameObject upgrade;
    public GameObject hud;
    public float fpsUpdateCooldown;
    public TMP_Text fps_text;

    private void Start()
    {
        InvokeRepeating("UpdateFPS",0.0f , fpsUpdateCooldown);
    }

    private void UpdateFPS()
    {
        fps_text.text = "FPS: " + Math.Round(1 / Time.deltaTime, 1);
    }


    public void OnUpgradeClick(InputAction.CallbackContext inp)
    {
        if (inp.performed)
        {
            upgrade.SetActive(!upgrade.activeSelf);
            hud.SetActive(!hud.activeSelf);
        }
    }

}
