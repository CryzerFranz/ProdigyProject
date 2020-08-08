using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meele_Weapon : MonoBehaviour
{
    protected Animator animator;

    public Transform attackPoint;
    public Transform attackPointEnd;

    public LayerMask enemyLayers;

    protected int damage;
    protected float critChance;
    
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float CritChance
    {
        get { return critChance; }
        set { critChance = value; }
    }

    void hitEnemies()
    {
        Collider[] hitEnemies = Physics.OverlapCapsule(attackPoint.position, attackPointEnd.position, 2, enemyLayers);
        Debug.Log(hitEnemies.Length);
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log(enemy.name);
            enemy.GetComponent<BasicEnemyStats>().takeDamage(20);
        }
    }


}
