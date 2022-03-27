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

    public TMP_Text level_text;
    public TMP_Text xp_text;
    public TMP_Text bolts_text;

    public TMP_Text upgradePoints_text;

    private void Start()
    {
        InvokeRepeating("UpdateFPS",0.0f , fpsUpdateCooldown);
        
    }

    private void FixedUpdate()
    {
        level_text.text = "Level\n\r" + ExperienceSystem.instance.level;
        xp_text.text = "XP\n\r" + ExperienceSystem.instance.xp;
        bolts_text.text = "Bolts\n\r" + PlayerCurrency.instance.amount;
        upgradePoints_text.text = "Upgrade Points\n\r" + ExperienceSystem.instance.upgradePoints;
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
