﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    //radius to interact with the player
    public float interactRadius = 2.0f;
   
    public static bool playerIsInsight = false;
    public NavMeshAgent playerNavMeshAgent;
    public GameObject ui_E_text;

    //Display E over the Object to interact
    public void DisplayOnHUD_E(GameObject displayObject)
    {
        if(playerIsInsight)
        {
            displayObject.SetActive(playerIsInsight);
        }
        else
        {
            displayObject.SetActive(playerIsInsight);
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
