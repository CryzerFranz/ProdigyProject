using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;



public class playerDetector : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent enemyNavMeshAgent;

    bool sawPlayer = false;
    public Attacking attack;
    public Transform player;

    [Range(2.0f, 360f)]
    public float maxAngle;

    //default max radius if player is escaped from enemy
    public float minRadius = 10f;
    public float maxRadius = 10f;
    //new radius if the player has been seen
    public float radiusSeenPlayer = 15f;


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
        if (!isInFOV)
        {
            Gizmos.color = Color.cyan;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);
    }


    //checking if player is in the Radius and viewAngle of the enemy
    public static bool inFOV(NavMeshAgent enemyToTarget, Transform checkingObject, Transform target, float maxAngle, ref float maxRadius, ref bool sawPlayer, float newMaxRadius)
    {

        if(Physics.CheckSphere(checkingObject.position, maxRadius, 1 << 8))
        { 
            //calculate the position between the objects
            Vector3 directionBetween = (target.position - checkingObject.position).normalized;
            //the y axis postion isn't important 
            directionBetween.y *= 0;

            float angle = Vector3.Angle(checkingObject.forward, directionBetween);

            if (angle <= maxAngle)
            {
                //We are in the view angle of the AI
                Ray ray = new Ray(checkingObject.position, target.position - checkingObject.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, maxRadius))
                {
                    if (hit.transform == target)
                    {
                        sawPlayer = true;
                        maxRadius = newMaxRadius;
                        enemyToTarget.SetDestination(target.position);
                        return true;
                    }
                }
            }
        }
        return false;
    }
    private void checkPlayerInRadius(NavMeshAgent enemyToTarget, Transform target, ref bool sawPlayer,ref float maxRadius, float minRadius)
    {
        if (Physics.CheckSphere(transform.position, maxRadius, 1 << 8) && sawPlayer == true)
        {
            enemyToTarget.SetDestination(target.position);
        }
        else
        {
            sawPlayer = false;
            maxRadius = minRadius;
        }
    }

    private void Update()
    {
       int distance = (int)Vector3.Distance(player.position, transform.position);
       isInFOV = inFOV(enemyNavMeshAgent, transform, player, maxAngle, ref maxRadius, ref sawPlayer, radiusSeenPlayer);
       if (isInFOV)
       {
           if (distance <= enemyNavMeshAgent.stoppingDistance)
           {
               attack.BasicAttack(20);
           }
       }
       checkPlayerInRadius(enemyNavMeshAgent, player, ref sawPlayer,ref maxRadius, minRadius);
        
    }

    private void Start()
    {
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }
}
