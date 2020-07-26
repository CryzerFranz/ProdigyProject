using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{

    private PlayerStats playerStats;
    public Healthbar healthbar;

    private float maxHealth;
    private float currentHealth;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        maxHealth = playerStats.LifePoints;
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        ///// TESTPHASE
        damage -= (damage * (playerStats.Defense * 0.1f));
        ///// TESTPHASE
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set { maxHealth += value; }
    }
}
