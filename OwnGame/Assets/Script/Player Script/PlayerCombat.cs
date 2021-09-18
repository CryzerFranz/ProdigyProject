using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCombat : MonoBehaviour
{
    /*
    Variable:
        firstAnimationPressed -> True = Ability is in Progress. Player movement is disabled
                              -> False = Ability is no more in Progress. Player movement is enabled
    */
    static public PlayerCombat instance;
   
    public AbilityTImeBar abilityTimeBar;
    
   // private Movement playerMovement;
    private NavMeshAgent playerNavMesh;    
    private Animator animator;
    private RuntimeAnimatorController ac;
    private AbilityProzentTimeBar abilitiesStartEndValue;
    private InputManager input;
    
    public bool firstAnimationPressed;
    
    [SerializeField]
    private LayerMask enemyLayers;
    private float timeOfAnimation;
   
    private void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        playerNavMesh = GetComponent<NavMeshAgent>();
        
        abilitiesStartEndValue = abilityTimeBar.abilityKeyPosition;
        input = InputManager.instance;

        firstAnimationPressed = false;
        ac = animator.runtimeAnimatorController;
    }
   
    void Update()
    {
        if (input.GetKeyDown(KeybindingActions.ability_01) && firstAnimationPressed == false)
        {
            abilityTimeBar.setKeyGradientValue(abilitiesStartEndValue.Ability_01_TimeStart, abilitiesStartEndValue.Ability_01_TimeEnd);
            animator.SetFloat("Forward", 0);
            timeOfAnimation = getAnimationLengthInFrame("melee_spalten_idle");
            abilityTimeBar.SetMaxValue(timeOfAnimation);
            executeAbility("Ability_01");     
        }
     
    }
    void executeAbility(string abilityName)
    {
        animator.SetTrigger(abilityName);
        firstAnimationPressed = true;
       // playerMovement.enabled = false;
        playerNavMesh.ResetPath();
    }
    
    public float getAnimationLengthInFrame(string animationName)
    {
        float result = 0;
        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if (ac.animationClips[i].name == animationName)
            {
                float length = ac.animationClips[i].length;
                double lengthRounded = Math.Round(length, 2);
                string lengthToSplit = lengthRounded.ToString();
                string[] subs = lengthToSplit.Split(',');
                float[] seconds = new float[2];
                for (int ii = 0; ii < subs.Length; ii++)
                {
                    seconds[ii] = float.Parse(subs[ii]);
                }
                result += seconds[0] * (ac.animationClips[i].frameRate * ac.animationClips[i].length);
                result += seconds[1];
                break;
            }
        }
        return result;
    }


    public void hitEnemies(Collider other, float damageValue)
    {
            other.GetComponent<BasicEnemyStats>().takeDamage(damageValue);
    }
}
