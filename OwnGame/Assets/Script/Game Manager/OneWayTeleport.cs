using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneWayTeleport : Interact
{
    // Update is called once per frame
    public Transform targetToPort;
    private void Update()
    {
        if (Physics.CheckSphere(transform.position, interactRadius, 1 << 8))
        {
            playerIsInsight = true;
            DisplayOnHUD_E(ui_E_text);
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerNavMeshAgent.Warp(targetToPort.position);
            }
        }
        else
        {
            playerIsInsight = false;
            DisplayOnHUD_E(ui_E_text);
        }
    }
}
