using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attacking : MonoBehaviour
{

    
    public Health playerHealth;
   
    private BasicEnemyStats enemyStat; 
    
    NavMeshAgent navMesh;

    public float attackSpeed = 1f;
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

    public void BasicAttack()
    {
        if(attackCooldown <= 0f)
        {
            playerHealth.TakeDamage(enemyStat.Damage);
            attackCooldown = 1f / attackSpeed;
        }
    }

    public void SpecialAttack()
    {

    }
}
