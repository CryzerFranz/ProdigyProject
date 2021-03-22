using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneControl : MonoBehaviour
{

    Quaternion standardRotation = new Quaternion(0,0,0,1);
    // Start is called before the first frame update

    private InputManager input;

    public float speed = 10f;
    private Rigidbody rb;

    void Start()
    {
        input = InputManager.instance;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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

    }
}
