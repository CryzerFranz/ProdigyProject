using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPort : Interact
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Physics.CheckSphere(transform.position, interactRadius, 1 << 8))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerNavMeshAgent.Warp(targetToPort.position);
            }
        }
    }
}
