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

            //if (Input.GetMouseButtonDown(1))
            //{
            //    Debug.Log("RightCLick");
            //    if (Physics.Raycast(ray, out hit, 100, layer_mask))
            //    {
            //        isFollowTarget = true;
            //        animator.SetFloat("Forward", 2f);
            //        playerNavMeshAgent.SetDestination(hit.point);
            //    }
            //}

            if (Input.GetMouseButtonDown(0))
            {
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
                    playerNavMeshAgent.ResetPath();                    
                }
            }
        }
        else
        {
            playerNavMeshAgent.ResetPath();
            if(Input.anyKeyDown)
            {
                Debug.Log("Respawn");

                //respawn player at xyz
                health.healthbar.SetMaxHealth(health.MaxHealth);
                playerNavMeshAgent.Warp(playerRespawnPoint.position);
                deathTransition.SetActive(false);
                PlayerManager.instance.deathTransition.SetActive(true);
                //Debug.Log(health.);

                // reset maxHealth ( maxHealth  >= 0 ? player movement activ : player movement disabled )

                

            }
        }
    }
 
}
