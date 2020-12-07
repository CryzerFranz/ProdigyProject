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
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<Movement>();
        playerNavMeshAgent = GetComponent<NavMeshAgent>();
        dodge = GetComponent<Dodge>();
    }
    void Update()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("melee_spalten_idle"))
        {
            playerNavMeshAgent.ResetPath();    
            Debug.Log(playerMovement.isActiveAndEnabled);
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("rollBack"))
        {
            //Debug.Log("rollBack");
            //Debug.Log("dodge.newPosition = " + dodge.PortPosition);
            //transform.Translate(dodge.PortPosition);
            transform.position = Vector3.MoveTowards(transform.position, dodge.PortPosition, 30 * Time.deltaTime);

        }

    }

    public void animationDone()
    {
        playerMovement.enabled = true;
    }
}
