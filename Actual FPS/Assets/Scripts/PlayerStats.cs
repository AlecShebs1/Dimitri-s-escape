using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update


    playerUI  playerui;
    GameController gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        playerui = GetComponent<playerUI>();

        maxHealth = 100;
        currHealth = maxHealth;
   

        maxStamina = 100;
        currStamina = maxStamina;

        SetStats();
    }

    public override void die()
    {
        Debug.Log("ded");
        gameController.reloadLevel();
       
    }

    void SetStats() 
    {
        playerui.playerHealth.text = currHealth.ToString("0");
        playerui.playerStamina.text = currStamina.ToString("0");
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        SetStats();
    }

    public override void CheckStamina()
    {
        base.CheckStamina();
        SetStats();
    }
    
}
