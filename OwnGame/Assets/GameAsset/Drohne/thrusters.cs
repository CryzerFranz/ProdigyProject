using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrusters : MonoBehaviour
{
    public DroneControl drone;

    private InputManager input;


    void Start()
    {
        input = InputManager.instance;
    }
    void Update()
    {
        if (drone.Engine == true)
        {
            if (input.GetKey(KeybindingActions.Up))
            {
                Vector3 tempVect = new Vector3(0, 0.05f, 0);
                //Vector3 newPosition = rb.position + transform.TransformDirection(tempVect);
                transform.Translate(Vector3.up * Time.deltaTime);
            }
            if (input.GetKey(KeybindingActions.Down))
            {
                Vector3 tempVect = new Vector3(0, -0.05f, 0);
                //Vector3 newPosition = rb.position + transform.TransformDirection(tempVect);
                transform.Translate(-Vector3.up * Time.deltaTime);

            }
        }
    }
}
