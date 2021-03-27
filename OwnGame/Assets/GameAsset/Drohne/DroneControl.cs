using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneControl : MonoBehaviour
{

    Quaternion standardRotation = new Quaternion(0,0,0,1);
    // Start is called before the first frame update

    private InputManager input;

    public float speed = 10f;
    [NonSerialized]
    public Rigidbody rb;
    private bool engineOn = false;

    void Start()
    {
        input = InputManager.instance;
        rb = GetComponent<Rigidbody>();
    }

    public bool Engine
    {
        get { return engineOn; }
    }

    void Update()
    {
        if (input.GetKeyDown(KeybindingActions.EngineOnOf))
        {
            if (!engineOn)
            {
                rb.drag = 50;
                engineOn = true;
            }
            else
            {
                rb.drag = 0;
                rb.WakeUp();
                engineOn = false;
            }
        }
    }
    void FixedUpdate()
    {
        
        //if(input.GetKey(KeybindingActions.Up))
        //{
        //    Vector3 tempVect = new Vector3(0, 5, 0);
        //    tempVect = tempVect * speed * Time.deltaTime;
        //    rb.MovePosition(transform.position + tempVect);
        //}
        //if (input.GetKey(KeybindingActions.Down))
        //{
        //    Vector3 tempVect = new Vector3(0, -5, 0);
        //    tempVect = tempVect * speed * Time.deltaTime;
        //    rb.MovePosition(transform.position + tempVect);
        //}
        if (input.GetKey(KeybindingActions.forward))
        {
            Vector3 tempVect = new Vector3(0, 0, 5);
            tempVect = tempVect * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect);
        }
        if (input.GetKey(KeybindingActions.backward))
        {
            Vector3 tempVect = new Vector3(0, 0, -5);
            tempVect = tempVect * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect);
        }
        if (input.GetKey(KeybindingActions.right))
        {
            Vector3 tempVect = new Vector3(5, 0, 0);
            tempVect = tempVect * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect);
        }
        if (input.GetKey(KeybindingActions.left))
        {
            Vector3 tempVect = new Vector3(-5, 0, 0);
            tempVect = tempVect * speed * Time.deltaTime;
            rb.MovePosition(transform.position + tempVect);
        }
        if(input.GetKey(KeybindingActions.rotateLeft))
        {
            transform.Rotate(new Vector3(0, 0, 2) * 50 * Time.deltaTime);
        }
        if (input.GetKey(KeybindingActions.rotateRight))
        {
            transform.Rotate(new Vector3(0, 0, -2) * 50 * Time.deltaTime);
        }

    }
}
