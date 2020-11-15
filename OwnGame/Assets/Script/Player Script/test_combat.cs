using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_combat : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;

    public Transform attackPoint;
    public Transform attackPointEnd;


    private GameObject weapon;
    private float attackRange = 0f;
    
    [SerializeField]
    private LayerMask enemyLayers;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            attackRange = 2f;
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Melee_Spalten");
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
