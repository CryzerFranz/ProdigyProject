using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    //To set animation
    //private Animator playerAnimator;
    
    private NavMeshAgent playerNavMeshAgent;
    private Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        //playerAnimator = GetComponent<Animator>();
        playerNavMeshAgent = GetComponent<NavMeshAgent>();
        playerCamera = GameObject.Find("Player_Camera").GetComponent<Camera>();
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
                playerNavMeshAgent.destination = hit.point;
            }
        }
    }
}
