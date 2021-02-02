using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{
    public static Player_Animations instance;
    void Awake()
    {
        instance = this;
    }

    public AnimationClip Test_Ability_01;
    public AnimationClip Test_Ability_02;
    public AnimationClip Test_Ability_03;
}
