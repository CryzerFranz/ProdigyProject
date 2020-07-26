using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{

    public PlayerStats playerStats;
    private float maxHealth;
    private float currentHealth;
    public Healthbar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = playerStats.LifePoints;
        Debug.Log(maxHealth);
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }
}
