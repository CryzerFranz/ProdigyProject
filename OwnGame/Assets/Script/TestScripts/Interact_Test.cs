using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Test : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public Transform player;
    public float interactRadius = 5f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Physics.CheckSphere(transform.position, interactRadius, 1 << 8))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("Entry");
            }
        }
    }


}
