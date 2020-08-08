using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wep_Sword : MonoBehaviour
{
    public Transform attackPoint;
    public Transform attackPointEnd;

    public LayerMask enemyLayers;

    private int damage = 20;
    private float critChance = 1f;

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

}
