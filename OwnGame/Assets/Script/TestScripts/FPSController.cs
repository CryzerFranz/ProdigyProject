﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    // W - Forward
    // S - Backward
    // A - Left
    // D - Right

    // U - increase speed
    // K - decrease speed

    // Shift - running
    float speed = 20;
    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            speed += 2.5f;
        }
        if (speed > 0)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                speed -= 2.5f;
            }
        }
        else
        {
            Debug.Log("Speed is 0");
        }
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(new Vector3(1 * x , 0, 1 * z) * (speed * 2) * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.Space))
        {

                transform.Translate(new Vector3(1 * x, 0.5f, 1 * z) * (speed) * Time.deltaTime); 
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {

            transform.Translate(new Vector3(1 * x, -0.5f, 1 * z) * (speed) * Time.deltaTime);
        }
        else
            transform.Translate(new Vector3(1 * x, 0 ,1 * z) * (speed) * Time.deltaTime);
        


    }
}
