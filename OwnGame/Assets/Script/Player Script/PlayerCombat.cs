using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCombat : MonoBehaviour
{
    static public PlayerCombat instance;
    private void Awake()
    {
        instance = this;    
    }

    Animator animator;

    private NavMeshAgent playerNavMesh;
    private Movement playerMovement;

    private GameObject weapon;
    private float attackRange = 0f;
    
    [SerializeField]
    private LayerMask enemyLayers;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerNavMesh = GetComponent<NavMeshAgent>();
        playerMovement = GetComponent<Movement>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Pressed 1");
            animator.SetFloat("Forward", 0);
            attackRange = 2f;
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Ability_01");
        playerMovement.enabled = false;
        playerNavMesh.ResetPath();
        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }

    public void hitEnemies(Collider other, float damageValue)
    {
            Debug.Log(other.name);
            other.GetComponent<BasicEnemyStats>().takeDamage(damageValue);
    }
}
