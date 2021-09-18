using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMissingColliders : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] gameObjects;
    void Start()
    {
        gameObjects = Object.FindObjectsOfType<GameObject>();
        foreach(GameObject g in gameObjects)
        {
            if(g.GetComponent<Collider>() == null)
            {
                g.AddComponent<MeshCollider>();            
            }
        }
    }
}
