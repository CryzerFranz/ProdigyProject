using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float sensitivityX = 15f;
    public float sensitivityY = 15f;
    void Update()
    {
        float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
        float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * sensitivityY;
        transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
    }
}
