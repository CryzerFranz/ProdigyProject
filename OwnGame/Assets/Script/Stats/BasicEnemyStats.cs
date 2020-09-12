using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class BasicEnemyStats : MonoBehaviour
{

    public GameObject FloatingTextPrefab;
    private Animator animator;

    private float health;
    private float damage;
   
    public bool Dead
    {
        get { return health <= 0; }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        health = 80;
        damage = 200;
    }

    public void takeDamage(float dmg)
    {
        health -= dmg;
        if(FloatingTextPrefab)
        {
            ShowFloatingText((int)dmg);
        }

        if (Dead)
        {
            GetComponent<CapsuleCollider>().enabled = false;
            this.enabled = false;
            animator.SetTrigger("Dead");
        }
        
    }
    void ShowFloatingText(int dmg)
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = dmg.ToString();
    }

    public float Health
    {
        get { return health; }
        set { health += value; }
    }

    public float Damage
    {
        get { return damage; }
        set { damage += value; }
    }


}
