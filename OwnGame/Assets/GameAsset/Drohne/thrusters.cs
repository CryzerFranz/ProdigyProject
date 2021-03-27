using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrusters : MonoBehaviour
{
    private InputManager input;

    void Start()
    {
        input = InputManager.instance;
    }
    void FixedUpdate()
    {
        //if(base.Engine == true)
        //{
        //    if (input.GetKey(KeybindingActions.Up))
        //    {
        //        Vector3 tempVect = new Vector3(0, 5, 0);
        //        tempVect = tempVect * base.speed * Time.deltaTime;
        //        base.rb.MovePosition(base.transform.position + tempVect);
        //    }
        //    if (input.GetKey(KeybindingActions.Down))
        //    {
        //        Vector3 tempVect = new Vector3(0, -5, 0);
        //        tempVect = tempVect * base.speed * Time.deltaTime;
        //        rb.MovePosition(base.transform.position + tempVect);
        //    }
        //}
    }
}
