using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationManager : MonoBehaviour
{
    public bool animationIsPlayer = false;
    private Animator animator;

    private Dodge dodge;
    private Movement playerMovement;
    private NavMeshAgent playerNavMeshAgent;

    public AbilityTImeBar abilityTimeBar;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<Movement>();
        playerNavMeshAgent = GetComponent<NavMeshAgent>();
        dodge = GetComponent<Dodge>();
    }
    void Update()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Ability_01"))
        {
            playerNavMeshAgent.ResetPath();
            abilityTimeBar.SetValue(1 * abilityTimeBar.getMaxValue() / 100);
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("rollBack"))
        {
            transform.position = Vector3.MoveTowards(transform.position, dodge.PortPosition, 30 * Time.deltaTime);
        }
    }

    public void animationDone()
    {
        playerMovement.enabled = true;
    }
}
