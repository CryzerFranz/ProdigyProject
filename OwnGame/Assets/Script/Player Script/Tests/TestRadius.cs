using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRadius : MonoBehaviour
{
    // Start is called before the first frame update


    public Collider[] entered; 
    public float radius = 20.0f;
    void Start()
    {
        
    }

    void Update()
    {
        entered = Physics.OverlapSphere(transform.position, radius, 1 << 9);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
