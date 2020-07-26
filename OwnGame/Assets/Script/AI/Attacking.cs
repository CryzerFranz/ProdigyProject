using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attacking : MonoBehaviour
{

    public Health playerHealth;
    NavMeshAgent navMesh;

    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    public float basicDamage;
   
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void BasicAttack(float dmg)
    {
        if(attackCooldown <= 0f)
        {
            playerHealth.TakeDamage(dmg);
            attackCooldown = 1f / attackSpeed;
        }
    }

    public void SpecialAttack()
    {

    }
}
