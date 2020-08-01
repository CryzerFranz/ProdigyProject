﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_combat : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;

    public Transform attackPoint;

    public float attackRange = 1f;
    public LayerMask enemyLayers;


 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Melee_Spalten");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log(enemy.name);
            enemy.GetComponent<BasicEnemyStats>().takeDamage(20);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
