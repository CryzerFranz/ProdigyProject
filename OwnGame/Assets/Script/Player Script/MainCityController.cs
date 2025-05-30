﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCityController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator anim;

    public float speed = 6f;

    public float Smoothness = 0.1f;
    float SmoothnessVelocity;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            anim.SetFloat("Forward", 1);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref SmoothnessVelocity, Smoothness);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * new Vector3(0,-1,1);
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            anim.SetFloat("Forward", 0);
        }

    }
}
