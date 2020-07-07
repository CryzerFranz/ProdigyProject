using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class playerDetector : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private bool playerDetected = false;
    private NavMeshAgent enemyNavMeshAgent;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyNavMeshAgent = GameObject.Find("Enemy Dummy").GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected)
        {
            enemyNavMeshAgent.destination = player.transform.position;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerDetected = true;
        }
    }
}
