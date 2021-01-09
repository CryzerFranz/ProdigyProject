using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    protected static bool sawPlayer = false;

    public static EnemyManager instance;
    void Awake()
    {
        instance = this;
    }

    public Attacking Basic_Psycho_attacking_Script;
}
