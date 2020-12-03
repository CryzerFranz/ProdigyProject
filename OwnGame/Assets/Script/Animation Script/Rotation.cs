using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Rotation")]
    [SerializeField]
    private float rotateSpeedX;
    [SerializeField]
    private float rotateSpeedY;
    [SerializeField]
    private float rotateSpeedZ;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotateSpeedX, rotateSpeedY, rotateSpeedZ));
    }
}
