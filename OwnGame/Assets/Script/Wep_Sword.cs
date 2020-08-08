using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wep_Sword : Meele_Weapon
{
    void Start()
    {
        //Attribute
        Damage = 20;
        CritChance = 15f;

        animator.GetComponentInParent<Animator>();
    }


}
