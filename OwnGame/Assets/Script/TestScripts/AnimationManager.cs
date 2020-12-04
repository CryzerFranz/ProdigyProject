using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationManager : MonoBehaviour
{
    public bool animationIsPlayer = false;
    private Animator animator;

    private Movement playerMovement;
    private NavMeshAgent playerNavMeshAgent;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<Movement>();
        playerNavMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("melee_spalten_idle"))
        {
            playerNavMeshAgent.ResetPath();    
            animationIsPlayer = true;
            Debug.Log(playerMovement.isActiveAndEnabled);
        }
        else
        {
            animationIsPlayer = false;
            playerMovement.enabled = true;
            Debug.Log("else verzweigung");
        }
    }
}
