using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wep_Sword : MonoBehaviour
{
    public LayerMask enemyLayers;
    private PlayerCombat pCombat;

    private int damage = 20;
    private float critChance = 1f;

    private void Start()
    {
        pCombat = PlayerCombat.instance;
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            pCombat.hitEnemies(other, damage);
        }
    }

}
