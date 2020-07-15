using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnClick_Portal : MonoBehaviour
{
    public void Portal0()
    {
        NavMeshAgent player = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        Transform target = GameObject.Find("Port_Position0").GetComponent<Transform>();
        PausedGame.Resume();
        player.Warp(target.position);
    }

    public void Portal1()
    {
        NavMeshAgent player = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        Transform target = GameObject.Find("Port_Position1").GetComponent<Transform>();
        PausedGame.Resume();
        player.Warp(target.position);
    }
}
