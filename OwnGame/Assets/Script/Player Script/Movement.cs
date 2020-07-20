using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


public class Movement : MonoBehaviour
{
    //To set animation
    //private Animator playerAnimator;
    //public Interact focus;
    private NavMeshAgent playerNavMeshAgent;
    private Camera playerCamera;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //playerAnimator = GetComponent<Animator>();
        playerNavMeshAgent = GetComponent<NavMeshAgent>();
        playerCamera = Camera.main;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Input.GetMouseButtonDown(0))
        {
            //keyword out because hit isn't assigned, for people who not remember how to code in C# kappa
            if(Physics.Raycast(ray, out hit, 100))
            {
                animator.SetFloat("Forward", 2f);
               playerNavMeshAgent.SetDestination(hit.point);
            }
        }
        else
        {
            float distanceRemaining = playerNavMeshAgent.remainingDistance;
            if (distanceRemaining != Mathf.Infinity && playerNavMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && playerNavMeshAgent.remainingDistance == 0)
            {
                animator.SetFloat("Forward", 0f);
                playerNavMeshAgent.ResetPath();
            }
        }

        //if (playerNavMeshAgent.remainingDistance <= playerNavMeshAgent.stoppingDistance)
        //{
        //    animator.SetFloat("Forward", 0f);
        //    //playerNavMeshAgent.ResetPath();
        //}

       

    }
 
}
