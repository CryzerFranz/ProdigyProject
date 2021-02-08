using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject, ISerializationCallbackReceiver
{
    [NonSerialized]
    public float currentHealth = 0;
    
    public float health = 500f;
    public float defense = 1f;
    public float critChance = 1f;
    public float dexterity = 1f;
    public float strength = 20f;

    public void OnAfterDeserialize()
    {
        //evtl. runtime zu standardwert initen
    }

    public void OnBeforeSerialize()
    {
        currentHealth = health;
    }
}
