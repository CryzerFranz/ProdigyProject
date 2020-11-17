 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class face_to_player : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Player Transform")]
    [SerializeField]
    private Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 4f);
    }
}
