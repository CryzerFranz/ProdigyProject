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
    void FixedUpdate()
    {
        if (drone.Engine == true)
        {
            if (input.GetKey(KeybindingActions.Up))
            {
                Vector3 tempVect = new Vector3(0, 0.05f, 0);
                Vector3 newPosition = drone.rb.position + transform.TransformDirection(tempVect);
                drone.rb.MovePosition(newPosition);
            }
            if (input.GetKey(KeybindingActions.Down))
            {
                Vector3 tempVect = new Vector3(0, -0.05f, 0);
                Vector3 newPosition = drone.rb.position + transform.TransformDirection(tempVect);
                drone.rb.MovePosition(newPosition);
            }
        }
    }
}
