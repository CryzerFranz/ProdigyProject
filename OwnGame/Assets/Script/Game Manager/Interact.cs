using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public float interactRadius = 2.0f;

    public NavMeshAgent playerNavMeshAgent;
    public Transform targetToPort;
       
    public void DisplayOnHUD_E(bool isInRange, GameObject displayObject)
    {
        if(isInRange)
        {
            displayObject.SetActive(isInRange);
        }
        else
        {
            displayObject.SetActive(isInRange);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
