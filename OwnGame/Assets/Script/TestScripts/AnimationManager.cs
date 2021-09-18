using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Effects;

public class AnimationManager : MonoBehaviour
{
    public bool animationIsPlayer = false;
    private Animator animator;

    private Dodge dodge;
    private Movement playerMovement;
    private NavMeshAgent playerNavMeshAgent;
    private PlayerCombat pc;

    public AbilityTImeBar abilityTimeBar;
    AnimatorClipInfo[] animClip;

    void Start()
    {
        pc = PlayerCombat.instance;
           animator = GetComponent<Animator>();
        animClip = animator.GetCurrentAnimatorClipInfo(0);
        playerMovement = GetComponent<Movement>();
        playerNavMeshAgent = GetComponent<NavMeshAgent>();
        dodge = GetComponent<Dodge>();
        for (int i = 0; i < animClip.Length; i++)
        {
            //Debug.Log(animClip[i].clip);
        }
    }
    void Update()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Ability_01") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            if(    pc.firstAnimationPressed == false)
                pc.firstAnimationPressed = true;


            if (abilityTimeBar.slider.value <= abilityTimeBar.slider.maxValue)
            {
                abilityTimeBar.SetValue();
            }
        }
        else
        {
            if (pc.firstAnimationPressed == true)
            {
                abilityTimeBar.slider.value = 0.0f;
                playerMovement.enabled = true;
                pc.firstAnimationPressed = false;
            }
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("rollBack")) //maybe need fix
        {
            transform.position = Vector3.MoveTowards(transform.position, dodge.PortPosition, 30 * Time.deltaTime);
        }
    }

    public void animationDone()
    {
        playerMovement.enabled = true;
    }
}
