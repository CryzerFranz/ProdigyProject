using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class target_enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent playerNavMeshAgent;
    public Animator animator;
    public Camera playerCamera;

    private Transform playerTransform;

    private bool isFollowTarget;
    private int layer_mask;

    void Start()
    {
        playerTransform = PlayerManager.instance.respawnPoint.transform;

        isFollowTarget = false;
        layer_mask = LayerMask.GetMask("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(1) || isFollowTarget)
        {
            if (Physics.Raycast(ray, out hit, 100, layer_mask))
            {
                isFollowTarget = true;
                animator.SetFloat("Forward", 2f);
                playerNavMeshAgent.SetDestination(this.transform.position);
                Debug.Log(this.name);
                Debug.Log(this.transform.position);
                isFollowTarget = false;

            }
        }
    }
}
