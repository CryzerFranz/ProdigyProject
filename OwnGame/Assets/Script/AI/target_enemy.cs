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

    private int layer_mask;

    void Start()
    {
        playerTransform = PlayerManager.instance.respawnPoint.transform;

        layer_mask = LayerMask.GetMask("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(1) || PlayerManager.instance.playerFollowTarget)
        {
            if (Physics.Raycast(ray, out hit, 100, layer_mask))
            {
                animator.SetFloat("Forward", 2f);
                playerNavMeshAgent.SetDestination(hit.point);
                PlayerManager.instance.playerFollowTarget = true;

            }
        }
        if(PlayerManager.instance.playerFollowTarget)
        {
            FaceTarget();
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (transform.position - playerTransform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, lookRotation, Time.deltaTime * 4f); ;
    }
}


