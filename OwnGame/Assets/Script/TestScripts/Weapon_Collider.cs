using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Collider : MonoBehaviour
{

    private Attacking attack;
    private void Start()
    {
        attack = EnemyManager.instance.Basic_Psycho_attacking_Script;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            attack.BasicAttack();
        }
    }
}
