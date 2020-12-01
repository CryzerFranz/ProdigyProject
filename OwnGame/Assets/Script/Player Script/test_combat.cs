using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test_combat : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;

    public Transform attackPoint;
    public Transform attackPointEnd;

    private NavMeshAgent playerNavMesh;

    private GameObject weapon;
    private float attackRange = 0f;
    
    [SerializeField]
    private LayerMask enemyLayers;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerNavMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            attackRange = 2f;
            playerNavMesh.ResetPath();
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Melee_Spalten");
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }

    void hitEnemies(GameObject _Weapon)
    {
        Collider[] hitEnemies = Physics.OverlapCapsule(attackPoint.position, attackPointEnd.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log(enemy.name);
            enemy.GetComponent<BasicEnemyStats>().takeDamage(_Weapon.GetComponent<Wep_Sword>().Damage);
        }
    }

}
