using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookToMouse : MonoBehaviour
{
    private void Update()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, transform.position);
        float rayLenght;

        if(groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}

