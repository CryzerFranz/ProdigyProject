using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCombat : MonoBehaviour
{
    static public PlayerCombat instance;
    private void Awake()
    {
        instance = this;    
    }

    private Animator animator;

    private NavMeshAgent playerNavMesh;
    private Movement playerMovement;

    private RuntimeAnimatorController ac;
    private AbilityProzentTimeBar abilitiesStartEndValue;

    public AbilityTImeBar abilityTimeBar;

    [SerializeField]
    private LayerMask enemyLayers;

    private InputManager input;

    private float timeOfAnimation;

    public bool firstAnimationPressed;

    void Start()
    {
        abilitiesStartEndValue = abilityTimeBar.abilityKeyPosition;
        input = InputManager.instance;
        firstAnimationPressed = false;
        animator = GetComponent<Animator>();
        playerNavMesh = GetComponent<NavMeshAgent>();
        playerMovement = GetComponent<Movement>();
        ac = animator.runtimeAnimatorController;
    }
   
    void Update()
    {
        if (input.GetKeyDown(KeybindingActions.ability_01) && firstAnimationPressed == false)
        {
            firstAnimationPressed = true;
            abilityTimeBar.setKeyGradientValue(abilitiesStartEndValue.Ability_01_TimeStart, abilitiesStartEndValue.Ability_01_TimeEnd);
            animator.SetFloat("Forward", 0);
            timeOfAnimation = getAnimationLengthInFrame("melee_spalten_idle");
            abilityTimeBar.setSliderAdditionsValue(1);



            abilityTimeBar.SetMaxValue(timeOfAnimation);
          
            //Debug.Log(timeOfAnimation);
            //abilityTimeBar.setSliderAdditionsValue(1);
            executeAbility("Ability_01");
           
        }
     
    }
    void executeAbility(string abilityName)
    {
        animator.SetTrigger(abilityName);
        playerMovement.enabled = false;
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
                result += seconds[0] * (float)ac.animationClips[i].frameRate;
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
