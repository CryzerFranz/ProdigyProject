using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dodge : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    Movement move;
    NavMeshAgent nv;

    [SerializeField]
    GameObject arrow;
    [SerializeField]
    Transform arrow_End_point;
    GameObject actualArrow;



    float dodgeCDR = 0.15f;
    float dodgeCoolDown = 0f;

    Vector3 portPosition;
    RaycastHit hit; 
    Ray ray;

    bool isArrowSpawned = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        move = GetComponent<Movement>();
        nv = GetComponent<NavMeshAgent>();
       
    }
    // Update is called once per frame
    void Update()
    {

        dodgeCoolDown -= Time.deltaTime;
        if(dodgeCoolDown <= 0f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                move.enabled = false;
                nv.ResetPath();
                Time.timeScale = 0.5f;

                if(!isArrowSpawned)
                {
                    spawnArrow();
                }

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    portPosition = actualArrow.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.position;
                    Debug.Log(portPosition);
                    destroyArrow();
                    //movePlayerToMouseClickPosition();
                    Time.timeScale = 1f;
                    animator.SetTrigger("Dodge");
                    transform.position = Vector3.MoveTowards(transform.position, portPosition, 10 * Time.deltaTime);
                    dodgeCoolDown = 1f / dodgeCDR;
                }
            }
            else
            {
                if(isArrowSpawned)
                {
                    destroyArrow();
                }
                move.enabled = true;
                Time.timeScale = 1f;

            }
        }

       
    }
    private void movePlayerToMouseClickPosition()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            portPosition = hit.point;
            animator.SetTrigger("Dodge");
        }

    }
    public void dodgeDone()
    {
        Time.timeScale = 1f;
        move.enabled = true;
    }

    private void spawnArrow()
    {
        isArrowSpawned = true;
        actualArrow = Instantiate(arrow, transform.position, Quaternion.Euler(0, 90, 0), transform);
    }
    private void destroyArrow()
    {
        Destroy(actualArrow);
        isArrowSpawned = false;
    }

    public Vector3 PortPosition
    {
        get { return portPosition; }
        set { portPosition = value; }
    }
}
