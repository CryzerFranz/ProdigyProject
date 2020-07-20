using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Stats : MonoBehaviour
{
    public GameObject Player;
    
    public GameObject Enemy1;
    public GameObject Enemy2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player: " + Player.GetComponent<PlayerStats>().LifePoints);
        Debug.Log("Enemy1: " + Enemy1.GetComponent<EnemyStats>().LifePoints);
        Debug.Log("Enemy2: " + Enemy2.GetComponent<EnemyStats>().LifePoints);
        Debug.Log("Enemy1: " + Enemy1.GetComponent<EnemyStats>().LifePoints);


    }


}
