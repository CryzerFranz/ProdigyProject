using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnClick_Portal : MonoBehaviour
{
    public void Portal0()
    {
        Debug.Log("geht");
        NavMeshAgent player = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        Transform target = GameObject.Find("Port_Position").GetComponent<Transform>();
        PausedGame.Resume();
        player.Warp(target.position);
    } 
}
