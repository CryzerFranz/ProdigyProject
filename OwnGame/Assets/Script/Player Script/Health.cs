using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{

    public Healthbar healthbar;

    private PlayerStats playerStats;
    private Animator animator;

    private float maxHealth;
    private float currentHealth;

    private bool isPlayerDead = false;

    public bool IsPlayerDead
    {
        get
        {
            return currentHealth <= 0;
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();

        maxHealth = playerStats.LifePoints;
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log(IsPlayerDead + "555");
        if(!IsPlayerDead)
        {
            
            ///// TESTPHASE
            damage -= (damage * (playerStats.Defense * 0.1f));
            ///// TESTPHASE

            currentHealth -= damage;
            healthbar.SetHealth(currentHealth);
            if (IsPlayerDead)
            {
                animator.SetTrigger("isDead");
            }
        }
       
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
