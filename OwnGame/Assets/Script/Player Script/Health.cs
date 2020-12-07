using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    //Canvas

    public Healthbar healthbar;

    private GameObject playerUI; 
    private GameObject deathTransition;

    private PlayerStats playerStats;
    private Animator animator;

    private Transform playerRespawnPoint;

    // maxHealth = Maximale Lebenspunkte
    private float maxHealth;
    // currentHealth = aktuelle Lebenspunkte
    private float currentHealth;

    public bool IsPlayerDead
    {
        get
        {
            return currentHealth <= 0;
        }
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();

        maxHealth = playerStats.LifePoints;
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }
    private void Start()
    {
        deathTransition = PlayerManager.instance.deathTransition;
        playerUI = PlayerManager.instance.userInterface;
        playerRespawnPoint = PlayerManager.instance.respawnPoint.transform;
    }

    private void Update()
    {
        if(IsPlayerDead)
        {
            this.GetComponent<Movement>().enabled = false;
            this.GetComponent<NavMeshAgent>().ResetPath();
            if(Input.anyKeyDown)
            {
                ResetHealth();
                this.GetComponent<NavMeshAgent>().Warp(playerRespawnPoint.position);
                animator.SetTrigger("Respawn");
                deathTransition.SetActive(false);
                PlayerManager.instance.userInterface.SetActive(true);
                this.GetComponent<Movement>().enabled = true;
            }
        }
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
        healthbar.slider.value = currentHealth;
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
