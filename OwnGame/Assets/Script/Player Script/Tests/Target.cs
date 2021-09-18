using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Player input controller")]
    [SerializeField] private TopDownPlayerController playerInput;

    [Header("Symbol of the targetted enemy")]
    [SerializeField] private GameObject symbol;

    [Header("Radius to target possible enemies")]
    [SerializeField]
    private float radius = 20.0f;


    private Movement_TopDown playerMovement;

    private Transform selectedEnemy;
    private GameObject currentSymbol;
    
    private List<Transform> targetableEnemies;
    private Collider[] radiusRangeEntered;

    private int currentIndex;

    void Start()
    {
        playerMovement = GetComponent<Movement_TopDown>();
        targetableEnemies = new List<Transform>();
        playerInput.Combat.Target.performed += ctx => target();
        currentIndex = 0;
        selectedEnemy = null;
    }

    private void Update()
    {
        radiusRangeEntered = Physics.OverlapSphere(transform.position, radius, 1 << 9);

        if(selectedEnemy != null && !isInRange(currentIndex))
        {
            DeselectTarget();
            selectedEnemy = null;
            currentIndex = 0;
        }
        if(selectedEnemy != null && isInRange(currentIndex))
        {
            //facing target
            Vector3 direction = (selectedEnemy.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        }
    }

    private bool isInRange(int index)
    {
        float distance = Vector3.Distance(transform.position, targetableEnemies[index].position);

        if (distance <= radius)
        {
            return true;
        }
        return false;
    }

    private void Awake()
    {
        playerInput = new TopDownPlayerController();
    }

    private void OnEnable()
    {
        playerInput.Combat.Enable();
    }

    private void OnDisable()
    {
        playerInput.Combat.Disable();
    }

    private void target()
    {
        targetableEnemies.Clear();
        if(radiusRangeEntered.Length > 0)
        { 
            foreach (Collider enemy in radiusRangeEntered)
            {
                targetableEnemies.Add(enemy.transform);
            }
            SortEnemyByDistance();
            if(selectedEnemy == null)
            {
                selectedEnemy = targetableEnemies[currentIndex];
                Debug.Log(selectedEnemy.name);
            }
            else
            {
                currentIndex = targetableEnemies.IndexOf(selectedEnemy) + 1;
                if(currentIndex > targetableEnemies.Count - 1)
                {
                    currentIndex = 0;
                }
                selectedEnemy = targetableEnemies[currentIndex];
                DeselectTarget();
            }
            SelectTarget();

            //if (selectedEnemy != null)
            //{
            //    DeselectTarget();
            //}
        }
    }

    private void SelectTarget()
    {
        currentSymbol = Instantiate(symbol, selectedEnemy.position, Quaternion.Euler(0, 0, 0), selectedEnemy);
    }

    public void DeselectTarget()
    {
        Destroy(currentSymbol);
    }

    public void SortEnemyByDistance()
    {
        targetableEnemies.Sort(delegate (Transform t1, Transform t2)
        {
            return Vector3.Distance(t1.position, transform.position).CompareTo(Vector3.Distance(t2.position, transform.position));
        });

    }
}
