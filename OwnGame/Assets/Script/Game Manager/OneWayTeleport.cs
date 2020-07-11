using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneWayTeleport : Interact
{
    // Start is called before the first frame update
    public GameObject ui_E_text;
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Physics.CheckSphere(transform.position, interactRadius, 1 << 8))
        {
            DisplayOnHUD_E(true, ui_E_text);
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerNavMeshAgent.Warp(targetToPort.position);
            }
        }
        else
        {
            DisplayOnHUD_E(false, ui_E_text);
        }
    }
}
