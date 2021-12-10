using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
    public float currHealth;
    public float maxHealth = 100;
    public float enemyStats;

    public float BasicStats;
    public float TankStats;
    public float FastStats;
    public float BoomerStats;

    public float currStamina;
    public float maxStamina;

    

    public bool isDead = false;

    public virtual void CheckHealth()
    {
        if (currHealth >= maxHealth)
            currHealth = maxHealth;
        if (currHealth <= 0)
        {
            currHealth = 0;
            SceneManager.UnloadSceneAsync(1);
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
            isDead = true;
        }
    }

    public virtual void CheckStamina()
    {
        if (currStamina >= maxStamina)
            currStamina = maxStamina;
        if (currStamina <= 0)
        {
            
            currStamina = 0;
        }
    }

    public virtual void die()
    {
        //override
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
    }
}
