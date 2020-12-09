using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class PathCreator_FollowLinesTest : MonoBehaviour
{
    [SerializeField]
    float speed = 2;
    public PathCreator path;
    float distance;

    void Update()
    {
        distance += speed * Time.deltaTime;
        transform.position = path.path.GetPointAtDistance(distance);
        transform.rotation = path.path.GetRotationAtDistance(distance);
    }
}
