using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Targetting : MonoBehaviour
{
    [Header("Radius to interact")]
    [SerializeField]
    private float interactRadius = 20.0f;
    [Space]
    [Header("Target symbol")]
    [SerializeField]
    private GameObject TargetSymbol;

    private Transform selectedEnemy;
    private GameObject currentSymbol;
    private Animator playerAnim;
    private List<Transform> targetableEnemies;
    // Start is called before the first frame update
    void Start()
    {
        targetableEnemies = new List<Transform>();
        AddAllEnemies();
        selectedEnemy = null;
        playerAnim = GetComponent<Animator>();
    }

    public void AddAllEnemies()
    {
        GameObject[] go_enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in go_enemies)
        {
            AddTarget(enemy.transform);
        }
    }

    public void AddTarget(Transform enemy)
    {
        targetableEnemies.Add(enemy);
    }

    public void SortEnemyByDistance()
    {
        targetableEnemies.Sort(delegate (Transform t1, Transform t2) 
                                {
                                    return Vector3.Distance(t1.position, transform.position).CompareTo(Vector3.Distance(t2.position, transform.position));
                                });

    }

    private void TargetEnemy()
    {
        bool nothingInRange = false;
        if(selectedEnemy == null)
        {
            SortEnemyByDistance();
            if(isInRange(0))
            {
                selectedEnemy = targetableEnemies[0];
            }
        }
        else
        {
            int index = targetableEnemies.IndexOf(selectedEnemy);
            int tmpIndex = index;
            do
            {
                if (index < targetableEnemies.Count - 1)
                {
                    index++;
                    if (isInRange(index))
                    {
                        break; //break endless loop 
                    }
                }
                else
                {
                    index = 0;
                    if (isInRange(index))
                    {
                        break; //break endless loop
                    }
                }
                nothingInRange = true;
            } while (index != tmpIndex);
            DeselectTarget();
            selectedEnemy = targetableEnemies[index];
        }
        if(selectedEnemy != null)
        {
            SelectTarget();
        }
        if(selectedEnemy != null && nothingInRange)
        {
            DeselectTarget();
            nothingInRange = false;
        }
    }
 
    private bool isInRange(int index)
    {
        float distance = Vector3.Distance(transform.position, targetableEnemies[index].position);
        
        if(distance <= interactRadius)
        {
            return true;
        }
        return false;
    }

    private void SelectTarget()
    {
        // selectedEnemy.GetComponentInChildren<Renderer>().material.color = Color.red;
       

        currentSymbol = Instantiate(TargetSymbol, selectedEnemy.position, Quaternion.Euler(90,0,0) ,selectedEnemy);
    }
    public void DeselectTarget()
    {
        Destroy(currentSymbol);
        selectedEnemy = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TargetEnemy();
        }
        if(selectedEnemy != null && playerAnim.GetFloat("Forward") < 1f)
        {
            //facing target
            Vector3 direction = (selectedEnemy.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
