using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


public class Movement : MonoBehaviour
{
    private Transform playerRespawnPoint;
    private NavMeshAgent playerNavMeshAgent;
    private Health health;
    private Animator animator;
    private Camera playerCamera;

    private GameObject deathTransition;

   
    void Start()
    {

        playerRespawnPoint = PlayerManager.instance.respawnPoint.transform;
        deathTransition = PlayerManager.instance.deathTransition;

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

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit, 100))
                {
                    PlayerManager.instance.playerFollowTarget = false;
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
                    if(!PlayerManager.instance.playerFollowTarget)
                    {
                        playerNavMeshAgent.ResetPath();                    
                    }
                }
            }
        }
        else
        {
            playerNavMeshAgent.ResetPath();
            if(Input.anyKeyDown)
            {
                //reset life
                health.ResetHealth();
                // teleport player to respawn point
                playerNavMeshAgent.Warp(playerRespawnPoint.position);
                // reset animation
                animator.SetTrigger("Respawn");
                // deactivate death transition
                deathTransition.SetActive(false);
                // reactivate UI
                PlayerManager.instance.userInterface.SetActive(true);

                // reset maxHealth ( maxHealth  >= 0 ? player movement activ : player movement disabled )
            }
        }
    }
 
}
