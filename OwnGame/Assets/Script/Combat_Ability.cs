using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Ability : MonoBehaviour
{

    private InputManager inputManager;
    private Animator animator;
    private string actual_ability_string;
    //private Player_Attack_Animation AnimationGetter;

    private AnimatorOverrideController animOverride;
    
    void Start()
    {
        animator = GetComponent<Animator>();
       inputManager = InputManager.instance ;
       animOverride = new AnimatorOverrideController();
       animOverride.runtimeAnimatorController = animator.runtimeAnimatorController;
    }

    void Update()
    {
        if(inputManager.GetKeyDown(KeybindingActions.ability_01))
        {
            animOverride[actual_ability_string] = Player_Animations.instance.Test_Ability_02;
            actual_ability_string = Player_Animations.instance.Test_Ability_02.ToString();
            animator.runtimeAnimatorController = animOverride;
            animator.SetTrigger("Melee_Spalten");
            Debug.Log("Ability one");
        }
        if (inputManager.GetKeyDown(KeybindingActions.ability_02))
        {
            animOverride[actual_ability_string] = Player_Animations.instance.Test_Ability_03;
            actual_ability_string = Player_Animations.instance.Test_Ability_03.ToString();
            animator.runtimeAnimatorController = animOverride;
            animator.SetTrigger("melee_spalten");
            Debug.Log("Ability 2");
        }
    }
}
