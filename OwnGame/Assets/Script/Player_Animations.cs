using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{
    public static Player_Animations instance;
    void Awake()
    {
        instance = this;
        //Test
        Ability_01_TimeStart = 40.0f;
        Ability_01_TimeEnd = 50.0f;
        //
    }

    public float Ability_01_TimeStart;
    public float Ability_01_TimeEnd;

    public float Ability_02_TimeStart;
    public float Ability_02_TimeEnd;

    public float Ability_03_TimeStart;
    public float Ability_03_TimeEnd;

    public float Ability_04_TimeStart;
    public float Ability_04_TimeEnd;

    public float Ability_05_TimeStart;
    public float Ability_05_TimeEnd;

    public AnimationClip Test_Ability_01;
    public AnimationClip Test_Ability_02;
    public AnimationClip Test_Ability_03;
}
