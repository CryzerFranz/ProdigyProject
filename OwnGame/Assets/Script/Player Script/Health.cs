using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    //Scriptable Objects
        //UI
        [SerializeField]
        private Canvas_Manager playerUI;
        //------
        [SerializeField]
        private PlayerStats playerStats;
    //-------------------------------------


    public Healthbar healthbar;
    private Animator animator;

    private Transform playerRespawnPoint;

    public bool IsPlayerDead
    {
        get
        {
            return playerStats.currentHealth <= 0;
        }
    }

    void Awake()
    {
        animator = GetComponent<Animator>();

        playerStats.currentHealth = playerStats.health;
        healthbar.SetMaxHealth(playerStats.currentHealth);
    }
    private void Start()
    {
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
                playerUI.Canvas_Dead_Transition.SetActive(false);
                playerUI.Canvas_Player_UI.SetActive(true);
                this.GetComponent<Movement>().enabled = true;
            }
        }
    }
    public void TakeDamage(float damage)
    {
        if(!IsPlayerDead)
        {
            ///// TESTPHASE
            damage -= (damage * (playerStats.defense * 0.1f));
            ///// TESTPHASE

            playerStats.currentHealth -= damage;
            healthbar.SetHealth(playerStats.currentHealth);
            if (IsPlayerDead)
            {  
                animator.SetTrigger("isDead");
                playerUI.Canvas_Dead_Transition.SetActive(false);
                playerUI.Canvas_Player_UI.SetActive(true);
            }
        }  
    }

    public void ResetHealth()
    {
        playerStats.currentHealth = playerStats.health;
        healthbar.slider.value = playerStats.currentHealth;
    }

    public float increaseHealth
    {
        get
        {
            return playerStats.health;
        }
        set { playerStats.health += value; }
    }
}
