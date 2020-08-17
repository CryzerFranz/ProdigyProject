﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    //Canvas

    public Healthbar healthbar;

    private GameObject playerUI; 
    private GameObject deathTransition;

    private PlayerStats playerStats;
    private Animator animator;

    private float maxHealth;
    private float currentHealth;
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

        deathTransition = PlayerManager.instance.deathTransition;
        playerUI = PlayerManager.instance.userInterface;

        maxHealth = playerStats.LifePoints;
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
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
                deathTransition.SetActive(true);
                playerUI.SetActive(false);
            }
        }  
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
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
