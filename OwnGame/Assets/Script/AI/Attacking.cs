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
    
    NavMeshAgent navMesh;

    public float attackSpeed = 0.25f;
    private float attackCooldown = 0f;
   
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        enemyStat = GetComponent<BasicEnemyStats>();
        playerHealth = PlayerManager.instance.oPlayer.GetComponent<Health>();

    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void BasicAttackAnimation()
    {
            if (attackCooldown <= 0f)
            {
                animator.SetTrigger("attack");
                attackCooldown = 1f / attackSpeed;
            }   
    }

    public void BasicAttack()
    {
        playerHealth.TakeDamage(enemyStat.Damage);
    }

    public void SpecialAttack()
    {

    }
}
