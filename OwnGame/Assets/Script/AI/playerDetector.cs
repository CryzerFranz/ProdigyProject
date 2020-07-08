using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class playerDetector : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent enemyNavMeshAgent;


    public Transform player;

    [Range(2.0f, 360f)]
    public float maxAngle;
   
    public float maxRadius;

    private bool isInFOV = false;

    //just drawing lines to show
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);


        //line between the player and the enemy
        if(!isInFOV)
        {
            Gizmos.color = Color.cyan;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxRadius );

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);
    }


    //checking if player is in the Radius and viewAngle of the enemy
    public static bool inFOV(NavMeshAgent enemyToTarget, Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        //Object in the radius are collected in this Collider Array
        Collider[] overlaps = new Collider[20];
        int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps);

        for (int i = 0; i < count; i++)
        {
            if(overlaps[i] != null)
            {
                //checks if the current object ( overlaps[i]) position is equal to the player position
                if(overlaps[i].transform == target)
                {
                    //calculate the position between the objects
                    Vector3 directionBetween = (target.position - checkingObject.position).normalized;
                    //the y axis postion isn't important 
                    directionBetween.y *= 0;


                    float angle = Vector3.Angle(checkingObject.forward, directionBetween);


                    if(angle <= maxAngle)
                    {
                        //We are in the view angle of the AI

                        Ray ray = new Ray(checkingObject.position, target.position - checkingObject.position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit, maxRadius))
                        {
                            if (hit.transform == target)
                            {
                                enemyToTarget.SetDestination(target.position);
                                return true;
                            }
                        }
                    }
                }
            }
        }

        return false;
    }
    private void Update()
    {
        isInFOV = inFOV(enemyNavMeshAgent, transform, player, maxAngle, maxRadius);
    }

    private void Start()
    {
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }
}
