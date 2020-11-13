using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Spieler Attribute

    float lifePoints = 500f;
    float defense = 1f;
    float critChance = 1f;
    float dexterity = 1f;
    float strength = 20f;

    public float LifePoints
    {
        get { return lifePoints; }
        set { lifePoints += value; }
    }

    public float Defense
    {
        get { return defense; }
        set { defense += value; }
    }

    public float CritChance
    {
        get { return critChance; }
        set { critChance += value; }
    }

    public float Dexterity
    {
        get { return dexterity; }
        set { dexterity += value; }
    }

    public float Strength
    {
        get { return strength; }
        set { strength += value; }
    }
}
