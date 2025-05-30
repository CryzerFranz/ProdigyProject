﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloattingText : MonoBehaviour
{
    // Start is called before the first frame update
    public float DestroyTime = 0.1f;
    public Vector3 Offset = new Vector3(0, 2, 0);
    public Vector3 RandomizeIntensity = new Vector3(1, 0, 0);
    void Start()
    {
        Destroy(gameObject, DestroyTime);
        transform.localPosition += Offset;
        transform.localPosition += new Vector3(Random.Range(-RandomizeIntensity.x, RandomizeIntensity.x),
            Random.Range(-RandomizeIntensity.y, RandomizeIntensity.y),
            Random.Range(-RandomizeIntensity.z, RandomizeIntensity.z));
    }


}
