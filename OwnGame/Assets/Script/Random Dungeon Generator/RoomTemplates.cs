using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class RoomTemplates : MonoBehaviour
{
    public NavMeshSurface navmesh;
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;
    public GameObject boss;

    private float coolDown = 15f;

    private bool spawnedBoss = false;

    private void Update()
    {
        if (coolDown <= 0 && spawnedBoss == false)
        {
            Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
            var inf = navmesh.GetBuildSettings();
            inf.agentHeight= 1;
            navmesh.BuildNavMesh();
            spawnedBoss = true;
        }
        coolDown -= Time.deltaTime;
    }
}
