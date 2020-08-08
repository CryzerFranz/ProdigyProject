using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


public class Movement : MonoBehaviour
{
    private NavMeshAgent playerNavMeshAgent;
    private Health health;
    private Animator animator;
    private Camera playerCamera;

    int layer_mask;
    bool isFollowTarget = false;
   
    void Start()
    {
        layer_mask = LayerMask.GetMask("enemy");
        playerNavMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();

        playerCamera = Camera.main;  
    }

    void Update()
    {
        if (!health.IsPlayerDead)
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("RightCLick");
                if (Physics.Raycast(ray, out hit, 100, layer_mask))
                {
                    isFollowTarget = true;
                    animator.SetFloat("Forward", 2f);
                    playerNavMeshAgent.SetDestination(hit.point);
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                isFollowTarget = false;
                if (Physics.Raycast(ray, out hit, 100))
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

                    if (!isFollowTarget)
                    {
                        playerNavMeshAgent.ResetPath();
                    }
                }
                else
                {
                    if (isFollowTarget)
                    {
                        animator.SetFloat("Forward", 2f);
                    }
                }
            }
        }
        else
        {
            playerNavMeshAgent.ResetPath();
        }
    }
 
}
