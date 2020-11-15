using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
    // Start is called before the first frame update
    private Material material;

    private float startPosition = 0;
    
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        startPosition += 0.0005f;
        material.SetTextureOffset("_MainTex", new Vector2(startPosition, 0));
    }
}
