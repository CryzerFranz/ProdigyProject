using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attacking : MonoBehaviour
{
    // Gegner soll nach Respawn vom Spieler, denn Spieler nicht mehr angreifen
    // Gegner soll nach Respawn vom Spieler, ihren Path resetten.


    public Animator animator;
    private Health playerHealth;
   
    private BasicEnemyStats enemyStat; 
    
    public float attackSpeed = 0.25f;
    public bool inRange = false;

    private float attackCooldown = 0f;
    private float heavyAttackCooldown = 3f;
    // Stärkeren Angriff versuchen // TEST
    private float damageMultiplicator = 1f;
    private float damageCritMultiplicator = 1f;


    private System.Random critNumber = new System.Random();


    // Start is called before the first frame update
    void Start()
    {
        enemyStat = GetComponent<BasicEnemyStats>();
        playerHealth = PlayerManager.instance.oPlayer.GetComponent<Health>();
    }

    private void Update()
    {
        // Cooldown for basic-Attack
        attackCooldown -= Time.deltaTime;

        if (inRange)
        {
            heavyAttackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0f)
            {
                animator.SetTrigger("attack");
                attackCooldown = 1f / attackSpeed;
            }
            if (heavyAttackCooldown <= 0f)
            {
                animator.SetTrigger("attack");
                heavyAttackCooldown = 3f / attackSpeed;
                attackCooldown = 1f / attackSpeed;
                damageMultiplicator = 2f;
            }
        }
    }

    public void BasicAttack()
    {
        float critChance = (float)critNumber.NextDouble();
        if (critChance <= enemyStat.CritChance)
        {
            damageCritMultiplicator = 1.5f;
            Debug.Log("Crit");
        }
        playerHealth.TakeDamage(enemyStat.Damage * damageMultiplicator * damageCritMultiplicator);
        Debug.Log("Damage: " + enemyStat.Damage * damageMultiplicator * damageCritMultiplicator);
        damageMultiplicator = 1f;
        damageCritMultiplicator = 1f;
    }

    public void SpecialAttack()
    {

    }
}
