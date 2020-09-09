using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting : MonoBehaviour
{
    public List<Transform> targetableEnemies;
    public Transform selectedEnemy;
    // Start is called before the first frame update
    void Start()
    {
        targetableEnemies = new List<Transform>();
        AddAllEnemies();
        selectedEnemy = null;
    }

    public void AddAllEnemies()
    {
        GameObject[] go_enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in go_enemies)
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
        if(selectedEnemy == null)
        {
            SortEnemyByDistance();
            selectedEnemy = targetableEnemies[0];
        }
        else
        {
            int index = targetableEnemies.IndexOf(selectedEnemy);

            if(index < targetableEnemies.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            selectedEnemy = targetableEnemies[index];
        }
        SelectTarget();
    }

    private void SelectTarget()
    {
        selectedEnemy.GetComponentInChildren<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TargetEnemy();
        }
    }
}
