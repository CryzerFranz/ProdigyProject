using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attacking : MonoBehaviour
{

    public Animator animator;
    public Health playerHealth;
   
    private BasicEnemyStats enemyStat; 
    
    NavMeshAgent navMesh;

    public float attackSpeed = 0.25f;
    private float attackCooldown = 0f;
   
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        enemyStat = GetComponent<BasicEnemyStats>();

    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void BasicAttackAnimation()
    {
        if(attackCooldown <= 0f)
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
