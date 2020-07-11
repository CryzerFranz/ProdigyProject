using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interact : MonoBehaviour
{
    public float interactRadius = 2.0f;

    public NavMeshAgent playerNavMeshAgent;
    public Transform targetToPort;

    //eigene script bekommen... not final
   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
