using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Movement_TopDown : MonoBehaviour
{
    // private
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private TopDownPlayerController playerInput;

    private Animator _animator;

    private bool followTarget;
    private GameObject targetPosition;

    // Animator IDs

    private int _animIDRun;

    private bool collided;

    private void Awake()
    {
        playerInput = new TopDownPlayerController();
    }

    private void OnEnable()
    {
        playerInput.Movement.Enable();
    }

    private void OnDisable()
    {
        playerInput.Movement.Disable();  
    }

    private void Start()
    {
        playerInput.Movement.Select.performed += ctx1 => moveToDestination();
        playerInput.Movement.Target.performed += ctx2 => moveToTarget();
        _animator = GetComponent<Animator>();
        followTarget = false;
        targetPosition = null;
        collided = false;

        //get Animation IDs

        _animIDRun = Animator.StringToHash("Forward");

    }

    private void Update()
    {
        // check if player reach his destination
        if(!followTarget)
        {
            float distanceRemaining = navMeshAgent.remainingDistance;
            if (distanceRemaining != Mathf.Infinity && navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && navMeshAgent.remainingDistance == 0)
            {
                _animator.SetFloat(_animIDRun, 0.0f);
                navMeshAgent.ResetPath();
            }
        }
        else
        {
            if(!collided )
            {
                _animator.SetFloat(_animIDRun, 1.0f);
                navMeshAgent.SetDestination(targetPosition.transform.position);
            }
            
        }
    }

    private void moveToDestination()
    {
       
        RaycastHit hit;
        if(Physics.Raycast(getRay(), out hit))
        {
            _animator.SetFloat(_animIDRun, 1.0f);
            followTarget = false;
            navMeshAgent.SetDestination(hit.point);
        }
    }

    private void moveToTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(getRay(), out hit))
        {
            if(hit.transform.gameObject.tag == "Enemy")
            {
                _animator.SetFloat(_animIDRun, 1.0f);
                followTarget = true;
                targetPosition = hit.transform.gameObject;
                navMeshAgent.SetDestination(hit.point);
            }
        }
    }

    private Ray getRay()
    {
        Vector2 mousePos = playerInput.Movement.MousePosition.ReadValue<Vector2>();
        Ray clickRay = playerCamera.ScreenPointToRay(mousePos);
        return clickRay;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Entered");
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy collision");

            _animator.SetFloat(_animIDRun, 0.0f);
            navMeshAgent.ResetPath();
            collided = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // should check if enemy is still alive 
        Debug.Log("Collision Exit");
        if (followTarget && other.gameObject.tag == "Enemy")
        {
            _animator.SetFloat(_animIDRun, 1.0f);
            navMeshAgent.SetDestination(targetPosition.transform.position);
            collided = false;
        }
    }
 
}
