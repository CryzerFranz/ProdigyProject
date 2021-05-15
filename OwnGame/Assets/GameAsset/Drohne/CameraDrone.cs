using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrone : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target);        // Face the object


        // Define a target position above and behind the target transform
        //Vector3 targetPosition = Target.TransformPoint(new Vector3(0, 5, -10));

        //// Smoothly move the camera towards that target position
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
